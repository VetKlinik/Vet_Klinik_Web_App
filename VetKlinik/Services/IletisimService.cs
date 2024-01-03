using VetKlinik.Dto;
using VetKlinik.Data;
using VetKlinik.Models;

namespace VetKlinik.Services
{
    public class IletisimService : IIletisimService
    {
        private readonly ApplicationDbContext _ApplicationDbContext;

        public IletisimService(ApplicationDbContext ApplicationDbContext)
        {
            _ApplicationDbContext = ApplicationDbContext;
        }

        public void DeleteIletisimBilgisiById(int id)
        {
            var gelenIB = _ApplicationDbContext.IletisimBilgileri.Where(x => x.Id == id).FirstOrDefault();
            if (gelenIB != null)
            {
                _ApplicationDbContext.IletisimBilgileri.Remove(gelenIB);
                _ApplicationDbContext.SaveChanges();
            }
        }

        public IletisimBilgileri GetIletisimBilgileri()
        {
            return _ApplicationDbContext.IletisimBilgileri.FirstOrDefault();
        }

        public void IletisimBilgisiEkleGuncelle(IletisimBilgileriEkleGuncelleDto input)
        {
            if (!input.Id.HasValue)
            {
                IletisimBilgisiEkle(input);
            }
            else
            {
                IletisimBilgisiGuncelle(input);
            }
        }

        private void IletisimBilgisiGuncelle(IletisimBilgileriEkleGuncelleDto input)
        {
            var gelenIB = _ApplicationDbContext.IletisimBilgileri.Where(x => x.Id == input.Id).FirstOrDefault();
            if (gelenIB != null)
            {
                gelenIB.Adres = input.Adres;
                gelenIB.TelefonNumaralari = input.TelefonNumaralari;
                gelenIB.EmailAdresleri = input.EmailAdresleri;
                gelenIB.FacebookLink = input.FacebookLink;
                gelenIB.XLink = input.XLink;
                gelenIB.InstagramLink = input.InstagramLink;
                gelenIB.LinkedinLink = input.LinkedinLink;
                gelenIB.PinterestLink = input.PinterestLink;
                _ApplicationDbContext.IletisimBilgileri.Update(gelenIB);
                _ApplicationDbContext.SaveChanges();
            }
        }

        private void IletisimBilgisiEkle(IletisimBilgileriEkleGuncelleDto input)
        {
            _ApplicationDbContext.IletisimBilgileri.Add(new IletisimBilgileri
            {
                Adres = input.Adres,
                TelefonNumaralari = input.TelefonNumaralari,
                EmailAdresleri = input.EmailAdresleri,
                FacebookLink = input.FacebookLink,
                XLink = input.XLink,
                InstagramLink = input.InstagramLink,
                LinkedinLink = input.LinkedinLink,
                PinterestLink = input.PinterestLink
            });
            _ApplicationDbContext.SaveChanges();
        }
        /*
        public void ClearField()
        {
            var iletisimBilgileri = _ApplicationDbContext.IletisimBilgileri.FirstOrDefault();
            if (iletisimBilgileri != null)
            {
                iletisimBilgileri.XLink = null;
                iletisimBilgileri.LinkedinLink = null;
                iletisimBilgileri.PinterestLink = null;
                iletisimBilgileri.CepTelNo3 = null;
                iletisimBilgileri.EmailAdress1 = null;
                iletisimBilgileri.EmailAdress2 = null;
            }

            _ApplicationDbContext.SaveChanges();
        }*/

        public void DeleteIletisimBilgileri()
        {
            var gelenIletisimBilgileri = _ApplicationDbContext.IletisimBilgileri.FirstOrDefault();

            _ApplicationDbContext.IletisimBilgileri.Remove(gelenIletisimBilgileri);
            _ApplicationDbContext.SaveChanges();
        }

        public IletisimBilgileri GetIletisimBilgileriById(int id)
        {
            return _ApplicationDbContext.IletisimBilgileri.Where(x => x.Id == id).FirstOrDefault();
        }
    }
}
