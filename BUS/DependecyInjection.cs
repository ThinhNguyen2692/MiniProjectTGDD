using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.DataModel;
using BUS.Services;
using ModelProject.Models;

namespace BUS
{
    public static class DependecyInjection
    {
        public static IServiceCollection serviceDescriptors(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IDalBrands, Dal_Brands>();
            services.AddSingleton<IDaltype, Dal_ProductType>();
            services.AddSingleton<IDalProductPecification, Dal_ProductPecification>();
            services.AddSingleton<IDalInformationProperties, Dal_InformationProperties>();
            services.AddSingleton<IDalCustomer, Dal_Customer>();
            services.AddSingleton<IDAlProduct, Dal_Product>();
            services.AddSingleton<IDal_Gift, Dal_Gift>();
            services.AddSingleton<IDalPhoto, Dal_Photo>();
            services.AddSingleton<IDalProductVersion, Dal_ProductVersion>();
            services.AddSingleton<IDalPropertyValue, Dal_PropertyValue>();
            services.AddSingleton<IDalProductPhoto, Dal_productphotos>();
            services.AddSingleton<IDalProductColor, Dal_ProductColor>();
            services.AddSingleton<IDalPurchaseOrder, DalPurchaseOrder>();
            services.AddSingleton<IDalVersionQuantity, Dal_VersionQuantity>();
            services.AddSingleton<IDAlUser, DalUser>();
            services.AddSingleton<IDalEvent, DalEvent>();

            services.AddSingleton<IBusShowProducts, BusShowProducts>();
            services.AddSingleton<IBusBands, BusBrands>();
            services.AddSingleton<IBusProductType, BusProductType>();
            services.AddSingleton<IBusCustomer, Bus_Customer>();
            services.AddSingleton<IBusPromotion, BusPromotion>();
            services.AddSingleton<IBusProduct, BusProduct>();
            services.AddSingleton<IBusPhoto, Busphoto>();
            services.AddSingleton<IBusPurchaseOrder, BusPurchaseOrder>();
            services.AddSingleton<IBusUser, BusUser>();
            services.AddSingleton<IBusStatistical, BusStatistical>();
            services.AddSingleton<IUnitOfWork, UnitOfWork>();
            return services;
        }
    }
}
