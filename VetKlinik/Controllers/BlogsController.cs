using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Models;

namespace VetKlinik.Controllers
{
    public class BlogsController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
