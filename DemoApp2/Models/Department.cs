using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DemoApp.Models;
[Table("Dept_33")]
public class Department
{
    [Key]
    public string deptno {get; set;}

    public string dname {get; set;}
    public string loc {get; set;}
    public List<Employee>Employees = new();
}