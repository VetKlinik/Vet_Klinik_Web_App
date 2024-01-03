using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Models;
using VetKlinik.Services;


namespace VetKlinik.Controllers
{
    public class DoctorsController : Controller
    {
        private readonly IPersonelService _personelService;

        public DoctorsController(IPersonelService personelService)
        {
            _personelService = personelService;
        }

        public IActionResult Index()
        {
            List<DoktorlarViewModel> doktorlarListesi = new List<DoktorlarViewModel>();

            var doktorlar = _personelService.GetDoktors();

            foreach (var doktor in doktorlar)
            {
                DoktorlarViewModel doktorViewModel = new DoktorlarViewModel
                {
                    Ad = doktor.Ad,
                    Soyad = doktor.Soyad,
                    Unvan = doktor.Unvan,
                    Facebook = doktor.Facebook,
                    X = doktor.X,
                    Instagram = doktor.Instagram,
                    LinkedIn = doktor.LinkedIn,
                    FotoUrl = doktor.FotoUrl
                };

                doktorlarListesi.Add(doktorViewModel);
            }

            return View(doktorlarListesi);
        }
    }
}
