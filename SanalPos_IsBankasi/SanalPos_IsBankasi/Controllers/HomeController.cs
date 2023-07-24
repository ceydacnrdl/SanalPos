using Microsoft.AspNetCore.Mvc;
using SanalPos_IsBankasi.Models;
using System.Diagnostics;
using SamProject.Models;
using System.Security.Cryptography;

using System.Text;

namespace SanalPos_IsBankasi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }


        public IActionResult Index()
        {
            string clientId = "700655000100";
            string oid = Guid.NewGuid().ToString();
            string amount = "1000";
            string okUrl = "http://127.0.0.1:8000/response.php";
            string failUrl = "http://127.0.0.1:8000/response.php";
            string rnd = Guid.NewGuid().ToString().Substring(0, 20);
            string taksit = "2";
            string islemtipi = "Auth";

            string hashStr = string.Concat(clientId, oid, amount, okUrl, failUrl, islemtipi, taksit, rnd, "TRPS0100");
            string hash = CalculateSHA1Hash(hashStr);

            var viewModel = new SanalPosModel()
            {
                ClientId = clientId,
                Oid = oid,
                Amount = amount,
                OkUrl = okUrl,
                FailUrl = failUrl,
                Rnd = rnd,
                Taksit = taksit,
                Islemtipi = islemtipi,
                Hash = hash
            };

            return View(viewModel);
        }
        protected string CalculateSHA1Hash(string input)
        {
            using (SHA1 sha1 = SHA1.Create())
            {
                byte[] bytes = Encoding.UTF8.GetBytes(input);
                byte[] hashBytes = sha1.ComputeHash(bytes);
                return Convert.ToBase64String(hashBytes);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}