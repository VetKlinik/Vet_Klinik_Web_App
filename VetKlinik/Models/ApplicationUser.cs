using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    public class ApplicationUser : IdentityUser
    {
        [Required]
        public string Ad { get; set; }
        public string Soyad { get; set; }
        public string TelNo { get; set; }
    }
}
