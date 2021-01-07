using System;
using System.Configuration;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using RedsysTPV.Helpers;
using RedsysTPV.WebSample.Models;

namespace RedsysTPV.WebSample.Controllers
{
    public class ResponseController : Controller
    {
        private readonly IConfiguration _configuration;
        private readonly IWebHostEnvironment _hostingEnvironment;
        private readonly ILogger<ResolveEventArgs> _logger;
        public ResponseController(IConfiguration configuration, IWebHostEnvironment hostingEnvironment, ILogger<ResolveEventArgs> logger)
        {
            _configuration = configuration;
            _hostingEnvironment = hostingEnvironment;
            _logger = logger;
        }
        // GET: Response
        public ActionResult Index()
        {
            var model = new ResponseViewModel();

            LogToFile(String.Format("Date: {0}", DateTime.Now));

            try
            {
                var secrets = _configuration.GetSection("Secrets");

                var paymentResponseService = new PaymentResponseService();

                var merchantParameters = Convert.ToString(this.Request.Query["Ds_MerchantParameters"]);
                var merchantKey = secrets["key"];
                var platformSignature = Convert.ToString(this.Request.Query["Ds_Signature"]);

                var processedPayment = paymentResponseService.GetProcessedPayment(merchantParameters, merchantKey, platformSignature);

                LogToFile(String.Format("IsValidSignature: {0}", processedPayment.IsValidSignature));
                LogToFile(String.Format("IsPaymentPerformed: {0}", processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single()));
                merchantParameters = merchantParameters.Replace('-', '+').Replace('_', '/');
                var json = WebUtility.UrlDecode(Base64.DecodeUtf8From64(merchantParameters));
                LogToFile(json);
                LogToFile(String.Format("PaymentResponse.Ds_Response: {0}", processedPayment.PaymentResponse.Ds_Response));
                LogToFile(String.Format("PaymentResponse.Ds_Order: {0}", processedPayment.PaymentResponse.Ds_Order));


                if (processedPayment.IsValidSignature)
                {
                    // Signature is correct, the request come from trusted source

                    if (processedPayment.IsPaymentPerformed.DefaultIfEmpty(false).Single())
                    {
                        // Payment accepted: success
                        // Update the order on database, etc
                        LogToFile("PAGO REALIZADO CORRECTAMENTE");
                    }
                    else
                    {
                        // Payment rejected: fail
                        // Update the order on database, etc
                        LogToFile("PAGO NO REALIZADO");
                    }
                }
                else
                {
                    // Signature is not valid, the request come from untrusted source
                }
                LogToFile("---");

                model = new ResponseViewModel()
                {
                    AuthorisationCode = processedPayment.PaymentResponse.Ds_AuthorisationCode,
                    Date = DateTime.Parse($"{processedPayment.PaymentResponse.Ds_Date} {processedPayment.PaymentResponse.Ds_Hour}"),
                    Amount = processedPayment.PaymentResponse.Ds_Amount,
                    CardNumber = processedPayment.PaymentResponse.Ds_Card_Number,
                    ExpiryDate = processedPayment.PaymentResponse.Ds_ExpiryDate
                };
            }
            catch (Exception ex)
            {
                LogToFile(String.Format("Error: {0}", ex.Message));
            }
            return View(model);
        }

        private void LogToFile(string message)
        {
            _logger.LogInformation(message);
            System.IO.StreamWriter sw = null;
            try
            {
                sw = new System.IO.StreamWriter(Path.Combine(_hostingEnvironment.WebRootPath, "log.txt"), true, encoding: Encoding.UTF8);
                sw.WriteLine(message);
            }
            catch (Exception) { }
            finally
            {
                if (sw != null)
                {
                    sw.Close();
                    sw.Dispose();
                }
            }
        }
    }
}