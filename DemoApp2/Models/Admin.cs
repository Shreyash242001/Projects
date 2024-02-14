using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Models;

[Table("Admin")]
public class Admin
{
   [Key]
    public string Username { get; set; }

    public string Password { get; set; }
}
