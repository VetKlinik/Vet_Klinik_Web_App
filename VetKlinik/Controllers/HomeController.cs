using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Models;
using VetKlinik.Services;

namespace VetKlinik.Controllers
{
    public class HomeController : Controller
    {
        //private readonly ILogger<HomeController> _logger;
        private readonly IPersonelService _personelService;
        private readonly IIletisimService _iletisimService;
        private readonly IHizmetlerService _hizmetlerService;

        public HomeController(ILogger<HomeController> logger, IPersonelService personelService, IIletisimService iletisimService, IHizmetlerService hizmetlerService)
        {
            //_logger = logger;
            _personelService = personelService;
            _iletisimService = iletisimService;
            _hizmetlerService = hizmetlerService;
        }

        public IActionResult Index(int personelId = -1)
        {
            var personeller = _personelService.GetPersoneller();
            personeller.Insert(0, new Personel { Id = -1, Ad = "Tümü" });

            var VetAsistant = _personelService.GetVeterinerAsistanCount();
            var VetTeknisyen = _personelService.GetVeterinerTeknisyenCount();
            var VetHekim = _personelService.GetVeterinerHekimCount();
            var VetUzmanHekim = _personelService.GetVeterinerUzmanHekimCount();

            ViewBag.VetAsistantCount = VetAsistant;
            ViewBag.VetTeknisyenCount = VetTeknisyen;
            ViewBag.VetHekimCount = VetHekim;
            ViewBag.VetUzmanHekimCount = VetUzmanHekim;

            var iletisimBilgileri = _iletisimService.GetIletisimBilgileri();
            ViewBag.iletisimBilgileri = iletisimBilgileri;

            var hizmetler = _hizmetlerService.GetHizmetler();
            ViewBag.hizmetler = hizmetler;

            

            return View();
        }


        

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
