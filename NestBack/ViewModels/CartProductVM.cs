using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NestBack.ViewModels
{
    public class CartProductVM
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Img { get; set; }
        public int Raiting { get; set; }
        public decimal  Price { get; set; }
        public bool IsAbailable { get; set; }
        public int Count { get; set; }

    }
}
