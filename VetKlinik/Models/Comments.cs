using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Yorumlar")]
    public class Comments
    {
        public int Id { get; set; }
        public string Ad { get; set; }
        public string? Yorum { get; set; }
        public string? Puan { get; set; }
    }
}
