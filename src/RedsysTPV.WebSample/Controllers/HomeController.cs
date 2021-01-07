using Microsoft.AspNetCore.Mvc;
using RedsysTPV.WebSample.Models;
using System.Diagnostics;

namespace RedsysTPV.WebSample.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string MerchantCode, string MerchantOrder, decimal Amount)
        {
            return RedirectToAction("Index", "Request", new { merchantCode = MerchantCode, merchantOrder = MerchantOrder, amount = Amount });
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

    }
}