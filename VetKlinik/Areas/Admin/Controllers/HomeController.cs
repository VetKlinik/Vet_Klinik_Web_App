using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using VetKlinik.Areas.Admin.Data;

namespace VetKlinik.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Index()
        {
            return View();
        }
    }
}
