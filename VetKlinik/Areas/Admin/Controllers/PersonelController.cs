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
    public class PersonelController : Controller
    {
        private readonly IPersonelService _personelService;

        public PersonelController(IPersonelService personelService)
        {
            _personelService = personelService;
        }
        public IActionResult Index()
        {
            var personeller = _personelService.GetPersoneller();

            return View(personeller);
        }
        public IActionResult Ekle()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Ekle(PersonelEkleGuncelleDto input)
        {
            _personelService.PersonelEkleGuncelle(input);

            return RedirectToAction("Index");
        }
        public IActionResult Guncelle(int id)
        {
            var personel = _personelService.GetPersonelById(id);

            if (personel != null)
            {
                var model = new PersonelEkleGuncelleDto
                {
                    Id = personel.Id,
                    Ad = personel.Ad,
                    Soyad = personel.Soyad,
                    Deneyim = personel.Deneyim,
                    Egitim = personel.Egitim,
                    Facebook = personel.Facebook,
                    FotoUrl = personel.FotoUrl,
                    Instagram = personel.Instagram,
                    LinkedIn = personel.LinkedIn,
                    UzmanlikAlani = personel.UzmanlikAlani,
                    Unvan = personel.Unvan,
                    X = personel.X
                };
                return View(model);
            }


            return View();
        }
        [HttpPost]
        public IActionResult Guncelle(PersonelEkleGuncelleDto input)
        {
            _personelService.PersonelEkleGuncelle(input);

            return RedirectToAction("Index");
        }
        public IActionResult Sil(int id)
        {
            _personelService.DeletePersonelById(id);
            return RedirectToAction("Index");
        }
    }
}
