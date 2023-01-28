using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;
using Web_API.Models;

namespace Web_API.Data
{
    public class BaseRepository<TEntity,TContext> 
        where TEntity : class, IEntity, new()
        where TContext : DbContext , new()
    {
        protected TContext Context { get; }

        public BaseRepository(TContext context)
        {
            Context = context;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Added;
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Delete(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Deleted;
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            Context.Entry(entity).State = EntityState.Modified;
            await Context.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity>? GetByAsync(Expression<Func<TEntity, bool>> filter)
        {
            using (Context)
            {
                return await Context.Set<TEntity>().SingleOrDefaultAsync(filter);
            }
        }
        public async Task<List<TEntity>> GetAllAsync(Expression<Func<TEntity, bool>> filter = null)
        {
            using (Context)
            {
                return filter == null ? await Context.Set<TEntity>().ToListAsync() : await Context.Set<TEntity>().Where(filter).ToListAsync();
            }
        }

        public List<TEntity> GetAll(Expression<Func<TEntity, bool>> filter = null)
        {
            using (TContext context = new TContext())
            {
                return filter == null ? context.Set<TEntity>().ToList() : context.Set<TEntity>().Where(filter).ToList();
            }
        }
    }
}
