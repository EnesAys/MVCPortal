namespace MvcPortal.DAL.Migrations
{
    using MvcPortal.DAL.DataContext;
    using MvcPortal.DAL.Model;
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<PortalContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(PortalContext context)
        {
            context.Kategori.AddOrUpdate(x => x.ID,
               new Kategori() { ID = 1, KategoriAdi = "Teknoloji" ,ParentID=0,URL="/Teknoloji"},
               new Kategori() { ID = 2, KategoriAdi = "Spor",ParentID=0,URL="/Spor"}
               );

            context.Rol.AddOrUpdate(x => x.ID,
                new Rol() { ID = 1, RolAdi = "Admin" },
                new Rol() { ID = 2, RolAdi = "User" }
                );

            context.Kullanici.AddOrUpdate(x => x.ID,
                new Kullanici()
                {
                    ID = 1,
                    AdSoyad = "Enes Aysan",
                    Email = "enes@enes.com",
                    Sifre = "123456",
                    Rol=context.Rol.FirstOrDefault(x=>x.ID==1)
                },
                new Kullanici()
                {
                  ID = 2,
                  AdSoyad = "Ahmet Demir",
                  Email = "ahmet@ahmet.com",
                  Sifre = "123456",
                  Rol = context.Rol.FirstOrDefault(x => x.ID ==2)
                }
                );
        }
    }
}
