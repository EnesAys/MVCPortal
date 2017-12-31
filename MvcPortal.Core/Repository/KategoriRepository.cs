using MvcPortal.Core.Infrastracture;
using MvcPortal.DAL.DataContext;
using MvcPortal.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;//AddOrUpdate methodu için gereklidir.
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.Core.Repository
{
    public class KategoriRepository : IKategoriRepository
    {
        private readonly PortalContext db = new PortalContext();

        public int Count()
        {
            return db.Kategori.Count();
        }

        public void Delete(int id)
        {
            var kategori = GetById(id);
            if (kategori!=null)
            {
                db.Kategori.Remove(kategori);
            }
        }

        public Kategori Get(Expression<Func<Kategori, bool>> expression)
        {
            return db.Kategori.FirstOrDefault(expression);
        }

        public IEnumerable<Kategori> GetAll()
        {
            return db.Kategori.ToList();
        }

        public Kategori GetById(int id)
        {
            return db.Kategori.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Kategori> GetMany(Expression<Func<Kategori, bool>> expression)
        {
            return db.Kategori.Where(expression);
        }

        public void Insert(Kategori obj)
        {
            db.Kategori.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Kategori obj)
        {
            db.Kategori.AddOrUpdate(obj);
        }
    }
}
