using Microsoft.EntityFrameworkCore;
using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class PersonelService : IPersonelService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public PersonelService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeletePersonelById(int id)
        {
            var gelenPersonel = _ApplicationDbContext.Personeller.Where(x =>  x.Id == id).FirstOrDefault();
            if (gelenPersonel != null)
            {
                _ApplicationDbContext.Personeller.Remove(gelenPersonel);
                _ApplicationDbContext.SaveChanges();
            }
        }
        
        public List<Personel> GetDoktors()
        {
            var doktorUnvanlar = new List<PersonelUnvan>
    {
        PersonelUnvan.VeterinerTeknisyen,
        PersonelUnvan.VeterinerAsistan,
        PersonelUnvan.VeterinerUzmanHekim,
        PersonelUnvan.VeterinerHekim
    };

            var doktors = _ApplicationDbContext.Personeller
                .Where(p => doktorUnvanlar.Contains(p.Unvan))
                .ToList();

            return doktors;
        }
        



        public Personel GetPersonelById(int id)
        {
            return _ApplicationDbContext.Personeller.Where(x => x.Id == id).FirstOrDefault();
        }

        public List<Personel> GetPersonelByUnvan(PersonelUnvan unvan)
        {
            return _ApplicationDbContext.Personeller.Where(x => x.Unvan==unvan).ToList();
        }

        public List<Personel> GetPersoneller()
        {
            return _ApplicationDbContext.Personeller.OrderBy(x => x.Ad).ToList();
        }

        public int GetVeterinerUzmanHekimCount()
        {
            int veterinerUzmanHekimCount = _ApplicationDbContext.Personeller
    .Count(p => p.Unvan == PersonelUnvan.VeterinerUzmanHekim);

            return veterinerUzmanHekimCount;
        }

        public void PersonelEkleGuncelle(PersonelEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                PersonelEkle(input);
            }
            else
            {
                PersonelGuncelle(input);
            }
        }

        public int GetVeterinerAsistanCount()
        {
            int veterinerAsistanCount = _ApplicationDbContext.Personeller
    .Count(p => p.Unvan == PersonelUnvan.VeterinerAsistan);

            return veterinerAsistanCount;
        }

        public int GetVeterinerHekimCount()
        {
            int veterinerHekimCount = _ApplicationDbContext.Personeller
    .Count(p => p.Unvan == PersonelUnvan.VeterinerHekim);

            return veterinerHekimCount;
        }

        public int GetVeterinerTeknisyenCount()
        {
            int veterinerTeknisyenCount = _ApplicationDbContext.Personeller
    .Count(p => p.Unvan == PersonelUnvan.VeterinerTeknisyen);

            return veterinerTeknisyenCount;
        }

        private void PersonelEkle(PersonelEkleGuncelleDto input)
        {
            _ApplicationDbContext.Personeller.Add(new Personel
            {
                Ad = input.Ad,
                Soyad = input.Soyad,
                Deneyim = input.Deneyim,
                UzmanlikAlani = input.UzmanlikAlani,
                Egitim = input.Egitim,
                FotoUrl = input.FotoUrl,
                Unvan = input.Unvan,
                Facebook = input.Facebook,
                Instagram = input.Instagram,
                LinkedIn = input.LinkedIn,
                X = input.X,
            });
            _ApplicationDbContext.SaveChanges();
        }

        private void PersonelGuncelle(PersonelEkleGuncelleDto input)
        {
            var gelenPersonel = _ApplicationDbContext.Personeller.Where(x => x.Id==input.Id.Value).FirstOrDefault();
            if (gelenPersonel != null)
            {
                gelenPersonel.Deneyim = input.Deneyim;
                gelenPersonel.Egitim = input.Egitim;
                gelenPersonel.Soyad = input.Soyad;
                gelenPersonel.Ad = input.Ad;
                gelenPersonel.FotoUrl = input.FotoUrl;
                gelenPersonel.UzmanlikAlani = input.UzmanlikAlani;
                gelenPersonel.Unvan = input.Unvan;
                gelenPersonel.LinkedIn = input.LinkedIn;
                gelenPersonel.Instagram = input.Instagram;
                gelenPersonel.X = input.X;
                gelenPersonel.Facebook = input.Facebook;
            }
            _ApplicationDbContext.SaveChanges();
        }
    }
}
