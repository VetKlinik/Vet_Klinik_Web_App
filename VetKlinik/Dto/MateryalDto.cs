using System.ComponentModel.DataAnnotations.Schema;
using VetKlinik.Models;

namespace VetKlinik.Dto
{
    public class MateryalDto
    {
        public int? Id { get; set; }
        public string Baslik { get; set; }
        public string Icerik { get; set; }
        public MateryalKategori Kategori { get; set; }
        public string? Cevap { get; set; }
        public int? MusteriId { get; set; }
        public int? PersonelId { get; set; }
    }
}
