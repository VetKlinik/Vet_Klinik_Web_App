using Microsoft.AspNetCore.Mvc;
using VetKlinik.Services;

namespace VetKlinik.Controllers
{
    public class AboutController : Controller
    {
        private readonly IGonderiService _service;
        public AboutController(IGonderiService service)
        {
            _service = service;
        }

        public IActionResult Index()
        {
            var gonderiler = _service.GetGonderiler();

            return View(gonderiler);
        }
    }
}
