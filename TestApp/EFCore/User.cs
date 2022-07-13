using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TestApp.EFCore
{
    [Table("user")]
    public class User
    {
        [Key, Required]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Login { get; set; }
        [DataType(DataType.Text)]
        public string Name { get; set; }
        [EmailAddress]
        public string Email { get; set; }   
        public List<UserPermission>? UserPermissions { get; set; }
    }
}
