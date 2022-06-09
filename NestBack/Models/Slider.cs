using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NestBack.Models
{
    public class Slider
    {
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        public string Img { get; set; }
        [Required]
        public string Desc { get; set; }
        [NotMapped]
        public IFormFile Photo { get; set; }
    }
}
