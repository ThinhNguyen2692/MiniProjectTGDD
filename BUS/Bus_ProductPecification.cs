using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    
    public class Bus_ProductPecification
    {
        Dal_ProductPecification dal_ProductPecification = new Dal_ProductPecification();

        //thêm thông số ky thuật
        public int BusAddProductPecification(string TypeId, string name, string Description)
        {
            ProductSpecification productSpecification = new ProductSpecification(TypeId, name, Description);
            return dal_ProductPecification.DalAddProductPecification(productSpecification);
        }

        // lấy danh sách thông số theo type
        public List<ProductSpecification> ReadSpecification(string id)
        {
            return dal_ProductPecification.ReadSpecification(id);
        }
        
        //cập nhật thông số
        public bool UpdateSpecificatio(ProductSpecification specification)
        {
            return dal_ProductPecification.UpdateSpecificatio(specification);
        }

        //Xóa thông số 
        public bool DeleteSpecification(int specification) { return dal_ProductPecification.DeleteSpecification(specification); }

        // Xóa thông số theo type id
        public bool DeleteSpecificationType(string typeid) { return dal_ProductPecification.DeleteSpecificationType(typeid); }


    }
}
