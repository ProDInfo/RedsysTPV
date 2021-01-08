using System;

namespace RedsysTPV.WebSample.Models
{
    public class ResponseViewModel
    {
        public string AuthorisationCode { get; set; }
        public DateTime Date { get; set; }
        public decimal Amount { get; set; }
        public string CardNumber { get; set; }
        public string ExpiryDate { get; set; }
    }
}
