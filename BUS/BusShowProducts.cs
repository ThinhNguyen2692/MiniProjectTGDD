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
    public class BusShowProducts:IBusShowProducts
    {
        private IDalBrands dalBrands;
        private IDaltype daltype;
        private IDalProductVersion dalProductVersion;

       public BusShowProducts( IDalProductVersion dalProductVersion, IDalBrands dalBrands, IDaltype daltype)
        {
            this.dalBrands = dalBrands;
            this.daltype = daltype;
            this.dalProductVersion = dalProductVersion;
        }


        public HeaderViewModel HeaderViewModel()
        {
            HeaderViewModel viewModel = new HeaderViewModel();
            //Lấy thông tin thương hiệu trạng thái đang kinh doanh
            var ListBrand = dalBrands.DalGetbrandsByStatus();
            foreach (var item in ListBrand)
            {
                ShowBrandsViewModel model = new ShowBrandsViewModel();
                model.BrandId = item.BrandId;
                model.BrandName = item.BrandName;
                model.BrandPhoto = item.BrandPhoto;
                model.BrandStatus = item.BrandStatus;
                viewModel.showBrandsViewModels.Add(model);
            }


            var listType = daltype.ReadTypes();
            foreach (var item in listType)
            {
                ListProductTypeViewModel model = new ListProductTypeViewModel();
                model.TypeId = item.Typeid;
                model.TypeName = item.Typename;
                viewModel.listProductTypeViewModels.Add(model);
            }

            return viewModel;

        }

    }
}
