using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using VetKlinik.Models;

namespace VetKlinik.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {

        public DbSet<Personel> Personeller { get; set; }
        public DbSet<Randevu> Randevular { get; set; }
        public DbSet<Fotograf> Fotograflar { get; set; }
        public DbSet<Hizmetler> Hizmetler { get; set; }
        public DbSet<IletisimBilgileri> IletisimBilgileri { get; set; }
        public DbSet<Materyal> Materyaller { get; set; }
        public DbSet<SoruCevap> SoruCevaplar { get; set; }
        public DbSet<Gonderi> Gonderiler{ get; set; }
        public DbSet<Comments> Comments{ get; set; }
        public DbSet<ApplicationUser> ApplicationUsers { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }



    }
}
