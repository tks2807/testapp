using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.EFCore
{
    [Table("permission")]
    public class Permission
    {
        [Key, Required]
        public int Id { get; set; }
        public int Code { get; set; }
        public string Description { get; set; }
        public List<UserPermission>? UserPermissions { get; set; }

    }
}
