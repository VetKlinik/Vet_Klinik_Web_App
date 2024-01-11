using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Areas.Admin.Services
{
    public interface IGetServicesDataService
    {
        Task<List<Hizmetler>> GetServicesData();
        //Hizmetler GetHizmetlerById(int id);
    }
}
