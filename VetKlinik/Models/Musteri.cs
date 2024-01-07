﻿using System.ComponentModel.DataAnnotations.Schema;

namespace VetKlinik.Models
{
    [Table("Musteri")]
    public class Musteri
    {
        public int Id { get; set; }
        public string Ad{ get; set; }
        public string Soyad{ get; set; }
        public string Email{ get; set; }
        public string Sifre{ get; set; }
        public string TelNo{ get; set; }
    }
}
