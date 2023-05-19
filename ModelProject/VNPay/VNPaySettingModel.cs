using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ModelProject.VNPay
{
    public class VNPaySettingModel 
    {
        public VNPaySettingModel() { }
		public string vnp_Version { get; set; }
		public string vnp_Command { get; set; }
		public string vnp_TmnCode { get; set; }
		public string vnp_Amount { get; set; }
		public string vnp_BankCode { get; set; }
		public string vnp_CreateDate { get; set; }
		public string vnp_CurrCode { get; set; }
		public string vnp_Locale { get; set; }
		public string vnp_OrderInfo { get; set; }
		public string vnp_OrderType { get; set; }
		public string vnp_ReturnUrl { get; set; }
		public string vnp_ExpireDate { get; set; }
		public string vnp_TxnRef { get; set; }
		public string vnp_SecureHash { get; set; }
		public string vnp_HashSecret { get; set; }
        public string vnp_Url { get; set; }
    }

    public class VNPayPaymetResponse
    {
        public string vnp_TmnCode { get; set; }
        public string vnp_Amount { get; set; }
        public string vnp_BankCode { get; set; }
        public string vnp_BankTranNo { get; set; }
        public string vnp_CardType { get; set; }
        public string vnp_PayDate { get; set; }
        public string vnp_OrderInfo { get; set; }
        public string vnp_TransactionNo { get; set; }
        public string vnp_ResponseCode { get; set; }
        public string vnp_TransactionStatus { get; set; }
        public string vnp_TxnRef { get; set; }
        public string vnp_SecureHashType { get; set; }
        public string vnp_SecureHash { get; set; }
    }

}
