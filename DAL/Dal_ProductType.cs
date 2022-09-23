using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using Microsoft.EntityFrameworkCore;

namespace DAL
{
    public interface IDaltype
    {
       bool DalAddType(ProductType type);
        bool DalUpdateType(ProductType type);
        ProductType ReadType(string id);
        List<ProductType> ReadTypes();
        public void deletetype(string typeid);
        public bool CheckProductByTypeId(string typeId);

    }
    public class Dal_ProductType:IDaltype
    {

        private MiniProjectTGDDContext context;

        public Dal_ProductType(MiniProjectTGDDContext context)
        {
            this.context = context;
        }


        //Thêm ngành hàng
        public bool DalAddType(ProductType type)
        {
            

            if (ReadType(type.Typeid) != null)
            {
                return false;
            }
            context.ProductTypes.Add(type);
                context.SaveChanges();
            return true;
        }

        //Cập nhật thông tin ngành hàng
        public bool DalUpdateType(ProductType type)
        {
            context = new MiniProjectTGDDContext();
            context.ProductTypes.Update(type);
            context.SaveChanges();
            
            return true;
        }


        //lấy 1 loại sản phẩm 
        public ProductType ReadType(string id)
        {
            context = new MiniProjectTGDDContext();
            var item = context.ProductTypes.Include(i => i.ProductSpecifications).ThenInclude(s => s.InformationProperties).Where(t => t.Typeid == id).FirstOrDefault();  
            if (item == null)
            {
                return null;
            }
            return item;
        }

        //lấy danh sách ngành hàng
        public List<ProductType> ReadTypes()
        {         
            var data = context.ProductTypes.ToList();
            return data;
        }

        //Xóa ngành hàng
        public void deletetype(string typeid)
        {
            //kiểm tra sản phẩm ngành hàng
            var item = ReadType(typeid);
            if (item.Typeid != null)
            {
                foreach (var item2 in item.ProductSpecifications)
                {
                    foreach (var item3 in item2.InformationProperties)
                    {
                        context.InformationProperties.Remove(item3);
                    }
                    context.ProductSpecifications.Remove(item2);

                }
                context.ProductTypes.Remove(item);
                context.SaveChanges();
            }
        }


        /// <summary>
        /// kiểm tra sản phẩm của ngành hàng còn tồn tại
        /// </summary>
        /// <param name="typeId">mã ngành hàng</param>
        /// <returns>true được xóa sản phẩm</returns>
        /// <returns>false không được xóa sản phẩm</returns>
        public bool CheckProductByTypeId(string typeId)
        {
            var data = context.Products.Where(p => p.ProductType == typeId).ToList();
            if (data.Count == 0) return true;
            else return false;
        }

    }
}
