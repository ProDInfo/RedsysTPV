using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Models;

namespace RedsysTPV.Tests
{
    [TestClass]
    public class PaymentRequestServiceTests
    {
        [TestMethod]
        public void GetPaymentRequestFormData_ShouldWork()
        {
            string merchantKey = "Mk9m98IfEblmPfrpsawt7BmxObt98Jev";
            PaymentRequest paymentRequest = new PaymentRequest(
                "",
                "999008881",
                "871",
                "0",
                "145",
                "978",
                "19990000000A",
                "",
                "",
                ""
                );
            IPaymentRequestService paymentRequestService = new PaymentRequestService();
            var result = paymentRequestService.GetPaymentRequestFormData(paymentRequest, merchantKey);

            Assert.IsTrue(result.Ds_SignatureVersion == "HMAC_SHA256_V1");
            Assert.IsTrue(result.Ds_MerchantParameters == "eyJEc19NZXJjaGFudF9Db25zdW1lckxhbmd1YWdlIjoiIiwiRHNfTWVyY2hhbnRfQW1vdW50IjoiMTQ1IiwiRHNfTWVyY2hhbnRfT3JkZXIiOiIxOTk5MDAwMDAwMEEiLCJEc19NZXJjaGFudF9NZXJjaGFudENvZGUiOiI5OTkwMDg4ODEiLCJEc19NZXJjaGFudF9DdXJyZW5jeSI6Ijk3OCIsIkRzX01lcmNoYW50X1RyYW5zYWN0aW9uVHlwZSI6IjAiLCJEc19NZXJjaGFudF9UZXJtaW5hbCI6Ijg3MSIsIkRzX01lcmNoYW50X01lcmNoYW50VVJMIjoiIiwiRHNfTWVyY2hhbnRfVXJsT0siOiIiLCJEc19NZXJjaGFudF9VcmxLTyI6IiJ9");
            Assert.IsTrue(result.Ds_Signature == "w8ddr3qPbnvQfn+bSfq1eEHYnLGtUuGHQZxOhSq25Qc=");
        }

    }
}
