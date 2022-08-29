using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
namespace BUS
{
     public class Bus_Brands
    {
        Dal_Brands dal_Brands = new DAL.Dal_Brands();
        public bool BusAddBrands(string brandsId, string brandsName, string photo, string brandsDescripton, int status)
        {
            ProductBrand brand = new ProductBrand(brandsId, brandsName, photo, brandsDescripton, status);
            
            return dal_Brands.DalAddBrands(brand);
        }

        public List<ProductBrand> ReadBrandsAll()
        {
            return dal_Brands.ReadBrandsAll();
        }
        public string DeleteBrands(string brandsId)
        {
            return dal_Brands.DeleteBrands(brandsId);
        }

        public ProductBrand BrandsDetail(string id)
        {
            return dal_Brands.BrandsDetail(id);
        }

        public bool BusUpdateBrands(string brandsId, string brandsName, string photo, string brandsDescripton, int status)
        {
            ProductBrand brand = new ProductBrand(brandsId, brandsName, photo, brandsDescripton, status);

            return dal_Brands.DalUpdateBrands(brand);
        }

        //Đọc dữ liệu thương hiệu đang kinh doanh
        public List<ProductBrand> ReadBrandsStatus()
        {
            return dal_Brands.ReadBrandsStatus();
        }
    }
}
