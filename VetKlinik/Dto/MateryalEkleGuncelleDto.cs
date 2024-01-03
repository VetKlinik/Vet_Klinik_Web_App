using System.ComponentModel.DataAnnotations.Schema;
using VetKlinik.Models;

namespace VetKlinik.Dto
{
    public class MateryalEkleGuncelleDto
    {
        public int? Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public MateryalKategori Kategori { get; set; }
        public string? Cevap { get; set; }
        public int? MusteriId { get; set; }
        public int? PersonelId { get; set; }
        [ForeignKey("MusteriId")]
        public Musteri? MusteriFk { get; set; }
        [ForeignKey("PersonelId")]
        public Personel? PersonelFk { get; set; }
    }
}
