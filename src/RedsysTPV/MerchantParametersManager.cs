using RedsysTPV.Models;
using RedsysTPV.Helpers;
using System.Net;
using System.Runtime.Serialization;
using System.Text.Json.Serialization;
using System.Text.Json;
using System;

namespace RedsysTPV
{
    public class MerchantParametersManager : IMerchantParametersManager
    {
        public string GetMerchantParameters(PaymentRequest paymentRequest)
        {
            //var settings = new JsonSerializerSettings
            //{
            //    DefaultValueHandling = DefaultValueHandling.Ignore,
            //    NullValueHandling = NullValueHandling.Ignore,
            //    Context = new StreamingContext(StreamingContextStates.All, paymentRequest.Ds_Merchant_Currency)
            //};
            //string json = JsonConvert.SerializeObject(paymentRequest, Formatting.Indented, settings);
            //return Base64.EncodeUtf8To64(json);

            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };

            PaymentRequest copyRequest = paymentRequest.Clone();

            int truncate = (int)Math.Truncate(copyRequest.Ds_Merchant_Amount);
            int remainder = (int)Math.Truncate((copyRequest.Ds_Merchant_Amount - truncate) * 100);
            int amount;
            if (copyRequest.Ds_Merchant_Currency == Currency.JPY)
                amount = truncate;
            else
                amount = truncate * 100 + remainder;
            copyRequest.Ds_Merchant_Amount = amount;

            string json = JsonSerializer.Serialize(copyRequest, options);
            return Base64.EncodeUtf8To64(json);
        }

        public PaymentResponse GetPaymentResponse(string merchantParameters)
        {
            merchantParameters = merchantParameters.Replace('-', '+').Replace('_', '/');
            var options = new JsonSerializerOptions
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true
            };
            var json = Base64.DecodeUtf8From64(merchantParameters);
            var response = JsonSerializer.Deserialize<PaymentResponse>(json, options);

            if (response.Ds_Currency != Currency.JPY)
                response.Ds_Amount = response.Ds_Amount / 100M;
            return response;
        }
    }
}
