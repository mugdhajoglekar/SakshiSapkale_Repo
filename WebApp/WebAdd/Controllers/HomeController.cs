
namespace WebAdd.Controllers
{
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.Extensions.Logging;
    using System;
    using System.Collections.Generic;
    using System.Diagnostics;
    using System.Linq;
    using System.Threading.Tasks;
    using WebAdd.Models;
    using calculateLib;
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
        [HttpPost]
        public IActionResult Index(calculator cal)
        {
            int a, b;
            a = cal.value1;
            b = cal.value2;
           
            if (cal.calculate == "sub")
            {
                cal.result = Calculate.Subtraction(a,b);
            }
            else if (cal.calculate == "mul")
            {
                cal.result = Calculate.Multiplication(a, b);
            }
            else if (cal.calculate == "div")
            {
                cal.result = Calculate.Division(a, b);
            }
            else
            {
                cal.result = Calculate.Adition(a, b);
            }
            ViewData["result"]=cal.result;
            return View();
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
