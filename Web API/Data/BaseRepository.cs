using Microsoft.EntityFrameworkCore;
using Web_API.Data.Context;
using Web_API.Models;

namespace Web_API.Data
{
    public class BaseRepository<TEntity> where TEntity : class, IEntity, new()
    {
        private MediatorContext _mediatorContext;
        private DbSet<TEntity> entities;

        public BaseRepository(MediatorContext mediatorContext, DbSet<TEntity> entities)
        {
            _mediatorContext = mediatorContext;
            this.entities = entities;
        }

        public async Task<TEntity> AddAsync(TEntity entity)
        {
            await entities.AddAsync(entity);
            await _mediatorContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Update(TEntity entity)
        {
            entities.Update(entity);
            await _mediatorContext.SaveChangesAsync();
            return entity;
        }
        public async Task<TEntity> Delete(int id)
        {
            var currentEntity = entities.SingleOrDefault(m => m.Id == id);
            entities.Remove(currentEntity);
            await _mediatorContext.SaveChangesAsync();
            return currentEntity;
        }
        public async Task<TEntity> GetByIdAsync(int id)
        {
            return await entities.SingleOrDefaultAsync(m => m.Id == id);
        }
        public async Task<List<TEntity>> GetAllAsync()
        {
            return await entities.ToListAsync();
        }
    }
}
