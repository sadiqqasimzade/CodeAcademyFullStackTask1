using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NestBack.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required(ErrorMessage ="Must be filled"),MaxLength(150)]
        public string Name { get; set; }
        [Required,Range(0,double.MaxValue)]
        public decimal Price { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal BuyPrice { get; set; }
        [Required, Range(0, double.MaxValue)]
        public decimal DiscountPrice { get; set; }
        [Range(0,5)]
        public int Raiting { get; set; }
        [Required]
        public string Desc { get; set; }
        [Required]
        public int CategoryId { get; set; }

        public Category Category { get; set; }

        public List<ProductImg> productImgs { get; set; }
        [Required,Range(0,int.MaxValue)]
        public List<Comment> comments { get; set; }
        public int Stock { get; set; }

        public bool IsDeleted { get; set; } = false;
        [NotMapped]
        public IFormFileCollection File { get; set; }
 
  

    }
}
