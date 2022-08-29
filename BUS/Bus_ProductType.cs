using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    
     public class Bus_ProductType
    {
        Dal_ProductType dal_ProductType = new Dal_ProductType();

        //thêm ngành hàng
        public bool BusAddType(string TypeID, string TypeName)
        {
            ProductType type = new ProductType(TypeID, TypeName);
            return dal_ProductType.DalAddType(type);
        }

        //Cập nhật thông tin ngành hàng
        public bool BusUpdateType(ProductType type)
        {
            return dal_ProductType.DalUpdateType(type);
        }

        // lấy danh sách ngành hàng
        public List<ProductType> ReadAll()
        {
            return dal_ProductType.ReadTypes();
        }
        //lay 1 ngành hàng
        public ProductType BusReadType(string id)
        {
            return dal_ProductType.ReadType(id);
        }
        //xóa ngành hàng
        public bool deletetype(string typeid)
        {
            return dal_ProductType.deletetype(typeid);
        }
    }
    
}
