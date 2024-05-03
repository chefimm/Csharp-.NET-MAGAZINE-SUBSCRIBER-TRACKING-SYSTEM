namespace Dergi_Abone_Takip_ASP.NET.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class mig1 : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.AlinanDergi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        DergiId = c.Int(nullable: false),
                        UyeId = c.Int(nullable: false),
                        AboneBaslangic = c.DateTime(nullable: false),
                        AboneBitis = c.DateTime(nullable: false),
                        OdemeTarihi = c.DateTime(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Dergi", t => t.DergiId, cascadeDelete: true)
                .ForeignKey("dbo.Uye", t => t.UyeId, cascadeDelete: true)
                .Index(t => t.DergiId)
                .Index(t => t.UyeId);
            
            CreateTable(
                "dbo.Dergi",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50, unicode: false),
                        SiraNo = c.String(nullable: false, maxLength: 500, unicode: false),
                        Adet = c.Int(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        YazarId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Yazar", t => t.YazarId, cascadeDelete: true)
                .Index(t => t.YazarId);
            
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 50, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Yazar",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 200, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Uye",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Ad = c.String(nullable: false, maxLength: 70, unicode: false),
                        Soyad = c.String(nullable: false, maxLength: 70, unicode: false),
                        Adres = c.String(maxLength: 400, fixedLength: true, unicode: false),
                        Tel = c.String(maxLength: 11, fixedLength: true, unicode: false),
                        KayitTarihi = c.DateTime(nullable: false),
                        Mail = c.String(maxLength: 250),
                        Sifre = c.String(maxLength: 32, fixedLength: true, unicode: false),
                        Ceza = c.Int(nullable: false),
                        Yetki = c.String(maxLength: 1, fixedLength: true, unicode: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.KategoriDergi",
                c => new
                    {
                        Kategori_Id = c.Int(nullable: false),
                        Dergi_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Kategori_Id, t.Dergi_Id })
                .ForeignKey("dbo.Kategori", t => t.Kategori_Id, cascadeDelete: true)
                .ForeignKey("dbo.Dergi", t => t.Dergi_Id, cascadeDelete: true)
                .Index(t => t.Kategori_Id)
                .Index(t => t.Dergi_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AlinanDergi", "UyeId", "dbo.Uye");
            DropForeignKey("dbo.AlinanDergi", "DergiId", "dbo.Dergi");
            DropForeignKey("dbo.Dergi", "YazarId", "dbo.Yazar");
            DropForeignKey("dbo.KategoriDergi", "Dergi_Id", "dbo.Dergi");
            DropForeignKey("dbo.KategoriDergi", "Kategori_Id", "dbo.Kategori");
            DropIndex("dbo.KategoriDergi", new[] { "Dergi_Id" });
            DropIndex("dbo.KategoriDergi", new[] { "Kategori_Id" });
            DropIndex("dbo.Dergi", new[] { "YazarId" });
            DropIndex("dbo.AlinanDergi", new[] { "UyeId" });
            DropIndex("dbo.AlinanDergi", new[] { "DergiId" });
            DropTable("dbo.KategoriDergi");
            DropTable("dbo.Uye");
            DropTable("dbo.Yazar");
            DropTable("dbo.Kategori");
            DropTable("dbo.Dergi");
            DropTable("dbo.AlinanDergi");
        }
    }
}
