using RedsysTPV.Models;

namespace RedsysTPV.Tests
{
    public static class Build
    {
        public static PaymentResponse PaymentResponse(bool paid)
        {
            return new PaymentResponse(){
                Ds_Amount = 1.23M,
                Ds_AuthorisationCode = "0",
                Ds_Card_Country = "1",
                Ds_Card_Type = "D",
                Ds_ConsumerLanguage = Language.Defect,
                Ds_Currency = Currency.EUR,
                Ds_Date = "01/01/2015",
                Ds_Hour = "22:00",
                Ds_MerchantCode = "TEST",
                Ds_MerchantData = "",
                Ds_Order = "",
                Ds_Response = paid ? "0000" : "101",
                Ds_SecurePayment = "",
                Ds_Terminal = "1",
                Ds_TransactionType = Enums.TransactionType.Authorization
            };
        }
    }
}
