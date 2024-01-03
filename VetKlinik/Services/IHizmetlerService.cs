using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IHizmetlerService
    {
        List<Hizmetler> GetHizmetler();
        Hizmetler GetHizmetlerById(int id);
        void HizmetlerEkleGuncelle(HizmetlerEkleGuncelleDto input);
        void DeleteHizmetById(int id);
    }
}
