﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using MoiveHub.Data.Base;
using MoiveHub.Models;
using System.Linq.Expressions;

namespace MoiveHub.Data.BaseGeneric
{
    public class EntityBaseRespository<T> : IEntityBaseRespository<T> where T : class, IEntityBase, new()
    {
        private readonly AppDbContext _context;
        public EntityBaseRespository(AppDbContext context)
        {
            _context=context;
        }
        public async Task AddAsync(T entity)
        {
            await _context.Set<T>().AddAsync(entity);
            await _context.SaveChangesAsync();
        }
        public async Task DeleteAsync(int id)
        {

            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id ==id);
            EntityEntry entityEntry = _context.Entry<T>(result);
            entityEntry.State = EntityState.Deleted;
            await _context.SaveChangesAsync();
        }
       
        public async Task<T> GetByIdAsync(int id)
        {
            var result = await _context.Set<T>().FirstOrDefaultAsync(n => n.Id ==id);
          
            return result;
        }
        public  async Task<IEnumerable<T>> GetAllAsync()
        {
            var result = await _context.Set<T>().ToListAsync();
            return result;
        }

        public async Task UpdateAsync(int id, T entity)
        {
            EntityEntry entityEntry = _context.Entry<T>(entity);
            entityEntry.State = EntityState.Modified;
            await _context.SaveChangesAsync();
        }

        public async Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties)
        {
            IQueryable<T> query = _context.Set<T>();
            query = includeProperties.Aggregate(query, (current, includeProperty) => current.Include(includeProperty));
            return await query.ToListAsync();
        }

       
    }
}
