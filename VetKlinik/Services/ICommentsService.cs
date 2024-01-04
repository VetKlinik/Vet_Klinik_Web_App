using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface ICommentsService
    {
        List<Comments> GetComments();
        Comments GetCommentsById(int id);
        void CommentsEkleGuncelle(CommentsEkleGuncelleDto input);
        void DeleteCommentById(int id);
    }
}
