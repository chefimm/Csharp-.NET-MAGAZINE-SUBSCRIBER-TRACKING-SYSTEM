namespace Dergi_Abone_Takip_ASP.NET.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<Dergi_Abone_Takip_ASP.NET.Data.Context>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;//veri tabanını otomatik güncellemeye yarıyor.
            AutomaticMigrationDataLossAllowed = true;//tablo da veri olsa da değişiklik yapmaya izin verir.
            ContextKey = "Dergi_Abone_Takip_ASP.NET.Data.Context";
        }

        protected override void Seed(Dergi_Abone_Takip_ASP.NET.Data.Context context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method
            //  to avoid creating duplicate seed data.
        }
    }
}
