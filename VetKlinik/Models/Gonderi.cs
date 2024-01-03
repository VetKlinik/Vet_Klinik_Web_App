using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Gonderi")]
    public class Gonderi
    {
        public int Id { get; set; }
        public string? Baslik { get; set; }
        public string? Icerik{ get; set; }

        public string? FotoUrl{ get; set; }
    }
}
