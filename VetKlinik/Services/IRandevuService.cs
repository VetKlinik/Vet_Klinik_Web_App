using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IRandevuService
    {
        List<Randevu> GetRandevular();
        Randevu GetRandevularById(int id);
        void DeleteRandevuById(int id);
        void RandevuEkleGuncelle(RandevuEkleGuncelleDto input);
    }
}
