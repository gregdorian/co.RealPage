using System.Collections.Generic;
using realpage.Domain.Entities;
using realpage.Domain.Core.Interfaces.Repositories;
using realpage.Domain.Core.Interfaces.Services;

namespace realpage.Domain.Core
{
    public class BaseService<TEntity> : IBaseService<TEntity> where TEntity : class
    {
        private readonly IBaseRepository<TEntity> baseRepository;

        public BaseService(IBaseRepository<TEntity> baseRepository)
        {
            this.baseRepository = baseRepository;
        }
        public void Add(TEntity entity)
        {
            this.baseRepository.Add (entity);
        }

        public void Delete(int id)
        {
            this.baseRepository.Delete(id);
        }

        public void Dispose()
        {
            this.baseRepository.Dispose();
        }

        public IEnumerable<TEntity> GetAll()
        {
            return this.baseRepository.GetAll();
        }

        public TEntity GetById(int id)
        {
            return this.baseRepository.GetById(id);
        }

        public void Modify(TEntity entity)
        {
            this.baseRepository.Modify(entity);
        }
    }
}
