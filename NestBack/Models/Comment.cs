using System.ComponentModel.DataAnnotations;

namespace NestBack.Models
{
    public class Comment
    {
        public int Id { get; set; }
        [Required]
        public string Text { get; set; }
        [Required]
        public int ProductId { get; set; }
        public Product Product { get; set; }


    }
}
