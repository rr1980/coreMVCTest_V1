using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Main.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        [Authorize(Policy = "ReadPolicy")]
        public async Task<IActionResult> Index()
        {
            //_logger.LogWarning("loulou");
            //_logger.LogError("loulou");
            _logger.LogWarning(LoggingEvents.GET_ITEM, "Getting item {ID}", 1);
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View(); 
        }

        [Authorize(Policy = "AdminPolicy")]
        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


    }
}
