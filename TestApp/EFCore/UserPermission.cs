using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.EFCore
{
    [Table("userpermission")]
    public class UserPermission
    {
        public int UserId { get; set; } 
        public virtual User? Users { get; set; }
        public int PermissionId { get; set; }   
        public virtual Permission? Permissions { get; set; }
    }
}
