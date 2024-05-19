using Microsoft.EntityFrameworkCore;
using SportsStore.Models;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllersWithViews();

builder.Services.AddSingleton<Cart>(); 

builder.Services.AddDbContext<StoreDBContext>(opts => {
    opts.UseSqlServer(
        builder.Configuration["ConnectionStrings:SportsStoreConnection"]);
});

builder.Services.AddScoped<IStoreRepository, EFStoreRepository>();

builder.Services.AddRazorPages();
builder.Services.AddDistributedMemoryCache();
builder.Services.AddSession();

var app = builder.Build();

// Serve static files
app.UseStaticFiles();
app.UseSession();

// Route for category with page
app.MapControllerRoute(
    name: "catpage",
    pattern: "{category}/Page{productPage:int}",
    defaults: new { Controller = "Home", action = "Index" });

// Route for just page
app.MapControllerRoute(
    name: "page",
    pattern: "Page{productPage:int}",
    defaults: new { Controller = "Home", action = "Index", productPage = 1 });

// Route for just category
app.MapControllerRoute(
    name: "category",
    pattern: "{category}",
    defaults: new { Controller = "Home", action = "Index", productPage = 1 });

// Fallback route
app.MapControllerRoute(
    name: "pagination",
    pattern: "Products/Page{productPage}",
    defaults: new { Controller = "Home", action = "Index", productPage = 1 });

// Default route
app.MapDefaultControllerRoute();
app.MapRazorPages();

// Seed database
SeedData.EnsurePopulated(app);

app.Run();
