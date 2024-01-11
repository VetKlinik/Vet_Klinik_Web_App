using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Areas.Admin.Data;
using VetKlinik.Dto;
using VetKlinik.Models;
using VetKlinik.Services;
using X.PagedList;

namespace VetKlinik.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ICommentsService _commentsContext;

        public ReviewController(ICommentsService commentsContext)
        {
            _commentsContext = commentsContext;
        }

        public IActionResult Index(int page = 1)
        {
            var comments = _commentsContext.GetComments().ToPagedList(page, 4);

            ViewBag.Comments = comments;

            return View(comments);
        }
        
        [Authorize(Roles = UserRoles.Role_Musteri)]
        public IActionResult Ekle()
        {
            return View(); 
        }

        [Authorize(Roles = UserRoles.Role_Musteri)]
        [HttpPost]
        public IActionResult Ekle(CommentsEkleGuncelleDto input)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            _commentsContext.CommentsEkleGuncelle(input);

            System.Threading.Thread.Sleep(1000);
            return RedirectToAction("Index");
        }
    }
}
