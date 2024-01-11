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
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Index1()
        {
            var comments = _commentsContext.GetComments();

            return View(comments);
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Ekle()
        {
            return View(); 
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Ekle(CommentsEkleGuncelleDto input)
        {
            if (!ModelState.IsValid)
            {
                return View("Ekle");
            }
            _commentsContext.CommentsEkleGuncelle(input);

            System.Threading.Thread.Sleep(1000);
            return RedirectToAction("Index1");
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Guncelle(int id)
        {
            var comments = _commentsContext.GetCommentsById(id);

            if (comments != null)
            {
                var model = new CommentsEkleGuncelleDto
                {
                    Id = comments.Id,
                    Ad = comments.Ad,
                    Yorum = comments.Yorum,
                    Puan = comments.Puan,
                };
                return View(model);
            }
            return View();
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        [HttpPost]
        public IActionResult Guncelle(CommentsEkleGuncelleDto input)
        {
            _commentsContext.CommentsEkleGuncelle(input);
            return RedirectToAction("Index1");
        }
        [Authorize(Roles = UserRoles.Role_Admin)]
        public IActionResult Sil(int id)
        {
            _commentsContext.DeleteCommentById(id);
            return RedirectToAction("Index1");
        }

    }
}
