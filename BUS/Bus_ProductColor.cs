using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace BUS
{
    public class Bus_ProductColor
    {
        Dal_ProductColor dal_ProductColor = new Dal_ProductColor();
        public bool AddProductColor(string ProductId, string ColorDescription, string filieName)
        {
            ProductColor color = new ProductColor(ProductId, filieName, ColorDescription);
            return dal_ProductColor.AddProductColor(color);
        }
        public List<ProductColor> BusReadProductColors(string id)
        {
            return dal_ProductColor.DalReadProductColors(id);
        }
    }
}
