using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public interface IBusProductPecification
    {
        public int BusAddProductPecification(ProductSpecification productSpecification);
        public List<ProductSpecification> ReadSpecification(string id);
        public bool UpdateSpecificatio(ProductSpecification specification);
        public bool DeleteSpecification(int specification) ;
        public void DeleteSpecificationType(string typeid) ;
        public string GetTypeIdBySpecification(int SpecificationId);


    }

    public class Bus_ProductPecification:IBusProductPecification
    {
        private IDalProductPecification iDalProductPecification;

        public Bus_ProductPecification(IDalProductPecification dalProductPecification) { iDalProductPecification = dalProductPecification; }
        //thêm thông số ky thuật
        public int BusAddProductPecification(ProductSpecification productSpecification)
        {
            return iDalProductPecification.DalAddProductPecification(productSpecification);
        }

        // lấy danh sách thông số theo type
        public List<ProductSpecification> ReadSpecification(string id)
        {
            return iDalProductPecification.ReadSpecification(id);
        }
        
        //cập nhật thông số
        public bool UpdateSpecificatio(ProductSpecification specification)
        {
            return iDalProductPecification.UpdateSpecificatio(specification);
        }

        //Xóa thông số 
        public bool DeleteSpecification(int specification) { return iDalProductPecification.DeleteSpecification(specification); }

        // Xóa thông số theo type id
        public void DeleteSpecificationType(string typeid) { iDalProductPecification.DeleteSpecificationType(typeid); }

        public string GetTypeIdBySpecification(int SpecificationId)
        {
            return iDalProductPecification.GetTypeIdBySpecification(SpecificationId);
        }
    }
}
