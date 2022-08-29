using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Models;

namespace DAL
{
    public class Dal_productphotos
    {
        MiniProjectTGDDContext context = new MiniProjectTGDDContext();
        // ket noi hinh va sản phẩm 
        public bool DalAddProductPhoto(ProductPhoto productPhoto)
        {
                

                context.ProductPhotos.Add(productPhoto);
                context.SaveChanges();
            return true;
           
        }
        public bool DelPhoto(string id)
        {
           
           
                var data = context.ProductPhotos.First(c => c.VersionId == id);
                context.Remove(data);
                context.SaveChanges();
            
            return true;
        }

    }
}
