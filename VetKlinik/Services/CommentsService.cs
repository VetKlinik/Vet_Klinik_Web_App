using VetKlinik.Data;
using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class CommentsService : ICommentsService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public CommentsService(ApplicationDbContext applicationDbContext)
        {
            _ApplicationDbContext = applicationDbContext;
        }
        public void DeleteCommentById(int id)
        {
            var gelenComment = _ApplicationDbContext.Comments.Where(h => h.Id == id).FirstOrDefault();
            if (gelenComment != null)
            {
                _ApplicationDbContext.Comments.Remove(gelenComment);
                _ApplicationDbContext.SaveChanges();
            }
        }
        public List<Comments> GetComments()
        {
            return _ApplicationDbContext.Comments.OrderBy(x => x.Ad).ToList();
        }
        public Comments GetCommentsById(int id)
        {
            return _ApplicationDbContext.Comments.Where(x => x.Id == id).FirstOrDefault();
        }

        public void CommentsEkleGuncelle(CommentsEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                AddComment(input);
            }
            else
            {
                UpdateComment(input);
            }
        }

        private void AddComment(CommentsEkleGuncelleDto input)
        {
            _ApplicationDbContext.Comments.Add(new Comments
            {
                Ad = input.Ad,
                Yorum = input.Yorum,
                Puan = input.Puan,
            });
            _ApplicationDbContext.SaveChanges();
        }

        private void UpdateComment(CommentsEkleGuncelleDto input)
        {
            var currentComment = _ApplicationDbContext.Comments.Where(x => x.Id == input.Id.Value).FirstOrDefault();
            if (currentComment != null)
            {
                currentComment.Ad = input.Ad;
                currentComment.Yorum = input.Yorum;
                currentComment.Puan = input.Puan;
                _ApplicationDbContext.Comments.Update(currentComment);
                _ApplicationDbContext.SaveChanges();
            }
        }

    }
}
