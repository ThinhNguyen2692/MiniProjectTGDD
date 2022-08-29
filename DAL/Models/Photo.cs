using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class Photo
    {
        public Photo()
        {
            ProductPhotos = new HashSet<ProductPhoto>();
        }

        public int PhotoId { get; set; }
        public string PhotoPath { get; set; } = null!;
        public string? PhotoDescription { get; set; }

        public Photo(string PhotoPath)
        {
            this.PhotoPath = PhotoPath;
        }
        public virtual ICollection<ProductPhoto> ProductPhotos { get; set; }
    }
}
