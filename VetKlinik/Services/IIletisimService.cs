using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IIletisimService
    {
        IletisimBilgileri GetIletisimBilgileri();
        void IletisimBilgisiEkleGuncelle(IletisimBilgileriEkleGuncelleDto input);
        void DeleteIletisimBilgisiById(int id);

        //void ClearField();
        void DeleteIletisimBilgileri();

        IletisimBilgileri GetIletisimBilgileriById(int id);
    }
}
