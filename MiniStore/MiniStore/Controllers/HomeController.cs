﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MiniStore.Models;
using System.Diagnostics;

namespace MiniStore.Controllers
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
        public IActionResult About()
        {
            return View();
        }
        [HttpGet("shop-single.cshtml")]
        public IActionResult Shop()
        {

            return View();
        }



        [HttpGet]
        public IActionResult Contact()
        {
            return View();
        }

        //[HttpPost]
        //public IActionResult Contact()
        //{
        //    return View();
        //}


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
