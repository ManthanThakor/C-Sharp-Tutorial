    using InfrastructureLayer.Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace InfrastructureLayer.Service.GeneralServices
{
    public class Service<T> : IService<T> where T : class
    {
        private readonly IRepository<T> _repository;

        public Service(IRepository<T> repository)
        {
            _repository = repository;
        }

        public async Task<ICollection<T>> GetAll()
        {
            return await _repository.GetAll();
        }

        public async Task<T> Get(Guid id)
        {
            return await _repository.Get(id);
        }

        public T GetLast()
        {
            return _repository.GetLast();
        }

        public async Task<bool> Insert(T entity)
        {
            return await _repository.Insert(entity);
        }

        public async Task<bool> Update(T entity)
        {
            return await _repository.Update(entity);
        }

        public async Task<bool> Delete(T entity)
        {
            return await _repository.Delete(entity);
        }

        public async Task<T> Find(Expression<Func<T, bool>> match)
        {
            return await _repository.Find(match);
        }

        public async Task<ICollection<T>> FindAll(Expression<Func<T, bool>> match)
        {
            return await _repository.FindAll(match);
        }
    }
}