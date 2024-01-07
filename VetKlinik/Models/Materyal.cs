using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Materyal")]
    public class Materyal
    {
        public int Id{ get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public MateryalKategori Kategori { get; set; }
        public string? Cevap{ get; set; }
        public int? MusteriId{ get; set; }
        public int? PersonelId{ get; set; }
        [ForeignKey("MusteriId")]
        public ApplicationUser? MusteriFk{ get; set; }
        [ForeignKey("PersonelId")]
        public Personel? PersonelFk { get; set; }
    }
}
