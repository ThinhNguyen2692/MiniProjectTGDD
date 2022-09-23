using DAL;
using ModelProject.Models;
using BUS;
using BUS.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddSession();

builder.Services.AddMvc();

builder.Services.AddSingleton<MiniProjectTGDDContext>();

//ProductBrands
builder.Services.AddSingleton<IDalBrands, Dal_Brands>();
builder.Services.AddSingleton<IBusBands, BusBrands>();

//productType
builder.Services.AddSingleton<IDaltype, Dal_ProductType>();
builder.Services.AddSingleton<IBusProductType, BusProductType>();
//Typecontronller
builder.Services.AddSingleton<IDalProductPecification, Dal_ProductPecification>();

builder.Services.AddSingleton<IDalInformationProperties, Dal_InformationProperties>();


//Customer
builder.Services.AddSingleton<IBusCustomer, Bus_Customer>();
builder.Services.AddSingleton<IDalCustomer, Dal_Customer>();
//Gift
builder.Services.AddSingleton<IBus_Gift, Bus_Gift>();
builder.Services.AddSingleton<IDal_Gift, Dal_Gift>();


//product
builder.Services.AddSingleton<IDAlProduct, Dal_Product>();
builder.Services.AddSingleton<IBusProduct, BusProduct>();
builder.Services.AddSingleton<IDalProductVersion, Dal_ProductVersion>();
builder.Services.AddSingleton<IDalPropertyValue, Dal_PropertyValue>();
builder.Services.AddSingleton<IDalPhoto, Dal_Photo>();



builder.Services.AddSingleton<IBusPhoto, Busphoto>();
builder.Services.AddSingleton<IDalProductPhoto, Dal_productphotos>();


//colorproduct
builder.Services.AddSingleton<IDalProductColor, Dal_ProductColor>();

//PurchaseOrderController
builder.Services.AddSingleton<IDalPurchaseOrder, DalPurchaseOrder>();
builder.Services.AddSingleton<IBusPurchaseOrder, BusPurchaseOrder>();



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
