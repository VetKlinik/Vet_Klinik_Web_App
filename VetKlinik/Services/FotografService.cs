using Microsoft.EntityFrameworkCore;
using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class FotografService : IFotografService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public FotografService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeleteFotobyId(int id)
        {
            var gelenFotograf = _ApplicationDbContext.Fotograflar.Where(x => x.Id == id).FirstOrDefault();

            if (gelenFotograf != null)
            {
                _ApplicationDbContext.Fotograflar.Remove(gelenFotograf);
                _ApplicationDbContext.SaveChanges();
            }
        }


        public void FotografEkleGuncelle(FotografEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                FotoEkle(input);
            }
            else
            {
                FotoGuncelle(input);
            }
        }

        private void FotoGuncelle(FotografEkleGuncelleDto input)
        {
            var mevcutFoto = _ApplicationDbContext.Fotograflar
                .Where(x => x.Id == input.Id.Value)
                .FirstOrDefault();

            if (mevcutFoto != null)
            {
                mevcutFoto.FotografUrl = input.FotografUrl;
                mevcutFoto.Aciklama = input.Aciklama;
                
                _ApplicationDbContext.Fotograflar.Update(mevcutFoto);
                _ApplicationDbContext.SaveChanges();
            }
        }

        private void FotoEkle(FotografEkleGuncelleDto input)
        {
            _ApplicationDbContext.Fotograflar.Add(new Fotograf
            {
                Aciklama = input.Aciklama,
                FotografUrl = input.FotografUrl
            });

            _ApplicationDbContext.SaveChanges();
        }

        public Fotograf GetFotobyId(int id)
        {
            return _ApplicationDbContext.Fotograflar.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
