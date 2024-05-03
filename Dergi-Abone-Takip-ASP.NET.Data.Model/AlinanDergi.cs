using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dergi_Abone_Takip_ASP.NET.Data.Model
{
    public class AlinanDergi:BaseEntity
    {
        [Required]
        public int DergiId { get; set; }
        [Required]
        public int UyeId { get; set; }
        [Required]
        public DateTime AboneBaslangic { get; set;}
        [Required]
        public DateTime AboneBitis { get; set; }
        public DateTime? OdemeTarihi { get; set; }
        public virtual Uye Uye { get; set; }
        public virtual Dergi Dergi { get; set; }
    }
}
