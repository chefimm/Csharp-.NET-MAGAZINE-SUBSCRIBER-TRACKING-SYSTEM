using System.ComponentModel.DataAnnotations;

namespace Dergi_Abone_Takip_ASP.NET.Data.Model
{
    public class BaseEntity
    {
        [Key]
        public int Id { get; set; }
    }
}
