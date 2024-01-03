using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IMusteriService
    {
        List<Musteri> GetMusteriler();
        Musteri GetMusteriById(int id);
        void MusteriEkleGuncelle(MusteriEkleGuncelleDto input);
        void DeleteMusteriById(int id);
    }
}
