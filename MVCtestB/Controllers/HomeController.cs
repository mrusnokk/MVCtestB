using Microsoft.AspNetCore.Mvc;
using MVCtestB.Models;
using System.Diagnostics;

namespace MVCtestB.Controllers
{
    public class HomeController : Controller
    {
        public Api _api = new Api();
        public dbService _db = new dbService();
        public async Task<IActionResult> Index()
        {
            
            ViewBag.kurzy = await _api.getJson();
            return View(new MainFormModel());
        }
        [HttpPost]
        public async Task<IActionResult> Index(MainFormModel model)
        {
            if (!ModelState.IsValid)
            {
                ViewBag.kurzy = await _api.getJson();
                return View(model);
            }

            ViewBag.kurzy = await _api.getJson();

            _db.Insert(model);
            return RedirectToAction("Privacy");

        }

        public async Task<IActionResult> Privacy()
        {
            ViewBag.select = _db.Get();
            ViewBag.kurzy = await _api.getJson();
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
