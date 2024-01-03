using System.ComponentModel;
using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface ISoruCevapService
    {
        List<SoruCevap> GetSoruCevaplar();
        SoruCevap GetSoruCevapById(int id);
        void DeleteSoruCevapById(int id);
        void SoruCevapEkleGuncelle(SoruCevapEkleGuncelleDto input);
    }
}
