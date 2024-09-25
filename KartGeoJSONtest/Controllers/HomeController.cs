using KartGeoJSONtest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace KartGeoJSONtest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        private static List<PositionModel> positions = new List<PositionModel>();

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult CorrectMap()
        {
            return View();
        }

        public IActionResult CorrectionOverview()
        {
            return View(positions);
        }

        [HttpPost]
        public IActionResult CorrectMap(PositionModel position)
        {
            if (ModelState.IsValid)
            {
                positions.Add(position);

                return View("CorrectionOverview", positions);
            }
            return View(); 
        }

        public IActionResult CorrectionList()
        {
            return View(positions);
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
