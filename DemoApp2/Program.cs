var builder = WebApplication.CreateBuilder(args); // allow to web application
builder.Services.AddControllersWithViews();       // add controller with views
builder.Services.AddAuthentication()
    .AddCookie(option => option.LoginPath = "/Index");
builder.Services.AddDbContext<DemoApp.Models.EmpDbContext>();  // to know where is our class and db

var app = builder.Build(); 

app.UseAuthentication();
app.UseAuthorization();
app.MapDefaultControllerRoute();  
app.Run();
