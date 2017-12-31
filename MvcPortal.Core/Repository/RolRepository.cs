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
    public class RolRepository : IRolRepository
    {
        private readonly PortalContext db = new PortalContext();

        public int Count()
        {
            return db.Rol.Count();
        }

        public void Delete(int id)
        {
            var Rol = GetById(id);
            if (Rol!=null)
            {
                db.Rol.Remove(Rol);
            }
        }

        public Rol Get(Expression<Func<Rol, bool>> expression)
        {
            return db.Rol.FirstOrDefault(expression);
        }

        public IEnumerable<Rol> GetAll()
        {
            return db.Rol.ToList();
        }

        public Rol GetById(int id)
        {
            return db.Rol.FirstOrDefault(x=>x.ID==id);
        }

        public IQueryable<Rol> GetMany(Expression<Func<Rol, bool>> expression)
        {
            return db.Rol.Where(expression);
        }

        public void Insert(Rol obj)
        {
            db.Rol.Add(obj);
        }

        public void Save()
        {
            db.SaveChanges();
        }

        public void Update(Rol obj)
        {
            db.Rol.AddOrUpdate(obj);
        }
    }
}
