using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject.ViewModel;
using DAL;
using BUS.Services;

namespace BUS
{
    public class BusProductType:IBusProductType
    {
        private readonly IDaltype daltype;
        private readonly IDalProductPecification iDalProductPecification;
        private readonly IDalInformationProperties iDalInformationProperties;
        private readonly IDAlProduct iDAlProduct;
        public BusProductType(IDaltype daltype, IDalProductPecification iDalProductPecification, IDalInformationProperties iDalInformationProperties, IDAlProduct iDAlProduct)
        {
            this.daltype = daltype;
            this.iDalProductPecification = iDalProductPecification;
            this.iDalInformationProperties = iDalInformationProperties;
            this.iDAlProduct = iDAlProduct;  
        }



        /// <summary>
        ///Thêm ngành hàng
        /// </summary>
        /// <param name="type">thông tin ngành hàng</param>
        /// <returns>true thêm thành công </returns>
        /// <returns>false thêm thất bại </returns>
        public bool BusAddType(CreateProductType type)
        {
            ProductType productType = new ProductType{ Typeid = type.typeId, Typename = type.typeName };
            return daltype.DalAddType(productType);
        }

        /// <summary>
        /// thêm thông tin thông số kỹ thuật
        /// </summary>
        /// <param name="productSpecification"></param>
        /// <returns></returns>
        public int BusAddProductPecification(CreateProductPecification productSpecification)
        {
            ProductSpecification specification = new ProductSpecification() { 
                TypeId = productSpecification.typeId, 
                SpecificationsName = productSpecification.ProductPecificationName,  
                SpecificationsDescription = productSpecification.ProductPecificationDrecription};
            return iDalProductPecification.DalAddProductPecification(specification);
        }

        /// <summary>
        ///thêm thông tin thuộc tính thông số cho sản phẩm
        /// </summary>
        /// <param name="informationProperty">Thông tin thuộc tính</param>
        public void BusAddInformationProperties(CreateInformationProperty informationProperty)
        {
            InformationProperty valueAdd = new InformationProperty()
            {
                SpecificationsId = informationProperty.SpecificationId,
                PropertiesName = informationProperty.InformationPropertyName,
                PropertiesDescription = informationProperty.Description
            };
            iDalInformationProperties.AddInformationProperties(valueAdd);
        }

        /// <summary>
        /// cập nhật thông tin ngành hàng 
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        public ProductTypeDetail BusUpdateType(ProductTypeDetail type)
        {
            //cập nhật thông tin ngành hàng 
            ProductType productType = new ProductType()
            {
                Typeid = type.TypeId,
                Typename = type.TypeName
            };
            foreach (var item in type.createListProductSpecification)
            {
              ProductSpecification value = new ProductSpecification()
                {
                    SpecificationsName = item.SpecificationName,
                    SpecificationsId = item.SpecificationId,
                    TypeId = type.TypeId
                };
                foreach (var item2 in item.listInformationProperty)
                {
                    InformationProperty informationProperty = new InformationProperty();
                    informationProperty.PropertiesName = item2.PropertyName;
                    informationProperty.PropertiesId = item2.PropertyId;
                    informationProperty.SpecificationsId = item.SpecificationId;
                    informationProperty.PropertiesDescription = item2.PropertiesDescription;

                    value.InformationProperties.Add(informationProperty);
                }

                productType.ProductSpecifications.Add(value);
            }
            bool check = daltype.DalUpdateType(productType);
            if (check == true)
            {
                type.messageUpdate = "UpdateProductTypeTrue";
            }
            else
            {
                type.messageUpdate = "UpdateProductTypeFalse";
            }
            return type;
        }

        /// <summary>
        /// đọc danh sách thông tin ngành hàng
        /// </summary>
        /// <returns>danh sách ngành hàng (ListProductTypeViewModel) </returns>
        public List<ListProductTypeViewModel> ReadAll()
        {
            //danh sách ngành hàng
            var data = daltype.ReadTypes();

            var listproductType = new List<ListProductTypeViewModel>();

            foreach (var item in data)
            {
                ListProductTypeViewModel viewModel = new ListProductTypeViewModel();
                viewModel.TypeName = item.Typename;
                viewModel.TypeId = item.Typeid;
                listproductType.Add(viewModel );
            }


            return listproductType;
        }
       
        /// <summary>
        /// đọc thông tin ngành hàng (producttype InformationProperty productSpecificaion)
        /// </summary>
        /// <param name="id">mã ngành hàng</param>
        /// <returns></returns>
        public ProductTypeDetail BusReadType(string id)
        {
            //dữ liệu
            var data = daltype.ReadType(id);
            var InformationProductTypeDetail = new ProductTypeDetail();
            InformationProductTypeDetail.TypeId = data.Typeid;
            InformationProductTypeDetail.TypeName = data.Typename;

            //danh sách thông tin thông số kỹ thuật
            foreach (var item in data.ProductSpecifications)
             {   
                //danh sách thông tin thông số kỹ thuật
                var valueProductSpecification = new ListProductSpectification();
                valueProductSpecification.SpecificationName = item.SpecificationsName;
                valueProductSpecification.SpecificationId = item.SpecificationsId;
                // thông tin thuộc tín của thông số kỹ thuật
                
                //lấy thông tin thông số kỹ thuật
                foreach (var item2 in item.InformationProperties)
                {
                    var valueinformationProperty = new ListInformationProperty();
                    valueinformationProperty.PropertyName = item2.PropertiesName;
                    valueinformationProperty.PropertyId = item2.PropertiesId;
                    valueinformationProperty.PropertiesDescription = item2.PropertiesDescription;

                    valueProductSpecification.listInformationProperty.Add(valueinformationProperty);
                }


                InformationProductTypeDetail.createListProductSpecification.Add(valueProductSpecification);
            }
            return InformationProductTypeDetail;
        }
       
        
        //xóa ngành hàng
        public bool deletetype(string typeid)
        {
            // kiểm tra sản phẩm ngành hàng còn tồn tại
            //true sản phẩm ngành hàng = 0 được xóa
            if (daltype.CheckProductByTypeId(typeid) == true)
            {

                daltype.deletetype(typeid);
                return true;
            }
            return false;
        }

        public bool deleteSpecificatio(int SpecificationId)
        {
            // kiểm tra sản phẩm ngành hàng còn tồn tại
            //true sản phẩm ngành hàng = 0 được xóa

            if (iDalProductPecification.DeleteSpecification(SpecificationId) == true)
            {
                return true;
            }
            return false;
        }

        /// <summary>
        /// Xóa thuộc tính ngành hàng
        /// </summary>
        /// <param name="idProperty">mã thuộc tính</param>
        /// <returns>true: được xóa</returns>
        /// <returns>true: đã xóa thông và người ngãm</returns>
        public bool DeleteInformationProperty(int idProperty)
        {
            if (iDalInformationProperties.DalDeleteProperty(idProperty) == true)
            {
                return true;
            }
            return false;
        }

     


     
      
        public string GetTypeIdBySpecification(int SpecificationId)
        {
            return iDalProductPecification.GetTypeIdBySpecification(SpecificationId);
        }


       
    }
}
