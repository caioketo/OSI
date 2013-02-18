using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate.Criterion;

namespace OSI.Repositories
{
    public interface IRepository<T>
    {
        T Find(object id);
        T FindOne(params ICriterion[] criteria);
        IList<T> FindAll();
        void Add(T item);
        void Remove(T item);
        int Count();
    }
}
