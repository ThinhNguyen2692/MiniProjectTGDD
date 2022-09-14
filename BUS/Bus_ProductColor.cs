using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public interface IBusProductColor
    {
        public List<ProductColor> BusReadProductColors(string id);
        public bool AddProductColor(ProductColor productColor);

        public List<string> delColor(string idProduct);

    }
    public class Bus_ProductColor:IBusProductColor
    {
        private IDalProductColor dal_ProductColor;


        public Bus_ProductColor(IDalProductColor dal_ProductColor)
        {
            this.dal_ProductColor = dal_ProductColor;
        }

       
        public bool AddProductColor(ProductColor productColor)
        {

            return dal_ProductColor.AddProductColor(productColor);
        }
        public List<ProductColor> BusReadProductColors(string id)
        {
            return dal_ProductColor.DalReadProductColors(id);
        }

        public List<string> delColor(string idProduct)
        {
            return dal_ProductColor.delColor(idProduct);
        }
    }
}
