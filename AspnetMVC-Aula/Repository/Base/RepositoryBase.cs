using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using WebAspnet_.Models;
using WebAspnet_.Repository.Interfaces;
namespace WebAspnet_.Repository.Base
{
    public class RepositoryBase<TEntity> : IRepositoryBase<TEntity> where TEntity : Entity
    {
        public readonly DbSet<TEntity> DbSet;
        public readonly BlogDbContext Context;

        public RepositoryBase(BlogDbContext context)
        {
            DbSet = context.Set<TEntity>();
            Context = context;
        }
        public async Task AddAsync(TEntity entity)
        {
            await DbSet.AddAsync(entity);
            await Context.SaveChangesAsync();
        }

        public async Task<IList<TEntity>> GetAll() =>
               await DbSet.ToListAsync();

        public async Task<TEntity> GetId(Guid id) =>
            await DbSet.FindAsync(id);

        public async Task Remove(Guid id)
        {
            var entityRemove = await GetId(id);
            DbSet.Remove((TEntity)entityRemove);
            await Context.SaveChangesAsync();
        }
        public async Task UpdateAsync(TEntity entity)
        {
            DbSet.Update(entity);
            await Context.SaveChangesAsync();
        }
    }
}