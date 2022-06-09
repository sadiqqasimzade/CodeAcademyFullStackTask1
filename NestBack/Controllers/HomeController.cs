using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using NestBack.DAL;
using NestBack.Models;
using NestBack.ViewModels;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;

namespace NestBack.Controllers
{
    public class HomeController : Controller
    {
        private AppDbContext _context { get; }
        public HomeController(AppDbContext dbContext)
        {
            _context = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            HomeVM homeVM = new HomeVM()
            {
                Sliders = await _context.Sliders.ToListAsync(),
                Products = await _context.Products.Include(p => p.productImgs).Include(p => p.Category).Where(p => p.IsDeleted == false).Take(10).ToListAsync(),
                Categories = await _context.Categories.ToListAsync(),
                RecentProducts = await _context.Products.OrderByDescending(p => p.Id).Take(3).Include(p => p.productImgs).Include(p => p.Category).ToListAsync(),
                TopRatedProducts = await _context.Products.OrderByDescending(p => p.Raiting).Take(3).Include(p => p.productImgs).Include(p => p.Category).ToListAsync()
            };
            return View(homeVM);
        }


    }
}
