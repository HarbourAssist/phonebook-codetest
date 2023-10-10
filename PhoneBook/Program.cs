using Microsoft.EntityFrameworkCore;
using PhoneBook.Models;
using PhoneBook.Repositories;
using PhoneBook.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

builder.Services.AddDbContext<PhoneBookContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("SysConfigContext"));
});

builder.Services.AddScoped<IPhoneBookRepository, PhoneBookRepository>();
builder.Services.AddScoped<IPhoneBookService, PhoneBookService>();

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

app.MapControllers();

app.MapFallbackToFile("index.html");

app.Run();
