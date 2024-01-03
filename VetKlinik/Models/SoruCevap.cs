using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("SoruCevap")]
    public class SoruCevap
    {
        public int Id { get; set; }
        public string Soru { get; set; }
        public MateryalKategori Kategori { get; set; }
        public string? Cevap { get; set; }
        public int MusteriId { get; set; }
        public int? PersonelId { get; set; }
        [ForeignKey("MusteriId")]
        public Musteri MusteriFk { get; set; }
        [ForeignKey("PersonelId")]
        public Personel? PersonelFk { get; set; }
    }
}
