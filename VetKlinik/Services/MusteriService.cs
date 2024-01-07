//using Microsoft.IdentityModel.Tokens;
//using VetKlinik.Dto;
//using VetKlinik.Data;
//using VetKlinik.Models;

//namespace VetKlinik.Services
//{
//    public class MusteriService : IMusteriService
//    {
//        private readonly ApplicationDbContext _ApplicationDbContext;

//        public MusteriService(ApplicationDbContext ApplicationDbContext)
//        {
//            _ApplicationDbContext = ApplicationDbContext;
//        }

//        public void DeleteMusteriById(int id)
//        {
//            var gelenMusteri = _ApplicationDbContext.ApplicationUsers.Where(x => x.Id==id).FirstOrDefault();
//            if (gelenMusteri != null)
//            {
//                _ApplicationDbContext.Musteriler.Remove(gelenMusteri);
//                _ApplicationDbContext.SaveChanges();
//            }

//        }

//        public ApplicationUser GetMusteriById(int id)
//        {
//            return _ApplicationDbContext.ApplicationUser.Where(x => x.Id == id).FirstOrDefault();
//        }

//        public List<ApplicationUser> GetMusteriler()
//        {
//                return _ApplicationDbContext.Musteriler.OrderBy(x => x.Ad).ToList();
//        }

//        public void MusteriEkleGuncelle(MusteriEkleGuncelleDto input)
//        {
//            if (!input.Id.HasValue)
//            {
//                MusteriEkle(input);
//            }
//            else
//            {
//                MusteriGuncelle(input);
//            }
//        }

//        private void MusteriGuncelle(MusteriEkleGuncelleDto input)
//        {
//            var gelenMusteri = _ApplicationDbContext.Musteriler.Where(x => x.Id==input.Id.Value).FirstOrDefault();
//            if(gelenMusteri != null)
//            {
//                gelenMusteri.Email = input.Email;
//                gelenMusteri.Sifre = input.Sifre;
//                gelenMusteri.Ad = input.Ad;
//                gelenMusteri.Soyad = input.Soyad;
//                gelenMusteri.TelNo = input.TelNo;
//                _ApplicationDbContext.Musteriler.Update(gelenMusteri);
//                _ApplicationDbContext.SaveChanges();
//            }

//        }

//        private void MusteriEkle(MusteriEkleGuncelleDto input)
//        {
//            _ApplicationDbContext.Musteriler.Add(new Musteri
//            {
//                Email = input.Email,
//                Sifre = input.Sifre,
//                Ad = input.Ad,
//                Soyad = input.Soyad,
//                TelNo = input.TelNo,
//            });
//            _ApplicationDbContext.SaveChanges();
//        }
//    }
//}
