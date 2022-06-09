using Microsoft.AspNetCore.Authorization;
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
    public class CategoryController : Controller
    {

        private AppDbContext _context;

        public CategoryController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Category> categories = await _context.Categories.Include(c => c.Products).ToListAsync();
            return View(categories);
        }

        public IActionResult Create()
        {
            return View();
        }

        public async Task<IActionResult> Update(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null) return BadRequest();
            return View(category);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            Category category = _context.Categories.Find(id);
            if (category == null) return NotFound();

            if (System.IO.File.Exists(Path.Combine(Constants.CategoryImgPath, category.Logo)))
                System.IO.File.Delete(Path.Combine(Constants.CategoryImgPath, category.Logo));

            _context.Categories.Remove(category);
            _context.SaveChanges();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangeState(int id)
        {
            Category category = await _context.Categories.FindAsync(id);
            if (category == null) return NotFound();
            category.IsDeleted = !category.IsDeleted;
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Category category)
        {
            if (!ModelState.IsValid)
                return View();
  
            Category dbcat = await _context.Categories.FindAsync(category.Id);
            if (dbcat == null) return BadRequest();
            if (_context.Categories.FirstOrDefault(c => (c.Name.Trim() == category.Name.Trim()) && (c.Id != category.Id)) != null)
            {
                ModelState.AddModelError("Name", "Category with this name exist");
                return RedirectToAction(nameof(Update));
            }
            dbcat.Name = category.Name.Trim();
            if (category.File != null)
            {
                if (System.IO.File.Exists(Path.Combine(Constants.CategoryImgPath, dbcat.Logo)))
                    System.IO.File.Delete(Path.Combine(Constants.CategoryImgPath, dbcat.Logo));

                string filename = Guid.NewGuid().ToString() + category.File.FileName;
                if (filename.Length > Constants.CategoryNameMaxLength)
                    filename = filename.Substring(filename.Length - Constants.CategoryNameMaxLength, Constants.CategoryNameMaxLength);
                using (FileStream fs = new FileStream(Path.Combine(Constants.CategoryImgPath, filename), FileMode.Create))
                    await category.File.CopyToAsync(fs);
                
                dbcat.Logo = filename;
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Category category)
        {
            if (!ModelState.IsValid)
                return View();
            
            if (category == null) return BadRequest();
            if (await _context.Categories.FirstOrDefaultAsync(c => c.Name.Trim() == category.Name.Trim()) != null)
            {
                ModelState.AddModelError("Name", "Category with this name exist");
                return View();
            }
            if (category.File == null)
            {
                ModelState.AddModelError("File", "Need Photo");
                return View();
            }
            if (!category.File.CheckSize(Constants.CategoryImgMaxSizeInKb))
            {
                ModelState.AddModelError("File", "Size cant be greater than:" + Constants.CategoryImgMaxSizeInKb + "Kb");
                return View();
            }
            if (!category.File.CheckType("image/"))
            {
                ModelState.AddModelError("File", "Wrong Type");
                return View();
            }
            string filename = Guid.NewGuid().ToString() + category.File.FileName;
            if (filename.Length > Constants.CategoryNameMaxLength)
                filename = filename.Substring(filename.Length - Constants.CategoryNameMaxLength, Constants.CategoryNameMaxLength);

            using (FileStream fs = new FileStream(Path.Combine(Constants.CategoryImgPath, filename), FileMode.Create))
                await category.File.CopyToAsync(fs);
            category.Name=category.Name.Trim();
            category.Logo = filename;
            await _context.Categories.AddAsync(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
    }
}
