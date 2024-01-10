using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Models;

namespace VetKlinik.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AppointmentController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
