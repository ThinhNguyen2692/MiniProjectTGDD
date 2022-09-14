namespace CMSWeb.Models
{
    public class GiftModel
    {
        public string ProdcutId { get; set; }
        public string ProducName { get; set; }
        public int? Price { get; set; }
        public string image { get; set; }

        public bool check { get; set; }


        public GiftModel() { }
        public GiftModel(string ProdcutId, string ProducName, int? Price, string image) {
         this.ProdcutId = ProdcutId;
            this.ProducName = ProducName;
            this.Price = Price;
            this.image = image;
        
        }
    }
}
