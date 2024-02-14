using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Models;

[Table("Employee_33")]
public class Employee
{
    
    [Column("eid")]
    public string Id { get; set; }
    public string ename { get; set; }
     [MaxLength(7, ErrorMessage = "Hatt Bhadave Awakat Se Jada Dalra")]
    public string sal { get; set; }
    
    public string age { get; set; }

    public string DeptId {get; set;}

   
}
