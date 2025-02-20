using Domain;
using Domain.Common;
using System.Collections.Generic;

namespace Infrastructure.Repositories
{
    public interface IUserRepository<T> where T : BaseEntity
    {
        T GetById(int id);
        IEnumerable<T> GetAll();
        void Add(T entity);
        void Update(T entity);
        void Delete(T entity);
        void Remove(T entity);
        void Save();
    }
}
