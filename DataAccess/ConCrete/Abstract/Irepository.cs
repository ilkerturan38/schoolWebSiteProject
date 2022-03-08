using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.ConCrete.Abstract
{
    public interface Irepository<T>
    {
        List<T> getList();
        List<T> ByList(Expression<Func<T, bool>> filter);

        void Insert(T p);
        void Update(T p);
        void Delete(T p);
        T getByID(int id);
        T getByFind(Expression<Func<T, bool>> filter);
    }
}
