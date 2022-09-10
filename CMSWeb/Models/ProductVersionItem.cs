namespace CMSWeb.Models
{
    public class ProductVersionItem
    {
        public string VersionId { get; set; } = null!;
        public string ProductId { get; set; } = null!;
        public string VersionName { get; set; } = null!;
        public int? ProductPrice { get; set; }
        public int? ProductStatus { get; set; }
        public string ProductPhoto { get; set; } = null!;


        public ProductVersionItem() { }

        public ProductVersionItem(string versionId, string productId, string versionName, int? productPrice, int? productStatus, string productPhoto)
        {
            VersionId = versionId;
            ProductId = productId;
            VersionName = versionName;
            ProductPrice = productPrice;
            ProductStatus = productStatus;
            ProductPhoto = productPhoto;
        }
    }
}
