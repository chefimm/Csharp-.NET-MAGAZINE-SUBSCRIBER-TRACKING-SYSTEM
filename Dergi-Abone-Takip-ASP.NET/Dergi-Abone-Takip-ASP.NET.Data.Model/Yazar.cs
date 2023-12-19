using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Dergi_Abone_Takip_ASP.NET.Data.Model
{
    public class Yazar:BaseEntity
    {
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(200)]
        public string Ad { get; set; }
        public virtual  List<Dergi> Dergiler { get; set; }
    }
}
