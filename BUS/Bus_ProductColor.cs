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
        private static IDalProductColor dal_ProductColor;
        private static Bus_ProductColor _instance ;

        public static Bus_ProductColor GetBus_ProductColor(IDalProductColor productColor) {
            if (_instance == null) { _instance = new Bus_ProductColor(); }
                dal_ProductColor = productColor;
            return _instance; }

       
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
