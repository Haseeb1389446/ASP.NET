using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Template_Integration.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var con = builder.Configuration.GetConnectionString("mycon");

builder.Services.AddDbContext<AuthDbContext>(opt =>

    opt.UseSqlServer(con)

);

builder.Services.AddIdentity<IdentityUser, IdentityRole>(opt =>
    {
        opt.SignIn.RequireConfirmedEmail = false;
        opt.Password.RequireNonAlphanumeric = false;
        opt.Password.RequireLowercase = false;
        opt.Password.RequireUppercase = false;
    }
).AddEntityFrameworkStores<AuthDbContext>().AddDefaultTokenProviders();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
