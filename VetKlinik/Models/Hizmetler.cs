using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Hizmetler")]
    public class Hizmetler
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string? Aciklama{ get; set; }
        public string? Icon{ get; set; }
    }
}
