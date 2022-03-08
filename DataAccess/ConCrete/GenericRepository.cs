using DataAccess.ConCrete.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConCrete
{
    public class GenericRepository<T> : Irepository<T> where T : class
    {
        Context c = new Context();
        DbSet<T> _object;
        public GenericRepository()
        {
            _object = c.Set<T>();
        }

        public List<T> ByList(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();
        }

        public void Delete(T p)
        {
            var deleteEntity = c.Entry(p);
            deleteEntity.State = EntityState.Deleted;
            c.SaveChanges();
        }

        public T getByFind(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).FirstOrDefault();
        }

        public T getByID(int id)
        {
            return _object.Find(id);
        }

        public List<T> getList()
        {
            return _object.ToList();
        }

        public void Insert(T p)
        {
            var InsertEntity = c.Entry(p);
            InsertEntity.State = EntityState.Added;
            c.SaveChanges();
        }

        public void Update(T p)
        {
            var UpdateEntity = c.Entry(p);
            UpdateEntity.State = EntityState.Modified;
            c.SaveChanges();
        }
    }
}
