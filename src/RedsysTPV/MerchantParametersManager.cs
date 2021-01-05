using RedsysTPV.Models;
using RedsysTPV.Helpers;
using System.Text.Json.Serialization;
using System.Text.Json;

namespace RedsysTPV
{
    public class MerchantParametersManager : IMerchantParametersManager
    {
        public string GetMerchantParameters(PaymentRequest paymentRequest)
        {
            var json = JsonSerializer.Serialize(paymentRequest);
            return Base64.EncodeTo64(json);
        }

        public PaymentResponse GetPaymentResponse(string merchantParameters)
        {
            var json = Base64.DecodeFrom64(merchantParameters);
            return JsonSerializer.Deserialize<PaymentResponse>(json);
        }
    }
}
