using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL;
using BUS.Services;

namespace BUS
{
    public class BusProductType:IBusProductType
    {
        private IDaltype daltype;
        private IDalProductPecification iDalProductPecification;
        private IDalInformationProperties iDalInformationProperties;
        public BusProductType(IDaltype daltype, IDalProductPecification iDalProductPecification, IDalInformationProperties iDalInformationProperties)
        {
            this.daltype = daltype;
            this.iDalProductPecification = iDalProductPecification;
            this.iDalInformationProperties = iDalInformationProperties;
        }



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
        //lấy thuộc tính theo loại
        public List<InformationProperty> ReadProperty(string id)
        {
            return iDalInformationProperties.ReadProperty(id);
        }
        public void UpDateProperty(InformationProperty property)
        {
            iDalInformationProperties.DalUpdateProperty(property);
        }

        public bool DalDeleteProperty(int property) { return iDalInformationProperties.DalDeleteProperty(property); }
        public bool DalDeletePropertySpecification(int SpecificationID) { return iDalInformationProperties.DalDeletePropertySpecification(SpecificationID); }
        public bool DeletePropertyType(string id) { return iDalInformationProperties.DeletePropertyType(id); }

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
        public void UpdateSpecificatio(ProductSpecification specification)
        {
            iDalProductPecification.UpdateSpecificatio(specification);
        }

        //Xóa thông số 
        public bool DeleteSpecification(int specification) { return iDalProductPecification.DeleteSpecification(specification); }

        // Xóa thông số theo type id
        public void DeleteSpecificationType(string typeid) { iDalProductPecification.DeleteSpecificationType(typeid); }

        public string GetTypeIdBySpecification(int SpecificationId)
        {
            return iDalProductPecification.GetTypeIdBySpecification(SpecificationId);
        }

        public void BusAddInformationProperties(InformationProperty informationProperty)
        {
            throw new NotImplementedException();
        }
    }
}
