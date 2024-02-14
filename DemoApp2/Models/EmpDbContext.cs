global using Microsoft.EntityFrameworkCore;

namespace DemoApp.Models;

public class EmpDbContext : DbContext
{
    public DbSet<Employee> Employees { get; set; }

    public DbSet<Department> Departments { get; set; }

    public DbSet<Admin> Admins { get; set; }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlServer("Data Source=iitdac.met.edu;Database=Shop6;User ID=dac6;Password=Dac6@1234;Encrypt=False");
    }
    
}