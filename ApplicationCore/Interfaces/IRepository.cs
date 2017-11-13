using System.Collections.Generic;

namespace ApplicationCore.Interfaces
{
    public interface IRepository<T>
    {
        T Add(T entity);
        T GetById(int id);
        void Update(T entity);
        void Delete(T entity);
        List<T> List();
    }
}