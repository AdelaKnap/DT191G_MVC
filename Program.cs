var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();   // Aktivera MVC
var app = builder.Build();

app.UseStaticFiles();   // Statiska filer i wwwroot
app.UseRouting();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
