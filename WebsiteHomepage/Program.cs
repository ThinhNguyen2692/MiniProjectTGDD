using BUS;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ModelProject.Models;
using ModelProject.VNPay;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddCors(options =>
{
    options.AddPolicy(name: "MyPolicy",
        policy =>
        {
            policy.AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin();
        });
});
builder.Services.AddMemoryCache();

// Add services to the container.
builder.Services.AddControllersWithViews();
Setting.ConnectionStrings = builder.Configuration.GetConnectionString("MiniProjectTGDD");
builder.Services.Configure<VNPaySettingModel>(builder.Configuration.GetSection(nameof(VNPaySettingModel)));
builder.Services.AddSingleton<VNPaySettingModel>();
builder.Services.serviceDescriptors(builder.Configuration);
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseForwardedHeaders();
app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseCors("MyPolicy");
app.UseAuthorization();

//app.MapControllerRoute(
//    name: "Home",
//    pattern: ""
//);

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
