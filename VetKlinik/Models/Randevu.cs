using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Randevu")]
    public class Randevu
    {
        public int Id { get; set; }
        public int MusteriId { get; set; }
        public int PersonelId { get; set; }
        [ForeignKey("MusteriId")]
        public ApplicationUser MusteriFk { get; set; }
        [ForeignKey("PersonelId")]
        public Personel PersonelFk { get; set; }
        public DateTime Tarih { get; set; }
        public RandevuDurumu Durum { get; set; }
    }
}
