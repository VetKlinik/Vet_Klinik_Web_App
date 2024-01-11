using Microsoft.AspNetCore.Mvc;
using VetKlinik.Services;

namespace VetKlinik.Controllers
{
    public class ServicesController : Controller
    {
        private readonly IHizmetlerService _hizmetlerContext;

        public ServicesController(IHizmetlerService hizmetlerContext)
        {
            _hizmetlerContext = hizmetlerContext;
        }

        public IActionResult Index()
        {
            var hizmetler = _hizmetlerContext.GetHizmetler();

            ViewBag.hizmetler = hizmetler;

            return View(hizmetler);
        }
    }
}
