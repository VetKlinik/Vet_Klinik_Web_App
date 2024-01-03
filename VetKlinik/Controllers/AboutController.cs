using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Dto;
using VetKlinik.Models;
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
            return View();
        }

        public IActionResult Index1()
        {
            var gonderiler = _service.GetGonderiler();

            return View(gonderiler);
        }

        public IActionResult Ekle() 
        { 
            return View(); 
        }
        [HttpPost]
        public IActionResult Ekle(GonderiEkleGuncelleDto input)
        {
            _service.GonderilerEkleGuncelle(input);
            return RedirectToAction("Index1");
        }

        public IActionResult Guncelle(int id)
        {
            var gonderi = _service.GetGonderilerById(id);

            if(gonderi != null)
            {
                var model = new GonderiEkleGuncelleDto
                {
                    Baslik = gonderi.Baslik,
                    Icerik = gonderi.Icerik,
                    FotoUrl = gonderi.FotoUrl,
                };
                return View(model);
            }

            return View();
        }
        [HttpPost]
        public IActionResult Guncelle(GonderiEkleGuncelleDto input)
        {
            _service.GonderilerEkleGuncelle(input);
            return View();
        }
        public IActionResult Sil(int id)
        {
            _service.DeleteGonderiById(id);
            return RedirectToAction("Index1");
        }



    }
}
