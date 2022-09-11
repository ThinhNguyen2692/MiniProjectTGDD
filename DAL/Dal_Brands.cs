using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL
{
    public interface IDalBrands
    {
        public bool DalAddBrand(ProductBrand productBrand);
        public string DalRemoveBrand(string id);
        public List<ProductBrand> DalGetBrand();
        public ProductBrand GetBrandById(string id);
        public bool DalUpdateBrands(ProductBrand name);
        public List<ProductBrand> DalGetbrandsByStatus();
        public bool CheckProduct(string BrandsId);
    }
    public class Dal_Brands : IDalBrands
    {
        public MiniProjectTGDDContext context;
        public Dal_Brands(MiniProjectTGDDContext context)
        {
            this.context = context;
        }

        

        //thêm thương hiệu
        public bool DalAddBrand(ProductBrand brand)
        {
            if (GetBrandById(brand.BrandId) == null)
            {

                context.ProductBrands.Add(brand);
                context.SaveChanges();
            }
            else
            {
                return false;
            }

            return true;
        }
        //Đọc toàn bộ dữ liệu
        public List<ProductBrand> DalGetBrand()
        {
          
            List<ProductBrand> result = new List<ProductBrand>();
            //Khong dung try catch 

           
            var list = context.ProductBrands.OrderByDescending(b => b.BrandStatus).ToList();
            result.AddRange(list);
            return list;
        }

        //Xóa thương hiệu
        public string DalRemoveBrand(string id)
        {
            // đương đẫn xóa hình logo
            string path = null;
            var data = context.ProductBrands.FirstOrDefault(c => c.BrandId == id);
            if (data != null)
            {
                path = data.BrandPhoto;
                context.Remove(data);
                context.SaveChanges();
            }
               
            return path;
        }

        //lây thông tin chi tiết thương hiệu
        public ProductBrand GetBrandById(string id)
        {
                return context.ProductBrands.First(c => c.BrandId == id);
        }


        //Cập nhật thông tin thương hiệu
        public bool DalUpdateBrands(ProductBrand brand)
        {
            context = new MiniProjectTGDDContext();
            context.ProductBrands.Update(brand);
            context.SaveChanges();
            return true;
        }

        //Đọc dữ liệu thương hiệu đang kinh doanh
        public List<ProductBrand> DalGetbrandsByStatus()
        {
            
            var list = context.ProductBrands.Where(b => b.BrandStatus == 1).ToList();
            return list;

        }

        //kiểm tra sản phẩm thương hiệu
        public bool CheckProduct(string BrandsId)
        {
            var list = context.Products.Where(b => b.ProductBrand == BrandsId).ToList();
            if(list.Count == 0) { return true; }
            return false;
        }


    }
}
