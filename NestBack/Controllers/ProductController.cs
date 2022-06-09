using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestBack.DAL;
using NestBack.Models;
using NestBack.Utilies;
using NestBack.ViewModels;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestBack.Controllers
{
    public class ProductController : Controller
    {
        private AppDbContext _context { get; }
        private readonly UserManager<AppUser> _userManager;
        public ProductController(AppDbContext context,UserManager<AppUser> userManager)
        {
            _context = context;
            _userManager=userManager;
        }
        public IActionResult Index()
        {
            ViewBag.ProductCount = _context.Products.Where(p => p.IsDeleted == false).Count();
            ViewBag.Categories = _context.Categories.Where(p => p.IsDeleted == false).Include(c => c.Products);
            return View(_context.Products.Where(p => p.IsDeleted == false).OrderByDescending(p => p.Id).Take(10).Include(p => p.productImgs).Include(p => p.Category));
        }
        public async Task<IActionResult> Details(int id)
        {
            Product product = await _context.Products.Include(p => p.Category).Include(p => p.productImgs).Include(p => p.comments).FirstOrDefaultAsync(p => p.Id == id);
            if (product == null) return NotFound();
            return View(product);
        }

        public IActionResult Cart()
        {
            List<BasketVM> basketVMs = new List<BasketVM>();
            List<CartProductVM> products = new List<CartProductVM>();
            if (Request.Cookies["Basket"] != null)
            {
                basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Basket"]);
            }
            foreach (var item in basketVMs)
            {
                Product product = _context.Products.Include(p => p.productImgs).FirstOrDefault(pa => pa.Id == item.Productid);
                if (product == null) continue;
                CartProductVM cartitem = new CartProductVM()
                {
                    Id = product.Id,
                    Name = product.Name,
                    Img = product.productImgs.FirstOrDefault(pi => pi.IsFront == true).Img,
                    Price = product.Price,
                    Count = item.Count,
                    Raiting = product.Raiting,
                    IsAbailable = product.Stock > 0 ? true : false
                };
                products.Add(cartitem);
            }

            return View(products);
        }
        public IActionResult LoadMore(int skip)
        {
            IQueryable<Product> p = _context.Products.Where(p => p.IsDeleted == false);
            int productCount = p.Count();
            if (productCount <= skip)
            {
                return Json(new
                {
                    message = ""
                });
            }
            return PartialView("_ProductPartial", p.OrderByDescending(p => p.Id).Skip(skip).Take(10).Include(p => p.productImgs).Include(p => p.Category));
        }
        public IActionResult CategoryFilter(int CategoryId)
        {
            if (_context.Categories.Find(CategoryId) == null) return NotFound();
            return PartialView("_ProductPartial", _context.Products.Where(p => p.IsDeleted == false && p.CategoryId == CategoryId).OrderByDescending(p => p.Id).Include(p => p.productImgs).Include(p => p.Category));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteCart(int id)
        {
            List<BasketVM> baskets = new List<BasketVM>();
            if (Request.Cookies["Basket"] != null)
            {
                baskets = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Basket"]);
            }
            BasketVM item = baskets.Find(i => i.Productid == id);
            if (item == null) return NotFound();
            baskets.Remove(item);
            Response.Cookies.Append("Basket", JsonConvert.SerializeObject(baskets));
            return RedirectToAction(nameof(Cart));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult AddBasket(int? id)
        {
            if (id == null) return BadRequest();
            UpdateBasket((int)id);

            return RedirectToAction(nameof(Index));
        }
        private void UpdateBasket(int id)
        {

            List<BasketVM> basketitems = new List<BasketVM>();
            if (Request.Cookies["Basket"] != null)
            {
                basketitems = JsonConvert.DeserializeObject<List<BasketVM>>(Request.Cookies["Basket"]);
            }
            BasketVM item = basketitems.Find(bi => bi.Productid == id);
            if (item != null)
            {
                item.Count++;
            }
            else
            {
                item = new BasketVM
                {
                    Productid = id,
                    Count = 1,
                };

            }
            basketitems.Add(item);
            Response.Cookies.Append("Basket", JsonConvert.SerializeObject(basketitems));
            return;
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> LeaveComment(string Comment, int productid, string user)
        {
            Product product = await _context.Products.Include(p => p.Category).Include(p => p.productImgs).Include(p => p.comments).FirstOrDefaultAsync(p => p.Id == productid);
            AppUser appuser=await _userManager.FindByNameAsync(user);
            if (!ModelState.IsValid || Comment.Length <= 0 || product == null||user==null)
            {
                if(product == null) return RedirectToAction("Index", "Home");
                ModelState.AddModelError("", "Something went wrong");
                return RedirectToAction("Details", "Product", product);
            }
            product.comments.Add(new Comment() { Text = Comment });
            await _context.SaveChangesAsync();
            return RedirectToAction("Details", "Product", product);
        }

    }
}
