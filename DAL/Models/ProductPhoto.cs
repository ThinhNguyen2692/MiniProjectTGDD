using System;
using System.Collections.Generic;

namespace DAL.Models
{
    public partial class ProductPhoto
    {
        public int ProductPhotoId { get; set; }
        public string VersionId { get; set; } = null!;
        public int PhotoId { get; set; }

        public virtual Photo Photo { get; set; } = null!;
        public virtual ProductVersion Version { get; set; } = null!;
    }
}
