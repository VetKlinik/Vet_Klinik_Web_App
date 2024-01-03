using VetKlinik.Data;
using VetKlinik.Dto;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class GonderiService : IGonderiService
    {
        private readonly ApplicationDbContext _context;
        public GonderiService(ApplicationDbContext context)
        {
            _context = context;
        }

        public void DeleteGonderiById(int id)
        {
            var gelenGonderi = _context.Gonderiler.Where(x => x.Id == id).FirstOrDefault();
            if (gelenGonderi != null)
            {
                _context.Gonderiler.Remove(gelenGonderi);
                _context.SaveChanges();
            }
        }

        public List<Gonderi> GetGonderiler()
        {
            return _context.Gonderiler.OrderBy(x => x.Baslik).ToList();
        }

        public Gonderi GetGonderilerById(int id)
        {
            return _context.Gonderiler.Where(x => x.Id == id).FirstOrDefault();
        }

        public void GonderilerEkleGuncelle(GonderiEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                GonderiEkle(input);
            }

            else
            {
                GonderiGuncelle(input);
            }
        }
        private void GonderiEkle(GonderiEkleGuncelleDto input)
        {
            _context.Gonderiler.Add(new Gonderi
            {
                Baslik = input.Baslik,
                Icerik = input.Icerik,
                FotoUrl = input.FotoUrl,
            });
            _context.SaveChanges();
        }

        private void GonderiGuncelle(GonderiEkleGuncelleDto input)
        {
            var gelenGonderi = _context.Gonderiler.Where(x => x.Id == input.Id.Value).FirstOrDefault();
            if (gelenGonderi != null)
            {
                gelenGonderi.Baslik = input.Baslik;
                gelenGonderi.Icerik = input.Icerik;
                gelenGonderi.FotoUrl = input.FotoUrl;
                _context.Gonderiler.Update(gelenGonderi);
                _context.SaveChanges(); 
            }
        }

        
    }
}
