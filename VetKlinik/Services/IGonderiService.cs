using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IGonderiService
    {
        List<Gonderi> GetGonderiler();
        Gonderi GetGonderilerById(int id);
        void GonderilerEkleGuncelle(GonderiEkleGuncelleDto input);
        void DeleteGonderiById(int id);
    }
}
