namespace MvcPortal.DAL.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Intializer : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Kategori",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        KategoriAdi = c.String(nullable: false, maxLength: 100),
                        ParentID = c.Int(),
                        URL = c.String(maxLength: 100),
                        Aktifmi = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Yazı",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        Baslik = c.String(nullable: false, maxLength: 150),
                        KisaAciklama = c.String(),
                        Aciklama = c.String(),
                        Okuma = c.Int(nullable: false),
                        Resim = c.String(maxLength: 255),
                        Aktifmi = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Kategori_ID = c.Int(),
                        Kullanici_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Kategori", t => t.Kategori_ID)
                .ForeignKey("dbo.Kullanici", t => t.Kullanici_ID)
                .Index(t => t.Kategori_ID)
                .Index(t => t.Kullanici_ID);
            
            CreateTable(
                "dbo.Kullanici",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        AdSoyad = c.String(maxLength: 100),
                        Email = c.String(nullable: false),
                        Sifre = c.String(nullable: false, maxLength: 16),
                        Aktifmi = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Rol_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Rol", t => t.Rol_ID)
                .Index(t => t.Rol_ID);
            
            CreateTable(
                "dbo.Rol",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        RolAdi = c.String(maxLength: 100),
                        Aktifmi = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.ID);
            
            CreateTable(
                "dbo.Resim",
                c => new
                    {
                        ID = c.Int(nullable: false, identity: true),
                        ResimUrl = c.String(),
                        Aktifmi = c.Boolean(nullable: false),
                        EklenmeTarihi = c.DateTime(nullable: false),
                        Yazi_ID = c.Int(),
                    })
                .PrimaryKey(t => t.ID)
                .ForeignKey("dbo.Yazı", t => t.Yazi_ID)
                .Index(t => t.Yazi_ID);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Resim", "Yazi_ID", "dbo.Yazı");
            DropForeignKey("dbo.Yazı", "Kullanici_ID", "dbo.Kullanici");
            DropForeignKey("dbo.Kullanici", "Rol_ID", "dbo.Rol");
            DropForeignKey("dbo.Yazı", "Kategori_ID", "dbo.Kategori");
            DropIndex("dbo.Resim", new[] { "Yazi_ID" });
            DropIndex("dbo.Kullanici", new[] { "Rol_ID" });
            DropIndex("dbo.Yazı", new[] { "Kullanici_ID" });
            DropIndex("dbo.Yazı", new[] { "Kategori_ID" });
            DropTable("dbo.Resim");
            DropTable("dbo.Rol");
            DropTable("dbo.Kullanici");
            DropTable("dbo.Yazı");
            DropTable("dbo.Kategori");
        }
    }
}
