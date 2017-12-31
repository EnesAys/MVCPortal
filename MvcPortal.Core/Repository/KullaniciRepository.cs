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
    public class KullaniciRepository : IKullaniciRepository
    {
        private readonly PortalContext db = new PortalContext();
        public int Count()
        {
            return db.Kullanici.Count();
        }

        public void Delete(int id)
        {
            var User = GetById(id);
            if (User!=null)
            {
                db.Kullanici.Remove(User);
            }
        }

        public Kullanici Get(Expression<Func<Kullanici, bool>> expression)
        {
            return db.Kullanici.FirstOrDefault(expression);
        }

        public IEnumerable<Kullanici> GetAll()
        {
            return db.Kullanici.ToList();
        }

        public Kullanici GetById(int id)
        {
            return db.Kullanici.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Kullanici> GetMany(Expression<Func<Kullanici, bool>> expression)
        {
            return db.Kullanici.Where(expression);
        }

        public void Insert(Kullanici obj)
        {
            db.Kullanici.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Kullanici obj)
        {
            db.Kullanici.AddOrUpdate(obj);
        }
    }
}
