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



    }

    public class Bus_ProductPecification:IBusProductPecification
    {
        private static Bus_ProductPecification _instance ;
        private static IDalProductPecification iDalProductPecification;
        public static Bus_ProductPecification GetBus_ProductPecification(IDalProductPecification dalProductPecification) {
            iDalProductPecification = dalProductPecification;
            if(_instance == null) { _instance = new Bus_ProductPecification(); }
            return _instance; }
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


    }
}
