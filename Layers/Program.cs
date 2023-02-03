using Layers.Models;
using Layers.Reposiotries;
using Layers.ServiceLifeTime;
using Layers.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();


builder.Services.AddDbContext<CompanyDBContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("myCS"));
});

builder.Services.AddScoped<IEmployeeRepo, EmployeeRepo>();
builder.Services.AddScoped<IEmployeeService, EmployeeService>();


builder.Services.AddScoped<IScopedService,ScopedService>();
builder.Services.AddTransient<ItransiantService,transiantService>();
builder.Services.AddSingleton<ISingletonService,SingletonService>();



var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
