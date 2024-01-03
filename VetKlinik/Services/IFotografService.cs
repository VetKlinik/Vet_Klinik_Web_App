using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IFotografService
    {
        void FotografEkleGuncelle(FotografEkleGuncelleDto input);

        Fotograf GetFotobyId(int id);

        void DeleteFotobyId(int id);
    }
}
