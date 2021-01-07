using System;

namespace RedsysTPV.WebSample.Models
{
    public class RequestViewModel
    {
        public string MerchantCode { get; set; }
        public string MerchantOrder { get; set; }
        public decimal Amount { get; set; }
    }
}
