using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Repository;
using static System.Net.Mime.MediaTypeNames;

var builder = WebApplication.CreateBuilder(args);
var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PhoneBookContext>(options =>
{
    options.UseSqlServer("Server=localhost\\MSSQLSERVER04;Database=PhoneBook;Trusted_Connection=True;TrustServerCertificate=true");
});

// Add Cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("angularApplication", (builder) =>
    {
        builder
        .WithOrigins("http://localhost:44425") // specifying the allowed origin
        .WithMethods("GET", "POST", "PUT", "DELETE") // defining the allowed HTTP method
        .AllowAnyHeader(); // allowing any header to be sent
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}


app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();

app.UseCors(MyAllowSpecificOrigins);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapControllerRoute(
	name: "apidefault",
	pattern: "api/{controller=Home}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();
