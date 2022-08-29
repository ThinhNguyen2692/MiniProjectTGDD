using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
namespace DAL
{
     public class Dal_Brands
    {
        //thêm thương hiệu
        public bool DalAddBrands(ProductBrand brand)
        {
            var context = new MiniProjectTGDDContext();
            context.ProductBrands.Add(brand);

            context.SaveChanges();

            return true;
        }
        //Đọc toàn bộ dữ liệu
        public List<ProductBrand> ReadBrandsAll()
        {
            List<ProductBrand> result = new List<ProductBrand>();
            //Khong dung try catch 
            
                var context = new MiniProjectTGDDContext();
                var list = context.ProductBrands.OrderByDescending(b => b.BrandStatus).ToList();
                result.AddRange(list);
                return list;
        }

        //Xóa thương hiệu
        public string DeleteBrands(string id)
        {
            // đương đẫn xóa hình logo
            string path;
            
                var context = new MiniProjectTGDDContext();
                var data = context.ProductBrands.First(c => c.BrandId == id);
                path = data.BrandPhoto;
                context.Remove(data);
                context.SaveChanges();
           
            return path;
        }

        //lây thông tin chi tiết thương hiệu
        public ProductBrand BrandsDetail(string id)
        {
                var context = new MiniProjectTGDDContext();
                var data = context.ProductBrands.First(c => c.BrandId == id);
            return data;
        }


        //Cập nhật thông tin thương hiệu
        public bool DalUpdateBrands(ProductBrand brand)
        {
                var context = new MiniProjectTGDDContext();
                context.ProductBrands.Update(brand);
                context.SaveChanges();
            return true;
        }

        //Đọc dữ liệu thương hiệu đang kinh doanh
        public List<ProductBrand> ReadBrandsStatus()
        {
                var context = new MiniProjectTGDDContext();
                var list = context.ProductBrands.Where(b => b.BrandStatus == 1).ToList();
            return list;

        }

    }
}
