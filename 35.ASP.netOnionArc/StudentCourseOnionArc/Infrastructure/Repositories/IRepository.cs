using Domain.common;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IRepository<T> where T : BaseEntity
    {
        T? GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Save();
    }
}