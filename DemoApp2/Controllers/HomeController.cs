using System.Security.Claims;
using DemoApp.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;

namespace DemoApp.Controllers;

public class HomeController : Controller
//---------------------------------------------------log in-------------------------------------------------------------------
{   public IActionResult Index()
    {
        return View(new Admin());
    }
    [HttpPost]
    public async Task<IActionResult> Index([FromServices] EmpDbContext site ,Admin Input)
    {
        if(ModelState.IsValid)
        {
        var customer = await site.Admins.FindAsync(Input.Username);
        if(customer?.Password == Input.Password)
        {
            var identity = new ClaimsIdentity("Admin");
            identity.AddClaim(new Claim(ClaimTypes.NameIdentifier, Input.Username));
            await HttpContext.SignInAsync(new ClaimsPrincipal(identity));
            return RedirectToAction("Display2");
        }
        }
        ModelState.AddModelError("Login", "Invalid Admin ID or Password");
        
        return RedirectToAction("Index");
    }
//---------------------------------------------------------display--------------------------------------------------------------------
    [Authorize]
    [ResponseCache(NoStore = true)]
    public IActionResult Display2([FromServices] EmpDbContext site) 
    {
        return View(new Admin());
    }

    public IActionResult Options([FromServices] EmpDbContext site)
    {
        return View();
    }
    public IActionResult Options2([FromServices] EmpDbContext site)
    {
        return View();
    }
//----------------------------------------------------employee--------------------------------------------------------------------------  
    public IActionResult RegisterE([FromServices] EmpDbContext site) 
    {
        var selection = from emp in site.Employees
                        select new EmpInfo 
                        {
                            EId = emp.Id,
                            EName = emp.ename,
                            ESalary = emp.sal,
                            EAge = emp.age,
                            DeptId = emp.DeptId
                        };
        return View(selection.ToList()); 
    }

    public IActionResult AddE()
    {
        return View(new Employee());
    }

    [HttpPost]
    public IActionResult AddE([FromServices] EmpDbContext site, Employee input)
    {
       
            site.Employees.Add(input);
            //emp.Employeess.Add(new Employee());
            site.SaveChanges();
            return RedirectToAction("RegisterE");
       
    }


    public IActionResult Delete()
    {
        return View(new Employee());
    }

    [HttpPost]
    public IActionResult Delete([FromServices] EmpDbContext site, Employee input)
    {
        if(ModelState.IsValid)
        {
       
            site.Employees.Remove(input);
            //emp.Employeess.Add(new Employee());
            site.SaveChanges();
            return RedirectToAction("RegisterE");
        }
        return Delete();
  
    }

    public IActionResult Update()
    {
        return View(new Employee());
    }

    [HttpPost]
    public IActionResult Update([FromServices] EmpDbContext site, Employee input)
    {
       
            // var emp1 = site.Employees.Find(u => u.Id == input.Id);
            // emp1.sal = input.sal;

            var emp = site.Employees.First(u => u.Id == input.Id);
            emp.sal=input.sal;
    
            site.SaveChanges();
            return RedirectToAction("RegisterE");
            //return NotFound();
       
    }


   
//---------------------------------------------log out----------------------------------------------------------------------------------
   
   public async Task<IActionResult> LogOut()
   {
     await HttpContext.SignOutAsync();   
     return RedirectToAction("Index");
   }

   //-------------------------------------------------department---------------------------------------------------------------

            
     public IActionResult Department([FromServices] EmpDbContext site) 
    {
        var selection = from dept in site.Departments
                        select new DeptInfo 
                        {
                            Deptno = dept.deptno,
                            DName = dept.dname,
                            DLocation = dept.loc,
                            
                        };
        return View(selection.ToList()); 
    }
   public IActionResult AddD()
    {
        return View(new Department());
    }

    [HttpPost]
    public IActionResult AddD([FromServices] EmpDbContext site, Department input)
    {
       
            site.Departments.Add(input);
            //emp.Employeess.Add(new Employee());
            site.SaveChanges();
            return RedirectToAction("Department");
       
    }

    public IActionResult DeleteD()
    {
        return View(new Department());
    }

    [HttpPost]
    public IActionResult DeleteD([FromServices] EmpDbContext site, Department input)
    {
        if(ModelState.IsValid)
        {
       
            site.Departments.Remove(input);
            //emp.Employeess.Add(new Employee());
            site.SaveChanges();
            return RedirectToAction("Department");
        }
        return DeleteD();
  
    }
    public IActionResult UpdateD()
    {
        return View(new Department());
    }

    [HttpPost]
    public IActionResult UpdateD([FromServices] EmpDbContext site, Department input)
    {
       
            // var emp1 = site.Employees.Find(u => u.Id == input.Id);
            // emp1.sal = input.sal;

            var emp = site.Departments.First(u => u.deptno == input.deptno);
            emp.loc=input.loc;
    
            site.SaveChanges();
            return RedirectToAction("Department");
            //return NotFound();
       
    }
}


