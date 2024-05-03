using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dergi_Abone_Takip_ASP.NET.Data.Model
{
    public class Dergi:BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Ad { get; set; }
        
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(500)]
        public string SiraNo { get; set; }
        
        [Required]
        public int Adet { get; set; }
        
        [Required]
        public DateTime  EklenmeTarihi { get; set; } = DateTime.Now;
        
        [Required]
        public int YazarId { get; set; }
        public virtual Yazar Yazar { get; set; }

        public virtual List<Kategori> Kategoriler { get; set; }
    }
}
