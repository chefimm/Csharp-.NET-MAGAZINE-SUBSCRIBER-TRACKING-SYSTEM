using Dergi_Abone_Takip_ASP.NET.Data.Migrations;
using Dergi_Abone_Takip_ASP.NET.Data.Model;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace Dergi_Abone_Takip_ASP.NET.Data
{
    public class Context:DbContext
    {
        public Context() : base("Context") 
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<Context,Configuration>("Context"));//Migrataino database bağlayıp dahil ettik.
        }

        public DbSet<Kategori> Kategoriler { get; set; }
        public DbSet<Dergi> Dergiler { get; set; }
        public DbSet<AlinanDergi> AlinanDergiler { get; set; }
        public DbSet<Uye> Uyeler { get; set; }
        public DbSet<Yazar> Yazarlar { get; set; }
        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            //Mssql de otomatik s takısı ekliyor bunu kaldırmanın yolu 
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
            base.OnModelCreating(modelBuilder);
        }
    }
}
