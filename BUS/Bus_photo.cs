using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Models;
using DAL;

namespace BUS
{
    public class Bus_photo
    {
        Dal_Photo dal_Photo = new Dal_Photo();
        //Thêm hình
        public List<int> AddPhoto(List<string> FileName) {
            List<int> list = new List<int>();
          
                foreach (var item in FileName)
                {
                    Photo p = new Photo(item);
                    int id = dal_Photo.AddPhoto(p);
                    if (id != -1)
                    {
                        list.Add(id);
                    }
                }
           
            return list;
        }
    }
}
