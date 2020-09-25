using System.Collections.Generic;

namespace realpage.Domain.Core.Interfaces.Services
{
    public interface IBaseService<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void Delete(int id);

        void Modify(TEntity entity);

        IEnumerable<TEntity> GetAll();

        TEntity GetById(int id);

        void Dispose();
    }
}
