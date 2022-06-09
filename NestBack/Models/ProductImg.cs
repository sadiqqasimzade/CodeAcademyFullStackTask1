using System.Collections.Generic;

namespace NestBack.Models
{
    public class ProductImg
    {
        public int Id { get; set; }
        public string Img { get; set; } = "Default";
        public bool IsFront { get; set; }
        public int ProductId { get; set; }
        public Product Product { get; set; }

 
    }
}
