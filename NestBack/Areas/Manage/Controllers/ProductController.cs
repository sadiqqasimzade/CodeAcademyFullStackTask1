
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestBack.DAL;
using NestBack.Models;
using NestBack.Utilies;
using NestBack.Utilies.Extensions;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NestBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class ProductController : Controller
    {
        private AppDbContext _context { get; }
        public ProductController(AppDbContext context)
        {
            _context = context;
        }



        public async Task<IActionResult> Index()
        {
            List<Product> products = await _context.Products.Include(p => p.Category).Include(p => p.productImgs).ToListAsync();
            return View(products);
        }



        public async Task<IActionResult> Create()
        {
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }



        public async Task<IActionResult> Update(int id)
        {
            Product product = await _context.Products.Include(p => p.Category).Include(p => p.productImgs).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound(); //edit with statuscode
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View(product);
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View();
            }
            if (product == null || product.File == null || product.File.Count == 0)
            {
                ModelState.AddModelError("File", "Need Photo");
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View();
            }
            if (_context.Products.FirstOrDefault(p => p.Name.ToLower().Trim() == product.Name.ToLower().Trim()) != null)
            {
                ModelState.AddModelError("Name", "Product with this name already exsists");
                ViewBag.Categories = await _context.Categories.ToListAsync();
                return View();
            }
            
            product.productImgs = new List<ProductImg>();
            for (int i = 0; i < product.File.Count; i++)
            {
                if (product.File[i] != null && product.File[i].CheckSize(Constants.ProductImgMaxSizeInKb) && product.File[i].CheckType("image/"))
                {
                    string filename = Guid.NewGuid().ToString() + product.File[i].FileName;
                    if (filename.Length > Constants.ProductNameMaxLength)
                        filename=filename.Substring(filename.Length - Constants.ProductNameMaxLength, Constants.ProductNameMaxLength);
                    using (FileStream fileStream = new FileStream(System.IO.Path.Combine(Constants.ProductImgPath, filename), FileMode.Create))
                        await product.File[i].CopyToAsync(fileStream);

                    ProductImg productImg = new ProductImg();
                    if (i == 0)
                        productImg = new ProductImg()
                        {
                            Img = filename,
                            IsFront = true,
                            ProductId = product.Id
                        };

                    else
                        productImg = new ProductImg()
                        {
                            Img = filename,
                            IsFront = false,
                            ProductId = product.Id
                        };
                    product.productImgs.Add(productImg);
                }
            }
            product.Name=product.Name.Trim();
            product.Desc=product.Desc.Trim();    
            await _context.Products.AddAsync(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Product product)
        {
            if (!ModelState.IsValid) return BadRequest();
            if (_context.Products.FirstOrDefault(p => (p.Name.Trim() == product.Name.Trim())&&(p.Id!=product.Id)) != null)
            {
                ModelState.AddModelError("Name", "Product with this name exist");
                return RedirectToAction(nameof(Update));
            }
            Product dbproduct = await _context.Products.Include(p => p.productImgs).FirstOrDefaultAsync(p => p.Id == product.Id);
            if(dbproduct == null)return BadRequest();

            dbproduct.Name = product.Name.Trim();
            dbproduct.Stock = product.Stock;
            dbproduct.Price = product.Price;
            dbproduct.Desc = product.Desc.Trim();
            dbproduct.Raiting = product.Raiting;
            dbproduct.CategoryId = product.CategoryId;
            dbproduct.BuyPrice = product.BuyPrice;
            dbproduct.DiscountPrice=product.DiscountPrice;
            if (product.File != null)
            {
                foreach (var file in product.File)
                {
                    if (file != null && file.CheckSize(Constants.ProductImgMaxSizeInKb) && file.CheckType("image/"))
                    {

                        string filename = Guid.NewGuid().ToString() + file.FileName;
                        if(filename.Length>Constants.ProductNameMaxLength)
                        filename=filename.Substring(filename.Length - Constants.ProductNameMaxLength, Constants.ProductNameMaxLength);

                        using (FileStream fs = new FileStream(Path.Combine(Constants.ProductImgPath, filename), FileMode.Create))
                            await file.CopyToAsync(fs);

                        ProductImg productImg = new ProductImg();
                        if (dbproduct.productImgs.FirstOrDefault(p => p.IsFront == true) == null)
                            productImg = new ProductImg()
                            {
                                Img = filename,
                                IsFront = true,
                                ProductId = product.Id
                            };
                        else
                            productImg = new ProductImg()
                            {
                                Img = filename,
                                IsFront = false,
                                ProductId = product.Id
                            };
                        dbproduct.productImgs.Add(productImg);
                    }
                }
            }
            if (dbproduct.productImgs.FirstOrDefault(pi => pi.IsFront == true) == null)
                dbproduct.productImgs.Add(new ProductImg() { Img = "404.jpg", IsFront = true, ProductId = product.Id });

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteImg(int id)
        {
            ProductImg img = await _context.ProductImgs.Include(pi=>pi.Product).FirstOrDefaultAsync(pi=>pi.Id==id);
            if (img == null) return NotFound();
            if (img.Img != "404.jpg")
                if (System.IO.File.Exists(Path.Combine(Constants.ProductImgPath, img.Img)))
                    System.IO.File.Delete(Path.Combine(Constants.ProductImgPath, img.Img));
            if(img.IsFront)
			{
               ProductImg temp=await _context.ProductImgs.FirstOrDefaultAsync(pi => pi.ProductId == img.ProductId && pi.IsFront == false);
                if (temp != null)
                    img.Product.productImgs.Find(pi=>pi.Id==temp.Id).IsFront = true;
			}
            _context.ProductImgs.Remove(img);
            await _context.SaveChangesAsync();
            ViewBag.Categories = await _context.Categories.ToListAsync();
            return View();
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Product product = await _context.Products.Include(p => p.productImgs).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            foreach (var img in product.productImgs)
            {
                if (img.Img != "404.jpg")
                    if (System.IO.File.Exists(Path.Combine(Constants.ProductImgPath, img.Img)))
                        System.IO.File.Delete(Path.Combine(Constants.ProductImgPath, img.Img));
            }
            _context.Remove(product);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeState(int id)
        {
            Product product = await _context.Products.FindAsync(id);
            if (product == null) return NotFound(); //fix
            product.IsDeleted = !product.IsDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }



    }
}
