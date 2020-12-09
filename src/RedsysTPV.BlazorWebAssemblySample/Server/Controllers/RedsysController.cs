using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using RedsysTPV.BlazorWebAssemblySample.Shared.Models;
using RedsysTPV.Enums;
using RedsysTPV.Models;

namespace RedsysTPV.BlazorWebAssemblySample.Server.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RedsysController : ControllerBase
    {
        private readonly ILogger<RedsysController> logger;

        public RedsysController(ILogger<RedsysController> logger)
        {
            this.logger = logger;
        }

        [HttpGet("{orderNumber}")]
        public ActionResult<RedsysRequest> Get(string orderNumber, [FromServices] Secret secret)
        {
            PaymentRequestService paymentRequestService = new PaymentRequestService();

            PaymentRequest paymentRequest = new PaymentRequest(
                Ds_Merchant_ConsumerLanguage: Language.Spanish,
                Ds_Merchant_MerchantCode: "335088258",
                Ds_Merchant_Terminal: "1",
                Ds_Merchant_TransactionType: "0",
                Ds_Merchant_Amount: "123",
                Ds_Merchant_Currency: "978",
                Ds_Merchant_Order: orderNumber,
                Ds_Merchant_MerchantURL: Url.Action("Index", "Response", null, Request.Scheme),
                Ds_Merchant_UrlOK: $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Ok",
                Ds_Merchant_UrlKO: $"{HttpContext.Request.Scheme}://{HttpContext.Request.Host}/Ko")
            {
                Ds_Merchant_Paymethods = PaymentMethod.CreditCard
            };

            PaymentFormData formData = paymentRequestService.GetPaymentRequestFormData(
                paymentRequest: paymentRequest,
                merchantKey: secret.Key);

            RedsysRequest redsysRequest = new RedsysRequest { ConnectionUrl = secret.Url, Request = formData };
            return Ok(redsysRequest);
        }
    }
}
