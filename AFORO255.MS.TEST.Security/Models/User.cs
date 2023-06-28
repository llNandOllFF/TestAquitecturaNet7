using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AFORO255.MS.TEST.Security.Models
{
    [Table("user",Schema ="security")]
    public class User
    {
        [Key,Column("id_user")] public long IdUser { get; set; }
        [Column("username", TypeName = "Varchar(100)")] public string UserName { get; set; } = "";
        [Column("password", TypeName = "Varchar(100)")] public string Password { get; set; } = "";
    }
}
