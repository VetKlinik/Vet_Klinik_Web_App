using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VetKlinik.Dto;
using VetKlinik.Models;
using VetKlinik.Services;

namespace VetKlinik.Controllers
{
    public class ReviewController : Controller
    {
        private readonly ICommentsService _commentsContext;

        public ReviewController(ICommentsService commentsContext)
        {
            _commentsContext = commentsContext;
        }

        public IActionResult Index()
        {
            var comments = _commentsContext.GetComments();

            ViewBag.Comments = comments;

            return View(comments);
        }

        public IActionResult Index1()
        {
            var comments = _commentsContext.GetComments();

            return View(comments);
        }

        public IActionResult Ekle()
        {
            return View(); 
        }

        [HttpPost]
        public IActionResult Ekle(CommentsEkleGuncelleDto input)
        {
            _commentsContext.CommentsEkleGuncelle(input);

            System.Threading.Thread.Sleep(1000);
            return RedirectToAction("Index1");
        }

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

        [HttpPost]
        public IActionResult Guncelle(CommentsEkleGuncelleDto input)
        {
            _commentsContext.CommentsEkleGuncelle(input);
            return RedirectToAction("Index1");
        }

        public IActionResult Sil(int id)
        {
            _commentsContext.DeleteCommentById(id);
            return RedirectToAction("Index1");
        }

    }
}
