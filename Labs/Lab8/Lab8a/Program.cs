using Lab8a.Database;
using Lab8a.Services;
using Lab8a.Services.Abstractions;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddScoped<IPhoneService, PhoneService>();

var connectionString = builder.Configuration.GetConnectionString("Lab8a");
builder.Services.AddDbContext<Lab8aContext>(options => 
    options.UseSqlServer(connectionString));

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Dist/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Dist}/{action=Index}/{id?}");

app.Run();
