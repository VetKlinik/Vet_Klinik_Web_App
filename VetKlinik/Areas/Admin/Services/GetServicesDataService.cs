using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;
using VetKlinik.Areas.Admin.Services;
using Microsoft.EntityFrameworkCore;

namespace VetKlinik.Areas.Admin.Services
{
    public class GetServicesDataService : IGetServicesDataService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public GetServicesDataService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public async Task<List<Hizmetler>> GetServicesData()
        {
            return await _ApplicationDbContext.Hizmetler.ToListAsync();
        }

        //public Hizmetler GetHizmetlerById(int id)
        //{
        //    return _ApplicationDbContext.Hizmetler.Where(x => x.Id == id).FirstOrDefault();
        //}
    }
}
