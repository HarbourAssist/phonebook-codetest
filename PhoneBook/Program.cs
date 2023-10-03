using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Repositories;
using PhoneBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<PhoneBookContext>(options =>
{
    options.UseSqlServer("Server=.\\SQLExpress;Database=PhoneBook;Trusted_Connection=True;TrustServerCertificate=true");
});

builder.Services.AddTransient<IPhoneBookRepository, PhoneBookRepository>();
builder.Services.AddTransient<IPhoneBookService, PhoneBookService>();

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

app.MapControllerRoute(
    name: "default",
    pattern: "{controller}/{action=Index}/{id?}");

app.MapFallbackToFile("index.html");

app.Run();

public partial class Program { }