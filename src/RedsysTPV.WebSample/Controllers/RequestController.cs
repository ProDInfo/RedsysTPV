using RedsysTPV.Enums;
using RedsysTPV.Models;
using System.Configuration;
using System.Security.Policy;
using Microsoft.AspNetCore.Mvc;
using System;
using Microsoft.Extensions.Configuration;

namespace RedsysTPV.WebSample.Controllers
{
    public class RequestController : Controller
    {
        private IConfiguration _configuration;
        public RequestController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        // GET: Request
        public ActionResult Index(string merchantCode, string merchantOrder, decimal amount)
        {
            var paymentRequestService = new PaymentRequestService();

            var paymentRequest = new PaymentRequest(
                Ds_Merchant_ConsumerLanguage: Language.Spanish,
                Ds_Merchant_MerchantCode: merchantCode,
                Ds_Merchant_Terminal: "1",
                Ds_Merchant_TransactionType: TransactionType.Authorization,
                Ds_Merchant_Amount: amount,
                Ds_Merchant_Currency: Currency.EUR,
                Ds_Merchant_Order: merchantOrder,
                Ds_Merchant_MerchantURL: Url.Action("Index", "Response", null, Request.Scheme),
                Ds_Merchant_UrlOK: Url.Action("OK", "Result", null, Request.Scheme),
                Ds_Merchant_UrlKO: Url.Action("KO", "Result", null, Request.Scheme)
                );

            paymentRequest.Ds_Merchant_Paymethods = PaymentMethod.CreditCard;
            paymentRequest.Ds_Merchant_Titular = "TITULAR";
            paymentRequest.Ds_Merchant_MerchantName = "MY COMMERCE";
            paymentRequest.Ds_Merchant_ProductDescription = "PRODUCT DESCRIPTION";
            paymentRequest.Ds_Merchant_Identifier = "REQUIRED";

            var secrets = _configuration.GetSection("Secrets");

            var formData = paymentRequestService.GetPaymentRequestFormData(
                paymentRequest: paymentRequest,
                merchantKey: secrets["key"]);

            ViewBag.ConnectionURL = secrets["url"];
            return View(formData);
        }
    }
}