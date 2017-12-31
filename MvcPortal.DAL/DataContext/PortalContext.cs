using MvcPortal.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.DAL.DataContext
{
   public class PortalContext:DbContext
    {
        public PortalContext():base("PortalCon")
        {

        }
        public DbSet<Kullanici> Kullanici { get; set; }
        public DbSet<Rol> Rol { get; set; }
        public DbSet<Resim> Resim { get; set; }
        public DbSet<Yazi> Yazi { get; set; }
        public DbSet<Kategori> Kategori { get; set; }

    }
}
