using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public interface IMateryalService
    {
        List<Materyal> GetMateryaller();
        Materyal GetMateryalById(int id);

        void MateryalEkleGuncelle(MateryalDto input);
        void DeleteMateryalById(int id);
    }
}
