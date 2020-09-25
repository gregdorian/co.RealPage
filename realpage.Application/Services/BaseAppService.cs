using realpage.Application.Interfaces;
using realpage.Domain.Core.Interfaces.Services;
using System;
using System.Collections.Generic;
using System.Text;

namespace realpage.Application.Services
{
    public class BaseAppService<TEntity> : IDisposable, IBaseAppService<TEntity> where TEntity : class
    {
        
        private readonly IBaseService<TEntity> baseService;


        public BaseAppService(IBaseService<TEntity> baseService)
        {
            this.baseService = baseService;
        }

  
        public void Add(TEntity entity)
        {
            this.baseService.Add(entity);
        }

  
        public void Delete(int id)
        {
            this.baseService.Delete(id);
        }

        public void Dispose()
        {
            this.baseService.Dispose();
        }


        public IEnumerable<TEntity> GetAll()
        {
            return this.baseService.GetAll();
        }


        public TEntity GetById(int id)
        {
            return this.baseService.GetById(id);
        }


        public void Modify(TEntity entity)
        {
            this.baseService.Modify(entity);
        }
    }
}
