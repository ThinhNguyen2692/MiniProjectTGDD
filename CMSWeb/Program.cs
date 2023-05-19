using BUS;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.Extensions.Options;
using ModelProject.Models;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();
builder.Services.AddMvc();
Setting.ConnectionStrings = builder.Configuration.GetConnectionString("MiniProjectTGDD");
builder.Services.serviceDescriptors(builder.Configuration);
builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
    .AddCookie(m => {
        m.LoginPath = "/login/index";
        m.ExpireTimeSpan = TimeSpan.FromSeconds(300);
    });


var app = builder.Build();
var cookiePolicyOptions = new CookiePolicyOptions
{
    MinimumSameSitePolicy = SameSiteMode.Strict
};
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseSession();
app.UseCookiePolicy(cookiePolicyOptions);
app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();
app.MapRazorPages();
app.MapDefaultControllerRoute();
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");
app.Run();
