using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Personel")]
    public class Personel
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string Soyad{ get; set; }
        public PersonelUnvan Unvan{ get; set; }
        public string? UzmanlikAlani{ get; set; }
        public string? Deneyim { get; set; }
        public string? Egitim{ get; set; }
        public string? FotoUrl{ get; set; }

        public string? Facebook{ get; set; }
        public string? X { get; set; }
        public string? Instagram { get; set; }
        public string? LinkedIn{ get; set; }

    }


}
