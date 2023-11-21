
using Microsoft.EntityFrameworkCore;
using ProniaWebApplication.DAL;

var builder = WebApplication.CreateBuilder(args);

           
  builder.Services.AddControllersWithViews();

  var app = builder.Build();

          
           
    app.UseStaticFiles();
    builder.Services.AddDbContext<AppDbContext>(opt =>
{
    opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
});
         

app.MapControllerRoute
(
    name: "default",
    pattern: "{controller=home}/{action=I]index}/{id?}"
    
);


app.Run();
 