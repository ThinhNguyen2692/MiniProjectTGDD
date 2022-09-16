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
        public bool DalRemoveBrand(string id);
        public List<ProductBrand> DalGetBrand();
        public ProductBrand GetBrandById(string id);
        public bool DalUpdateBrands(ProductBrand name);
        public List<ProductBrand> DalGetbrandsByStatus();
        public bool CheckProduct(string BrandsId);
    }
    public class Dal_Brands : IDalBrands
    {
        private MiniProjectTGDDContext context;
        public Dal_Brands(MiniProjectTGDDContext context)
        {
            this.context = context;
        }

        

        /// <summary>
        /// Thêm thương hiệu mới
        /// </summary>
        /// <param name="brand">thông tin thương hiệu</param>
        /// <returns>false: thêm không thành công</returns>
        /// <returns>true: thêm thành công</returns>
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

        /// <summary>
        /// Đọc thông tin thương hiệu
        /// </summary>
        /// <returns>danh sách thông tin các thương hiệu</returns>
        public List<ProductBrand> DalGetBrand()
        {
            List<ProductBrand> result = new List<ProductBrand>();
            //Khong dung try catch 
            var list = context.ProductBrands.OrderByDescending(b => b.BrandStatus);
            if(list != null) result.AddRange(list.ToList());
            return result;
        }


        //Xóa thương hiệu
        public bool DalRemoveBrand(string id)
        {
            var data = GetBrandById(id);
            if (data != null)
            {
                context.Remove(data);
                context.SaveChanges();
            }
            else
            {
                return false;
            }
            return true;
        }

        //lây thông tin chi tiết thương hiệu
        public ProductBrand? GetBrandById(string id)
        {
            var data = context.ProductBrands.Where(c => c.BrandId == id).FirstOrDefault();
            if(data == null) { return null; }
            return data;
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
