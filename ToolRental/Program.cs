using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using ToolRental.Data;
using ToolRental.Repositories;
using ToolRental.Repositories.Interfaces;
using ToolRental.Services;
using ToolRental.Services.Interfaces;
var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddDbContext<ToolRentalContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("ToolRentalContext") ?? throw new InvalidOperationException("Connection string 'ToolRentalContext' not found.")));

builder.Services.AddScoped<IToolService, ToolService>();
builder.Services.AddScoped<IReservationService, ReservationService>();
builder.Services.AddScoped<UserService>();

builder.Services.AddScoped<IToolRepository, ToolRepository>();
builder.Services.AddScoped<IReservationRepository, ReservationRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapRazorPages();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}");

app.Run();
