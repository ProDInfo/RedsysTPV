using RedsysTPV.Models;
using Newtonsoft.Json;
using RedsysTPV.Helpers;
using System.Net;
using System.Runtime.Serialization;

namespace RedsysTPV
{
    public class MerchantParametersManager : IMerchantParametersManager
    {
        public string GetMerchantParameters(PaymentRequest paymentRequest)
        {
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore,
                Context = new StreamingContext(StreamingContextStates.All, paymentRequest.Ds_Merchant_Currency)
            };
            string json = JsonConvert.SerializeObject(paymentRequest, Formatting.Indented, settings);
            return Base64.EncodeUtf8To64(json);
        }

        public PaymentResponse GetPaymentResponse(string merchantParameters)
        {
            var settings = new JsonSerializerSettings
            {
                DefaultValueHandling = DefaultValueHandling.Ignore,
                NullValueHandling = NullValueHandling.Ignore
                //Context = new StreamingContext(StreamingContextStates.All, merchantParameters)
            };
            merchantParameters = merchantParameters.Replace('-', '+').Replace('_', '/');
            var json = WebUtility.UrlDecode(Base64.DecodeUtf8From64(merchantParameters));
            var response =JsonConvert.DeserializeObject<PaymentResponse>(json, settings);

            if (response.Ds_Currency != Currency.JPY)
                response.Ds_Amount = response.Ds_Amount / 100M;
            return response;
        }
    }
}
