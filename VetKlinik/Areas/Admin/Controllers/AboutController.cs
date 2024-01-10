using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Data;
using VetKlinik.Dto;
using VetKlinik.Models;
using VetKlinik.Services;

namespace VetKlinik.Areas.Admin.Controllers
{
    [Area("Admin")]
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
        //[Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Index1()
        {
            var gonderiler = _service.GetGonderiler();

            return View(gonderiler);
        }
        //[Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Ekle()
        {
            return View();
        }
        //[Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Ekle(GonderiEkleGuncelleDto input)
        {
            _service.GonderilerEkleGuncelle(input);
            return RedirectToAction("Index1");
        }
        //[Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(int id)
        {
            var gonderi = _service.GetGonderilerById(id);

            if (gonderi != null)
            {
                var model = new GonderiEkleGuncelleDto
                {
                    BaslikBir = gonderi.BaslikBir,
                    BaslikIki = gonderi.BaslikIki,
                    AltBaslik = gonderi.AltBaslik,
                    Icerik = gonderi.Icerik,
                    FotoUrl = gonderi.FotoUrl,
                    Height = gonderi.Height,
                    Width = gonderi.Width,
                };
                return View(model);
            }

            return View();
        }
        //[Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Guncelle(GonderiEkleGuncelleDto input)
        {
            _service.GonderilerEkleGuncelle(input);
            return RedirectToAction("Index1");
        }
        //[Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int id)
        {
            _service.DeleteGonderiById(id);
            return RedirectToAction("Index1");
        }



    }
}
