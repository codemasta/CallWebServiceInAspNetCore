using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CallWebService.Core;
using Microsoft.AspNetCore.Mvc;

namespace CallWebService.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICalculatorService _calculatorService;

        public HomeController(ICalculatorService calculatorService)
        {
            _calculatorService = calculatorService;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(int firstNumber , int secondNumber)
        {
            var result = _calculatorService.Add(firstNumber, secondNumber);
            ViewBag.Result = $"{firstNumber} + {secondNumber} = {result}";
            return View();
        }
    }
}
