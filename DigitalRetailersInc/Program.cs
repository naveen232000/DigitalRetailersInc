using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using DigitalRetailersInc.Data;
using Microsoft.AspNetCore.Identity;
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<DigitalRetailersIncContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DigitalRetailersIncContext") ?? throw new InvalidOperationException("Connection string 'DigitalRetailersIncContext' not found.")));

builder.Services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
    .AddEntityFrameworkStores<DigitalRetailersIncContext>();

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
}
app.UseWebSockets();

app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();;
app.MapRazorPages();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
