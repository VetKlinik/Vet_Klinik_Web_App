using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Models;
using VetKlinik.Dto;
using VetKlinik.Services;
using Microsoft.AspNetCore.Authorization;
using VetKlinik.Data;
using VetKlinik.Areas.Admin.Data;

namespace VetKlinik.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class IletisimBilgileriController : Controller
    {
        private readonly IIletisimService _service;

        public IletisimBilgileriController(IIletisimService service)
        {
            _service = service;
        }
        public IActionResult Index()
        {
            var IB = _service.GetIletisimBilgileri;
            var asd = new IletisimBilgileri()
            {
                Adres = "asd",
                XLink = "asd",
                LinkedinLink = "asd",
                FacebookLink = "asd",
                PinterestLink = "asd",
                InstagramLink = "asd",
                TelefonNumaralari = ["asd"],
                EmailAdresleri = ["asd"],
            };

            return View(asd);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(IletisimBilgileriEkleGuncelleDto input)
        {
            _service.IletisimBilgisiEkleGuncelle(input);

            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var IB = _service.GetIletisimBilgileriById(id);

            if (IB != null)
            {
                var model = new IletisimBilgileriEkleGuncelleDto
                {
                    Adres = IB.Adres,
                    TelefonNumaralari = IB.TelefonNumaralari,
                    EmailAdresleri = IB.EmailAdresleri,
                    FacebookLink = IB.FacebookLink,
                    XLink = IB.XLink,
                    InstagramLink = IB.InstagramLink,
                    LinkedinLink = IB.LinkedinLink,
                    PinterestLink = IB.PinterestLink
                };

                return View(model);
            }

            return View();
        }
        [HttpPost]
        public IActionResult Guncelle(IletisimBilgileriEkleGuncelleDto input)
        {
            _service.IletisimBilgisiEkleGuncelle(input);

            return RedirectToAction("Index");
        }
        public IActionResult Temizle()
        {
            //_service.ClearField();
            return RedirectToAction("Index");
        }
        public IActionResult Sil()
        {
            _service.DeleteIletisimBilgileri();
            return RedirectToAction("Index");
        }
    }
}
