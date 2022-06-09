using NestBack.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Http;
using System.Threading.Tasks;
using NestBack.ViewModels;
using Newtonsoft.Json;
using NestBack.Models;
using Microsoft.EntityFrameworkCore;

namespace NestBack.Services
{
    public class LayoutServices
    {
        private AppDbContext _context { get; }
        private IHttpContextAccessor _accessor { get; }
        public LayoutServices(AppDbContext context,IHttpContextAccessor accessor)
        {
            _context = context;
            _accessor = accessor;
        }
        public Dictionary<string,string> GetSettings()
        {
           return _context.Settings.ToDictionary(p => p.Key, p => p.Value);
        }
            
        public List<CartProductVM> GetBasket()
        {
            List<CartProductVM> basket = new List<CartProductVM>();
            if (_accessor.HttpContext.Request.Cookies["Basket"] == null) return basket;
            List<BasketVM> basketVMs = JsonConvert.DeserializeObject<List<BasketVM>>(_accessor.HttpContext.Request.Cookies["Basket"]);
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
                basket.Add(cartitem);
            }
            return basket;
        }
    }
}
