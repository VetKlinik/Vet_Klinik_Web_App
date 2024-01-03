using System.ComponentModel.DataAnnotations.Schema;
using VetKlinik.Models;

namespace VetKlinik.Dto
{
    public class SoruCevapEkleGuncelleDto
    {
        public int? Id { get; set; }
        public string Soru { get; set; }
        public MateryalKategori Kategori { get; set; }
        public string? Cevap { get; set; }
        public int MusteriId { get; set; }
        public int? PersonelId { get; set; }

    }
}
