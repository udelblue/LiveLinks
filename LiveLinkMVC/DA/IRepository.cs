using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.Data;
using System.Linq.Expressions;



namespace LiveLinkMVC.Models
{
    public interface IRepository<T>
    {
        void Add(T entity);
        void Update(T entity);
        void DeleteById(int id);
        T GetById(int id);
        T[] GetAll();
        IQueryable<T> Query(Expression<Func<T, bool>> filter);
    }
}
