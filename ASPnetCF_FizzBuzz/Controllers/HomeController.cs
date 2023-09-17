using ASPnetCF_FizzBuzz.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ASPnetCF_FizzBuzz.Controllers
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
            return View();
        }

        [HttpGet]
        public IActionResult FBPage()
        {
            FizzBuzz model = new();

            model.FizzNum = 3;
            model.BuzzNum = 5;

            return View(model);
        }

        [HttpPost]
        [AutoValidateAntiforgeryToken]
        public IActionResult FBPage(FizzBuzz fizzBuzz)
        {
            List<string> fbItems = new();

            bool fizz;
            bool buzz;


            for (int i = 1; i <= 100; i++)
            {
                fizz = i % fizzBuzz.FizzNum == 0;
                buzz = i % fizzBuzz.BuzzNum == 0;

                if (fizz == true && buzz == true)
                {
                    fbItems.Add("FizzBuzz");
                }
                else if (fizz == true)
                {
                    fbItems.Add("Fizz");
                }
                else if (buzz == true)
                {
                    fbItems.Add("Buzz");
                }
                else
                {
                    fbItems.Add(i.ToString());
                }
            }
            fizzBuzz.Records = fbItems;

            return View(fizzBuzz);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}