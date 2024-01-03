using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("IletisimBilgileri")]
    public class IletisimBilgileri
    {
        public int Id { get; set; }
        public string? Adres { get; set; }

        public List<string>? TelefonNumaralari { get; set; }
        public List<string>? EmailAdresleri { get; set; }

        public string? FacebookLink { get; set; }
        public string? XLink { get; set; }
        public string? InstagramLink { get; set; }
        public string? LinkedinLink { get; set; }
        public string? PinterestLink { get; set; }
    }
}
