using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class MateryalService : IMateryalService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public MateryalService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeleteMateryalById(int id)
        {
            var gelenMateryal = _ApplicationDbContext.Materyaller.Where(x => x.Id == id).FirstOrDefault();
            if (gelenMateryal != null)
            {
                _ApplicationDbContext.Materyaller.Remove(gelenMateryal);
                _ApplicationDbContext.SaveChanges();
            }
        }

        public Materyal GetMateryalById(int id)
        {
            return _ApplicationDbContext.Materyaller.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Materyal> GetMateryaller()
        {
            return _ApplicationDbContext.Materyaller.OrderBy(x => x.Baslik).ToList();
        }

        public void MateryalEkleGuncelle(MateryalDto input)
        {
            if (!input.Id.HasValue)
            {
                MateryalEkle(input);
            }
            else
            {
                MateryalGuncelle(input);
            }
        }

        private void MateryalGuncelle(MateryalDto input)
        {
            var gelenMateryal = _ApplicationDbContext.Materyaller.Where(x => x.Id == input.Id.Value).FirstOrDefault();
            if(gelenMateryal != null)
            {
                gelenMateryal.Cevap=input.Cevap;
                gelenMateryal.Icerik=input.Icerik;
                gelenMateryal.Kategori=input.Kategori;
                gelenMateryal.Baslik=input.Baslik;
                _ApplicationDbContext.Materyaller.Update(gelenMateryal);
                _ApplicationDbContext.SaveChanges();
            }
        }

        private void MateryalEkle(MateryalDto input)
        {
            _ApplicationDbContext.Materyaller.Add(new Materyal
            {
                PersonelId = input.PersonelId,
                MusteriId = input.MusteriId,
                Baslik = input.Baslik,
                Cevap = input.Cevap,
                Icerik = input.Icerik,
                Kategori = input.Kategori,
            });
        }
    }
}
