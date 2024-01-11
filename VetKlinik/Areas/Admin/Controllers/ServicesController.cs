using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using VetKlinik.Dto;
using VetKlinik.Services;
using Microsoft.AspNetCore.Authorization;
using VetKlinik.Data;
using VetKlinik.Areas.Admin.Data;
using VetKlinik.Areas.Admin.Services;

namespace VetKlinik.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = UserRoles.Role_Admin)]
    public class ServicesController : Controller
    {
        private readonly IHizmetlerService _hizmetlerContext;
        private readonly IGetServicesDataService _getServicesDataService;

        public ServicesController(IHizmetlerService hizmetlerContext, IGetServicesDataService getServicesDataService)
        {
            _hizmetlerContext = hizmetlerContext;
            _getServicesDataService = getServicesDataService;
        }

        public IActionResult Index()
        {
            var hizmetler = _hizmetlerContext.GetHizmetler();

            ViewBag.hizmetler = hizmetler;

            return View(hizmetler);
        }
        public IActionResult Index1()
        {
            var hizmetler = _hizmetlerContext.GetHizmetler();

            return View(hizmetler);
        }

        //TODO TASK'A GEÇİŞ YAPILABİLİR MAYBE
        public async Task<IActionResult> GetServicesData()
        {
            var servicesData = await _getServicesDataService.GetServicesData();

            return View(servicesData);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(HizmetlerEkleGuncelleDto input)
        {
            _hizmetlerContext.HizmetlerEkleGuncelle(input);

            return RedirectToAction("Index1");
        }
        public IActionResult Guncelle(int id)
        {
            var hizmetler = _hizmetlerContext.GetHizmetlerById(id);

            if (hizmetler != null)
            {
                var model = new HizmetlerEkleGuncelleDto
                {
                    Id = hizmetler.Id,
                    Ad = hizmetler.Ad,
                    Aciklama = hizmetler.Aciklama,
                    Icon = hizmetler.Icon,
                };
                return View(model);
            }

            return View();
        }
        [HttpPost]
        public IActionResult Guncelle(HizmetlerEkleGuncelleDto input)
        {
            _hizmetlerContext.HizmetlerEkleGuncelle(input);

            return RedirectToAction("Index1");
        }
        public IActionResult Sil(int id)
        {
            _hizmetlerContext.DeleteHizmetById(id);
            return RedirectToAction("Index1");
        }

    }
}
