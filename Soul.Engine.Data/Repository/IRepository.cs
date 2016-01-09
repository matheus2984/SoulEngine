using System.Collections.Generic;

namespace Soul.Engine.Data.Repository
{
    public interface IRepository<T>
    {
        void Insert(T entity);
        void Delete(T entity);
        void Update(T entity);
        T GetById(int id);
        IList<T> Query();
    }
}
