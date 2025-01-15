using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WALogin.Models.ViewModels
{
    public class LoginViewModel
    {
        [DisplayName("Email")]
        [Required(ErrorMessage = "*Enter email")]
        [EmailAddress]
        public string Email { get; set; }

        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
