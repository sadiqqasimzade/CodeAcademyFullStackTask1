using System.ComponentModel.DataAnnotations;

namespace NestBack.ViewModels.Auth
{
    public class LoginVM
    {
        [Required]
        public string UsernameOrEmail { get; set; }
        [Required, DataType(DataType.Password)]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
    }
}
