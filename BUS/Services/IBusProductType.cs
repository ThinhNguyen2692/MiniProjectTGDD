using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ModelProject.Models;
using ModelProject.ViewModel;

namespace BUS.Services
{
    public interface IBusProductType
    {
        public bool BusAddType(CreateProductType type);
        public ProductTypeDetail BusUpdateType(ProductTypeDetail type);
        public List<ListProductTypeViewModel> ReadAll();
        public ProductTypeDetail BusReadType(string id);
        public bool deletetype(string typeid);
        public bool DeleteInformationProperty(int idProperty);
        public bool deleteSpecificatio(int SpecìficationId);



        public void BusAddInformationProperties(CreateInformationProperty informationProperty);
      
  

      

        public int BusAddProductPecification(CreateProductPecification informationProperty);
      
        public string GetTypeIdBySpecification(int SpecificationId);
    }
}
