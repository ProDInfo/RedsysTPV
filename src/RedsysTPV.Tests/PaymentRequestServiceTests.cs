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
                "999008881",
                "871",
                Enums.TransactionType.Authorization,
                1.45M,
                Currency.EUR,
                "19990000000A",
                "",
                "",
                "",
                Language.Spanish
                );
            IPaymentRequestService paymentRequestService = new PaymentRequestService();
            var result = paymentRequestService.GetPaymentRequestFormData(paymentRequest, merchantKey);

            Assert.IsTrue(result.Ds_SignatureVersion == "HMAC_SHA256_V1");
            Assert.IsTrue(result.Ds_MerchantParameters == "ew0KICAiRHNfTWVyY2hhbnRfQW1vdW50IjogIjE0NSIsDQogICJEc19NZXJjaGFudF9Db25zdW1lckxhbmd1YWdlIjogIjAwMSIsDQogICJEc19NZXJjaGFudF9DdXJyZW5jeSI6ICI5NzgiLA0KICAiRHNfTWVyY2hhbnRfTWVyY2hhbnRDb2RlIjogIjk5OTAwODg4MSIsDQogICJEc19NZXJjaGFudF9NZXJjaGFudFVSTCI6ICIiLA0KICAiRHNfTWVyY2hhbnRfT3JkZXIiOiAiMTk5OTAwMDAwMDBBIiwNCiAgIkRzX01lcmNoYW50X1BheW1ldGhvZHMiOiAiQyIsDQogICJEc19NZXJjaGFudF9UZXJtaW5hbCI6ICI4NzEiLA0KICAiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjogIjAiLA0KICAiRHNfTWVyY2hhbnRfVXJsT0siOiAiIiwNCiAgIkRzX01lcmNoYW50X1VybEtPIjogIiINCn0=");
            Assert.IsTrue(result.Ds_Signature == "RIOJqg6hoE0SodvQqYSoGkHIa98Nkxep1xcRyBRhvSI=");
        }

    }
}
