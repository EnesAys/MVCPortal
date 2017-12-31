using MvcPortal.Core.Infrastracture;
using MvcPortal.DAL.DataContext;
using MvcPortal.DAL.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.Migrations;//AddOrUpdate metodu için
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace MvcPortal.Core.Repository
{
    public class YaziRepository : IYaziRepository
    {
        private readonly PortalContext db = new PortalContext();

        public int Count()
        {
            return db.Yazi.Count();//Yazı Sayımızı verecek
        }

        public void Delete(int id)
        {
            var Yazi = GetById(id);
            if (Yazi!=null)
            {
                db.Yazi.Remove(Yazi);
            }
        }

        public Yazi Get(Expression<Func<Yazi, bool>> expression)
        {
            return db.Yazi.FirstOrDefault(expression);
        }

        public IEnumerable<Yazi> GetAll()
        {
            return db.Yazi.ToList();    
        }

        public Yazi GetById(int id)
        {
           return db.Yazi.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Yazi> GetMany(Expression<Func<Yazi, bool>> expression)
        {
            return db.Yazi.Where(expression);
        }

        public void Insert(Yazi obj)
        {
            db.Yazi.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Yazi obj)
        {
            db.Yazi.AddOrUpdate();
        }
    }
}
