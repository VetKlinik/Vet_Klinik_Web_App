using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{

    [Table("Fotograf")]
    public class Fotograf
    {
        public int Id{ get; set; }
        public string? Aciklama { get; set; }
        public string FotografUrl{ get; set;}
    }
}
