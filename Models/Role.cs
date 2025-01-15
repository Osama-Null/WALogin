using System.ComponentModel;

namespace WALogin.Models
{
    public class Role
    {
        [DisplayName("ID")]
        public int RoleId { get; set; }
        [DisplayName("Role Name")]
        public string Name { get; set; }
    }
}
