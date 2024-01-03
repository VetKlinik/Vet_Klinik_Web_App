using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class HizmetlerService : IHizmetlerService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;
        public HizmetlerService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeleteHizmetById(int id)
        {
            var gelenHizmet = _ApplicationDbContext.Hizmetler.Where(h => h.Id == id).FirstOrDefault();
            if (gelenHizmet != null)
            {
                _ApplicationDbContext.Hizmetler.Remove(gelenHizmet);
                _ApplicationDbContext.SaveChanges();
            }
        }

        public List<Hizmetler> GetHizmetler()
        {
            return _ApplicationDbContext.Hizmetler.OrderBy(x => x.Ad).ToList();
        }

        public Hizmetler GetHizmetlerById(int id)
        {
            return _ApplicationDbContext.Hizmetler.Where(x => x.Id == id).FirstOrDefault();
        }

        public void HizmetlerEkleGuncelle(HizmetlerEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                HizmetEkle(input);
            }
            else
            {
                HizmetGuncelle(input);
            }
        }

        private void HizmetEkle(HizmetlerEkleGuncelleDto input)
        {
            _ApplicationDbContext.Hizmetler.Add(new Hizmetler
            {
                Aciklama = input.Aciklama,
                Ad = input.Ad,
                Icon = input.Icon,
            });
            _ApplicationDbContext.SaveChanges();
        }

        private void HizmetGuncelle(HizmetlerEkleGuncelleDto input)
        {
            var mevcutHizmet = _ApplicationDbContext.Hizmetler.Where(x => x.Id == input.Id.Value).FirstOrDefault();
            if (mevcutHizmet != null)
            {
                mevcutHizmet.Aciklama=input.Aciklama;
                mevcutHizmet.Ad=input.Ad;
                mevcutHizmet.Icon=input.Icon;
                _ApplicationDbContext.Hizmetler.Update(mevcutHizmet);
                _ApplicationDbContext.SaveChanges();
            }
        }
    }
}
