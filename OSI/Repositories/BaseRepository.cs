using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Castle.ActiveRecord;
using NHibernate.Criterion;
using OSI.Models;

namespace OSI.Repositories
{
    public class BaseRepository<T> : IRepository<T> where T : BaseModel
    {
        protected ActiveRecordMediator<T> mediator;

        public virtual void Add(T item)
        {
            if (item.Id <= 0)
            {
                item.InsertedDate = DateTime.UtcNow;
            }
            else
            {
                item.InsertedDate = Find(item.Id).InsertedDate;
            }
            item.ModificationDate = DateTime.UtcNow;
            ActiveRecordMediator<T>.Save(item);

        }
        public virtual T Find(object id)
        {
            return ActiveRecordMediator<T>.FindByPrimaryKey(id);
        }

        public virtual T FindOne(params ICriterion[] criteria)
        {
            return ActiveRecordMediator<T>.FindOne(criteria);

        }
        public virtual IList<T> FindAll()
        {
                return ActiveRecordMediator<T>.FindAll().Where(t => (!t.DeletedDate.HasValue)).ToList();
        }

        public virtual int Count()
        {
            return ActiveRecordMediator<T>.Count();
        }

        public virtual void Remove(T item)
        {
            item.DeletedDate = DateTime.UtcNow;
            ActiveRecordMediator<T>.Save(item);
        }
    }
}