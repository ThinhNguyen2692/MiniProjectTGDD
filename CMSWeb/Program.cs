using DAL;
using DAL.Models;
using BUS;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddMvc();

builder.Services.AddSingleton<MiniProjectTGDDContext>();

//ProductBrands
builder.Services.AddSingleton<IDalBrands, Dal_Brands>();
builder.Services.AddSingleton<IBrands, Bus_Brands>();

//productType
builder.Services.AddSingleton<IDaltype, Dal_ProductType>();
builder.Services.AddSingleton<IBusProductType, Bus_ProductType>();
//Typecontronller
builder.Services.AddSingleton<IDalProductPecification, Dal_ProductPecification>();
builder.Services.AddSingleton<IBusProductPecification, Bus_ProductPecification>();
builder.Services.AddSingleton<IDalInformationProperties, Dal_InformationProperties>();
builder.Services.AddSingleton<IBusInformationProperties, Bus_InformationProperties>();



builder.Services.AddSingleton<IDAlProduct, Dal_Product>();
builder.Services.AddSingleton<IDalVersionQuantity, Dal_VersionQuantity>();
builder.Services.AddSingleton<IDalVersionQuantity, Dal_VersionQuantity>();



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
app.UseSession();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
