using Microsoft.AspNetCore.Mvc;
using System;
using System.Diagnostics;
using System.Reflection.Emit;
using Test.Models;

namespace Test.Controllers
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
            DatabaseManager dbManager = new DatabaseManager();
            List<Card> cards = dbManager.GetData();
            ViewBag.cards = cards;
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
        public IActionResult CreateNewData()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CreateNewData(Card card)
        {
            DatabaseManager dbmanager = new DatabaseManager();
            try
            {
                dbmanager.NewData(card);
            }
            catch
            {
                Console.WriteLine(double.E.ToString());
            }
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
