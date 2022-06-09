
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NestBack.DAL;
using NestBack.Models;
using NestBack.Utilies;
using NestBack.Utilies.Extensions;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace NestBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    [Authorize(Roles = "Admin")]
    public class SliderController : Controller
    {
        private AppDbContext _context { get; }
        public SliderController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            List<Slider> sliderList = await _context.Sliders.ToListAsync();
            return View(sliderList);
        }
        public IActionResult Create()
        {
            return View();
        }
        public IActionResult Update(int id)
        {
            Slider slider = _context.Sliders.Find(id);
            if (slider == null) return NotFound();
            return View(slider);
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();

            if (slider == null) return BadRequest();
            if (slider.Photo == null)
            {
                ModelState.AddModelError("Photo", "Need Photo");
                return View();
            }
            if (!slider.Photo.CheckSize(Constants.SliderImgMaxSizeInKb))
            {
                ModelState.AddModelError("Photo", "File size must be less than:"+Constants.SliderImgMaxSizeInKb+"Kb");
                return View();
            }
            if (!slider.Photo.CheckType("image/"))
            {
                ModelState.AddModelError("Photo", "File must be image");
                return View();
            }
            slider.Title=slider.Title.Trim();
            slider.Desc=slider.Desc.Trim();
            slider.Img = await slider.Photo.SaveFileAsync(Constants.SliderImgPath);
            await _context.Sliders.AddAsync(slider);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Update(Slider slider)
        {
            if (!ModelState.IsValid)
                return View();
            if (slider == null) return BadRequest();
            Slider dbslider = await _context.Sliders.FindAsync(slider.Id);
            if (dbslider == null) return NotFound();
            dbslider.Title = slider.Title.Trim();
            dbslider.Desc = slider.Desc.Trim();
            if (dbslider.Photo != null)
            {
                if (System.IO.File.Exists(Path.Combine(Constants.SliderImgPath, dbslider.Img)))
                    System.IO.File.Delete(Path.Combine(Constants.SliderImgPath, dbslider.Img));
                dbslider.Img = await slider.Photo.SaveFileAsync(Constants.SliderImgPath);
            }
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete(int id)
        {
            Slider slider = await _context.Sliders.FindAsync(id);
            if (slider == null) return Json(new { status = 404 });
            if (System.IO.File.Exists(Path.Combine(Constants.SliderImgPath, slider.Img)))
                System.IO.File.Delete(Path.Combine(Constants.SliderImgPath, slider.Img));


            _context.Sliders.Remove(slider);
            _context.SaveChanges();
            return Json(new { status = 200 });
        }
    }
}
