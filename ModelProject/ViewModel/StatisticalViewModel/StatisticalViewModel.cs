using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.ViewModel
{
    public class ProductStatistical
    {
        public ProductStatistical() { }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public int Price { get; set; }

        public int ProductQuantity { get; set; }
    }

    public class PurChaseOderStatistical
    {
        public PurChaseOderStatistical(string PurChaseOderName) { this.PurChaseOderName = PurChaseOderName; }
        public int PurChaseOderQuantity { get; set; }
        public string PurChaseOderName { get; set; }
        public int PurChaseOderprice { get; set; }
    }


    public class StatisticalViewModel
    {
        public StatisticalViewModel() { }

        public List<ProductStatistical> ProductStatistical { get; set; } = new List<ProductStatistical>();

        public PurChaseOderStatistical purChaseOderStatisticalsProcessing { get; set; } = new PurChaseOderStatistical("Đang sử lý");
        public PurChaseOderStatistical purChaseOderStatisticalsDelivering { get; set; } = new PurChaseOderStatistical("Đang giao");
        public PurChaseOderStatistical purChaseOderStatisticalsDelivered { get; set; } = new PurChaseOderStatistical("Đã giao");
        public PurChaseOderStatistical purChaseOderStatisticalsCancelled { get; set; } = new PurChaseOderStatistical("Đã hủy");

        

    }
}
