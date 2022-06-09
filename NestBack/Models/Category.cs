using Microsoft.AspNetCore.Http;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NestBack.Models
{
    public class Category
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Logo { get; set; }
        public List<Product> Products { get; set; }

        public bool IsDeleted { get; set; } = false;

        [NotMapped]
        public IFormFile File { get; set; }
    }
}
