using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public interface IBusProductType
    {
        public bool BusAddType(ProductType type);
        public bool BusUpdateType(ProductType type);
        public List<ProductType> ReadAll();
        public ProductType BusReadType(string id);
        public void deletetype(string typeid);

    }
     public class Bus_ProductType:IBusProductType
    {
        public IDaltype daltype;
        public Bus_ProductType(IDaltype daltype) { this.daltype = daltype; }

        //thêm ngành hàng
        public bool BusAddType(ProductType type)
        {
            return daltype.DalAddType(type);
        }

        //Cập nhật thông tin ngành hàng
        public bool BusUpdateType(ProductType type)
        {
            return daltype.DalUpdateType(type);
        }

        // lấy danh sách ngành hàng
        public List<ProductType> ReadAll()
        {
            return daltype.ReadTypes();
        }
        //lay 1 ngành hàng
        public ProductType BusReadType(string id)
        {
            return daltype.ReadType(id);
        }
        //xóa ngành hàng
        public void deletetype(string typeid)
        {
             daltype.deletetype(typeid);
        }
    }
    
}
