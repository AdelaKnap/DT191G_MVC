var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();   // Aktivera MVC
builder.Services.AddSession();               // Lägg till session

var app = builder.Build();

app.UseSession();       // Använd session
app.UseStaticFiles();   // Statiska filer i wwwroot
app.UseRouting();

// Routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}"
);

app.Run();
