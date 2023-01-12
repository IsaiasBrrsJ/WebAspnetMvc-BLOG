using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using WebAspnet_.Models;

namespace WebAspnet_.Repository.Interfaces
{
    public interface IRepositoryBase<TEntity> where TEntity : Entity
    {
        Task<IEnumerable<TEntity>> GetAll();
        Task<Entity> GetId(Guid id);

        Task AddAsync(TEntity entity);

        Task UpdateAsync(TEntity entity);

        Task Remove(Guid id);

    }
}