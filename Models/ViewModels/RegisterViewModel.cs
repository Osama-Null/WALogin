using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace WALogin.Models.ViewModels
{
    public class RegisterViewModel
    {
        public int Id { get; set; }
        [DisplayName("Name")]
        [Required(ErrorMessage = "*Enter name")]
        [MinLength(3)]
        public string Name { get; set; }
        [DisplayName("Email")]
        [Required(ErrorMessage = "*Enter email")]
        [EmailAddress]
        public string Email { get; set; }
        [DisplayName("Confirm email")]
        [EmailAddress]
        [Compare("Email", ErrorMessage = "*Email not match")]
        public string ConfirmEmail { get; set; }
        [DisplayName("Password")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("Confirm password")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "*Password not match")]
        public string ConfirmPassword { get; set; }

        //---------------- FK
        [DisplayName("Role")]
        [Required(ErrorMessage = "*Please select a role.")]
        [Range(1, int.MaxValue, ErrorMessage = "*Please select a valid role.")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}
