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
    public class ResimRepository : IResimRepository
    {
        private readonly PortalContext db = new PortalContext();
        public int Count()
        {
            return db.Resim.Count();
        }

        public void Delete(int id)
        {
            var Resim = GetById(id);
            if (Resim!=null)
            {
                db.Resim.Remove(Resim);
            }
        }

        public Resim Get(Expression<Func<Resim, bool>> expression)
        {
            return db.Resim.FirstOrDefault(expression);
        }

        public IEnumerable<Resim> GetAll()
        {
            return db.Resim.ToList();
        }

        public Resim GetById(int id)
        {
            return db.Resim.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Resim> GetMany(Expression<Func<Resim, bool>> expression)
        {
            return db.Resim.Where(expression);
        }

        public void Insert(Resim obj)
        {
            db.Resim.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Resim obj)
        {
            db.Resim.AddOrUpdate(obj);
        }
    }
}
