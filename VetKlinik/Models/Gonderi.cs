using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Gonderi")]
    public class Gonderi
    {
        public int Id { get; set; }
        public string? BaslikBir { get; set; }
        public string? BaslikIki { get; set; }
        public string? AltBaslik{ get; set; }
        public string? Icerik{ get; set; }
        public string? FotoUrl{ get; set; }
        public string? Height { get; set; }
        public string? Width { get; set; }
    }
}
