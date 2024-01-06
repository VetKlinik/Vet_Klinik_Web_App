using System.ComponentModel.DataAnnotations;

namespace VetKlinik.Dto
{
    public class CommentsEkleGuncelleDto
    {
        //TODO Server side validation kullanımı
        public int? Id { get; set; }

        [Required(ErrorMessage = "Ad alanı zorunludur.")]
        [StringLength(50, MinimumLength = 2, ErrorMessage = "Ad alanı en az 2, en fazla 50 karakter olmalıdır.")]
        public string Ad { get; set; }

        [Required(ErrorMessage = "Yorum alanı zorunludur.")]
        [StringLength(500, MinimumLength = 10, ErrorMessage = "Yorum alanı en az 10, en fazla 500 karakter olmalıdır.")]
        public string? Yorum { get; set; }

        [Range(1, 5, ErrorMessage = "Puan alanı 1 ile 5 arasında olmalıdır.")]
        public string? Puan { get; set; }
    }
}
