﻿using MoiveHub.Models;
using System.Linq.Expressions;

namespace MoiveHub.Data.Base
{
    public interface IEntityBaseRespository<T> where T : class,IEntityBase,new()
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<IEnumerable<T>> GetAllAsync(params Expression<Func<T, object>>[] includeProperties);
        Task<T> GetByIdAsync(int Id);
        
        Task AddAsync(T entity);
        Task UpdateAsync(int id, T entity);
        Task DeleteAsync(int id);
        
       
        
    }
}
