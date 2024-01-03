using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class RandevuService : IRandevuService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public RandevuService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeleteRandevuById(int id)
        {
            var gelenRandevu = _ApplicationDbContext.Randevular.Where(x => x.Id == id).FirstOrDefault();
            if(gelenRandevu!=null)
            {
                _ApplicationDbContext.Randevular.Remove(gelenRandevu);
            }
            

        }

        public List<Randevu> GetRandevular()
        {
            return _ApplicationDbContext.Randevular.OrderBy(x => x.Tarih).ToList();
        }

        public Randevu GetRandevularById(int id)
        {
            return _ApplicationDbContext.Randevular.Where(x => x.Id == id).FirstOrDefault();
        }

        public void RandevuEkleGuncelle(RandevuEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                EkleRandevu(input);
            }
            else
            {
                GuncelleRandevu(input);
            }
        }

        private void EkleRandevu(RandevuEkleGuncelleDto input)
        {
            _ApplicationDbContext.Randevular.Add(new Randevu
            {
                Durum = input.Durum,
                MusteriId = input.MusteriId,
                PersonelId = input.PersonelId,
                Tarih = input.Tarih,
            });
            _ApplicationDbContext.SaveChanges();
        }

        private void GuncelleRandevu(RandevuEkleGuncelleDto input)
        {
            var gelenRandevu = _ApplicationDbContext.Randevular.Where(x => x.Id==input.Id.Value).FirstOrDefault();
            if (gelenRandevu != null)
            {
                gelenRandevu.Durum = input.Durum;
                gelenRandevu.Tarih = input.Tarih;
                gelenRandevu.MusteriId = input.MusteriId;
                gelenRandevu.PersonelId = input.PersonelId;
            }
            _ApplicationDbContext.SaveChanges();
        }
    }
}
