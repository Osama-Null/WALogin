using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WALogin.Models
{
    public class User
    {
        [DisplayName("ID")]
        public int Id { get; set; }
        [DisplayName("Name")]
        public string Name { get; set; }
        [DisplayName("Email Address")]
        [EmailAddress(ErrorMessage ="*Write your email address")]
        [Range(4, 12, ErrorMessage = "*Out of range [4-12]")]
        public string Email { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }

        // ------------------- Join Usr & Role
        [DisplayName("Role ID")]
        [ForeignKey("Role")]
        public int RoleId { get; set; }
        public Role? Role { get; set; }
    }
}