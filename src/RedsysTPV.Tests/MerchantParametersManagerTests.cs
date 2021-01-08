using Microsoft.VisualStudio.TestTools.UnitTesting;
using RedsysTPV.Models;

namespace RedsysTPV.Tests
{
    [TestClass]
    public class MerchantParametersManagerTests
    {
        [TestMethod]
        public void GetMerchantParameters_ShouldWork()
        {
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
            IMerchantParametersManager merchantParamentersManager = new MerchantParametersManager();
            var result = merchantParamentersManager.GetMerchantParameters(paymentRequest);

            Assert.IsTrue(result== "ew0KICAiRHNfTWVyY2hhbnRfQW1vdW50IjogIjE0NSIsDQogICJEc19NZXJjaGFudF9Db25zdW1lckxhbmd1YWdlIjogIjAwMSIsDQogICJEc19NZXJjaGFudF9DdXJyZW5jeSI6ICI5NzgiLA0KICAiRHNfTWVyY2hhbnRfTWVyY2hhbnRDb2RlIjogIjk5OTAwODg4MSIsDQogICJEc19NZXJjaGFudF9NZXJjaGFudFVSTCI6ICIiLA0KICAiRHNfTWVyY2hhbnRfT3JkZXIiOiAiMTk5OTAwMDAwMDBBIiwNCiAgIkRzX01lcmNoYW50X1BheW1ldGhvZHMiOiAiQyIsDQogICJEc19NZXJjaGFudF9UZXJtaW5hbCI6ICI4NzEiLA0KICAiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjogIjAiLA0KICAiRHNfTWVyY2hhbnRfVXJsT0siOiAiIiwNCiAgIkRzX01lcmNoYW50X1VybEtPIjogIiINCn0=");
        }

        [TestMethod]
        public void GetMerchantParameters_ShouldWork_2()
        {
            PaymentRequest paymentRequest = new PaymentRequest(
                "999008881",
                "871",
                Enums.TransactionType.Authorization,
                1.45M,
                Currency.EUR,
                "999911111111",
                "",
                "",
                "",
                Language.Spanish
                );
            IMerchantParametersManager merchantParamentersManager = new MerchantParametersManager();
            var result = merchantParamentersManager.GetMerchantParameters(paymentRequest);

            Assert.IsTrue(result == "ew0KICAiRHNfTWVyY2hhbnRfQW1vdW50IjogIjE0NSIsDQogICJEc19NZXJjaGFudF9Db25zdW1lckxhbmd1YWdlIjogIjAwMSIsDQogICJEc19NZXJjaGFudF9DdXJyZW5jeSI6ICI5NzgiLA0KICAiRHNfTWVyY2hhbnRfTWVyY2hhbnRDb2RlIjogIjk5OTAwODg4MSIsDQogICJEc19NZXJjaGFudF9NZXJjaGFudFVSTCI6ICIiLA0KICAiRHNfTWVyY2hhbnRfT3JkZXIiOiAiOTk5OTExMTExMTExIiwNCiAgIkRzX01lcmNoYW50X1BheW1ldGhvZHMiOiAiQyIsDQogICJEc19NZXJjaGFudF9UZXJtaW5hbCI6ICI4NzEiLA0KICAiRHNfTWVyY2hhbnRfVHJhbnNhY3Rpb25UeXBlIjogIjAiLA0KICAiRHNfTWVyY2hhbnRfVXJsT0siOiAiIiwNCiAgIkRzX01lcmNoYW50X1VybEtPIjogIiINCn0=");
        }

        [TestMethod]
        public void GetPaymentResponse_ShouldWork()
        {
            var merchantParamenters = "eyJEc19EYXRlIjoiMTkvMDgvMjAxNSIsIkRzX0hvdXIiOiIxMjo0OSIsIkRzX0Ftb3VudCI6IjEyMzQ1IiwiRHNfQ3VycmVuY3kiOiI5NzgiLCJEc19PcmRlciI6Ijk5OTkxMTExMjIyMiIsIkRzX01lcmNoYW50Q29kZSI6IjAxMjM0NTYiLCJEc19UZXJtaW5hbCI6IjIiLCJEc19SZXNwb25zZSI6IjAiLCJEc19NZXJjaGFudERhdGEiOiIiLCJEc19TZWN1cmVQYXltZW50IjoiMSIsIkRzX1RyYW5zYWN0aW9uVHlwZSI6IjAiLCJEc19DYXJkX0NvdW50cnkiOiIiLCJEc19BdXRob3Jpc2F0aW9uQ29kZSI6IjAiLCJEc19Db25zdW1lckxhbmd1YWdlIjoiMCIsIkRzX0NhcmRfVHlwZSI6IkQifQ==";
            IMerchantParametersManager merchantParamentersManager = new MerchantParametersManager();
            var paymentResponse = merchantParamentersManager.GetPaymentResponse(merchantParamenters);

            Assert.IsNotNull(paymentResponse);
            Assert.IsTrue(paymentResponse.Ds_Amount == 123.45M);
            Assert.IsTrue(paymentResponse.Ds_AuthorisationCode == "0");
            Assert.IsTrue(paymentResponse.Ds_Card_Country == "");
            Assert.IsTrue(paymentResponse.Ds_Card_Type == "D");
            Assert.IsTrue(paymentResponse.Ds_ConsumerLanguage == Language.Defect);
            Assert.IsTrue(paymentResponse.Ds_Currency == Currency.EUR);
            Assert.IsTrue(paymentResponse.Ds_Date == "19/08/2015");
            Assert.IsTrue(paymentResponse.Ds_Hour == "12:49");
            Assert.IsTrue(paymentResponse.Ds_MerchantCode == "0123456");
            Assert.IsTrue(paymentResponse.Ds_MerchantData == "");
            Assert.IsTrue(paymentResponse.Ds_Order == "999911112222");
            Assert.IsTrue(paymentResponse.Ds_Response == "0");
            Assert.IsTrue(paymentResponse.Ds_SecurePayment == "1");
            Assert.IsTrue(paymentResponse.Ds_Terminal == "2");
            Assert.IsTrue(paymentResponse.Ds_TransactionType == Enums.TransactionType.Authorization);
        }
    }
}
