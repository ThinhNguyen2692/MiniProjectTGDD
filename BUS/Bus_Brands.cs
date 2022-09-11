using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;
namespace BUS
{
    public interface IBrands
    {
        public bool AddBrands(ProductBrand productBrand);
        public List<ProductBrand> GetProductBrands();
        public ProductBrand GetBrandById(string id);
        public string? RemoveBrand(string brandsId);
        public bool UpdateBrands(ProductBrand productBrand);
        public List<ProductBrand> DalGetbrandsByStatus();
        public bool CheckProduct(string BrandsId);

    }
     public class Bus_Brands:IBrands
    {


        private static IDalBrands iDalBrands;
       
        public Bus_Brands(IDalBrands dalBrands) { iDalBrands = dalBrands; }

        public bool AddBrands(ProductBrand productBrand)
        {   
            return iDalBrands.DalAddBrand(productBrand);
        }

        public List<ProductBrand> GetProductBrands()
        {
            return iDalBrands.DalGetBrand();
        }
        public string? RemoveBrand(string brandsId)
        {
            if(iDalBrands.CheckProduct(brandsId) == false)
            {
                return null;
            }
            return iDalBrands.DalRemoveBrand(brandsId);
        }

        public ProductBrand GetBrandById(string id)
        {
            return iDalBrands.GetBrandById(id);
        }

        public bool UpdateBrands(ProductBrand productBrand)
        {
            return iDalBrands.DalUpdateBrands(productBrand);
        }

        //Đọc dữ liệu thương hiệu đang kinh doanh
        public List<ProductBrand> DalGetbrandsByStatus()
        {
            return iDalBrands.DalGetbrandsByStatus();
        }

        public bool CheckProduct(string BrandsId)
        {
            return iDalBrands.CheckProduct(BrandsId);
        }

    }
}
