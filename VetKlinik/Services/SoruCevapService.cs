using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class SoruCevapService : ISoruCevapService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public SoruCevapService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeleteSoruCevapById(int id)
        {
            var gelenSoruCevap = _ApplicationDbContext.SoruCevaplar.Where(x => x.Id == id).FirstOrDefault();
            _ApplicationDbContext.SoruCevaplar.Remove(gelenSoruCevap);
            _ApplicationDbContext.SaveChanges();
        }

        public SoruCevap GetSoruCevapById(int id)
        {
            return _ApplicationDbContext.SoruCevaplar.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<SoruCevap> GetSoruCevaplar()
        {
            return _ApplicationDbContext.SoruCevaplar.OrderBy(x => x.Kategori).ToList();
        }

        public void SoruCevapEkleGuncelle(SoruCevapEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                SoruCevapEkle(input);
            }
            else
            {
                SoruCevapGuncelle(input);
            }
        }

        private void SoruCevapGuncelle(SoruCevapEkleGuncelleDto input)
        {
            var gelenSoruCevap = _ApplicationDbContext.SoruCevaplar.Where(x => x.Id==input.Id.Value).FirstOrDefault();
            if (gelenSoruCevap != null)
            {
                gelenSoruCevap.Cevap=input.Cevap;
                gelenSoruCevap.Soru=input.Soru;
                gelenSoruCevap.Kategori=input.Kategori;
                gelenSoruCevap.MusteriId=input.MusteriId;
                gelenSoruCevap.PersonelId=input.PersonelId;
            }
            _ApplicationDbContext.SaveChanges();
        }

        private void SoruCevapEkle(SoruCevapEkleGuncelleDto input)
        {
            _ApplicationDbContext.SoruCevaplar.Add(new SoruCevap
            {
                Soru=input.Soru,
                Cevap=input.Cevap,
                Kategori=input.Kategori,
                MusteriId=input.MusteriId,
                PersonelId=input.PersonelId
            });
            _ApplicationDbContext.SaveChanges();
        }
    }
}
