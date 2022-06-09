using System.ComponentModel.DataAnnotations;

namespace NestBack.ViewModels.Auth
{
	public class RegisterVM
	{
		[Required,MaxLength(50)]
		public string FirstName { get; set; }
		[Required,MaxLength(50)]
		public string LastName { get; set; }
		[Required,MaxLength(50)]
		public string UserName { get; set; }
		[Required,DataType(DataType.EmailAddress)]
		public string Email { get; set; }
		[Required,DataType(DataType.Password)]
		public string Password { get; set; }
		[Required,Compare(nameof(Password))]
		public string ConfirmPass { get; set; }
	}
}
