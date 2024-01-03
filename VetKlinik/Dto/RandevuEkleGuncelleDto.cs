using System.ComponentModel.DataAnnotations.Schema;
using VetKlinik.Models;

namespace VetKlinik.Dto
{
    public class RandevuEkleGuncelleDto
    {
        public int? Id { get; set; }
        public int MusteriId { get; set; }
        public int PersonelId { get; set; }
        public DateTime Tarih { get; set; }
        public RandevuDurumu Durum { get; set; }
    }
}
