using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IPersonelService
    {
        List<Personel> GetPersoneller();
        Personel GetPersonelById(int id);
        void PersonelEkleGuncelle(PersonelEkleGuncelleDto input);
        void DeletePersonelById(int id);

        List<Personel> GetPersonelByUnvan(PersonelUnvan unvan);

        int GetVeterinerUzmanHekimCount();
        int GetVeterinerHekimCount();
        int GetVeterinerTeknisyenCount();
        int GetVeterinerAsistanCount();

        List<Personel> GetDoktors();

    }
}
