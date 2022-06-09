using System.ComponentModel.DataAnnotations;

namespace NestBack.ViewModels.Auth
{
    public class ChangePassVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        [Required, DataType(DataType.Password)]
        public string ChangedPassword { get; set; }
    }
}
