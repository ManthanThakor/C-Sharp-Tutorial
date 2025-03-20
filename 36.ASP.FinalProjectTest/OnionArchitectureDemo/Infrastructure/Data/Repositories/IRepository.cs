using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Data.Repositories
{
    public interface IRepository<T> where T : class
    {
        Task<T> GetById(Guid id);
        Task<IEnumerable<T>> GetAll();
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(T entity);
        Task<T> Find(Expression<Func<T, bool>> match);
        Task<ICollection<T>> FindAll(Expression<Func<T, bool>> match);
    }
}
