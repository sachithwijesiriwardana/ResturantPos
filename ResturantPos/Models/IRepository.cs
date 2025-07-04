﻿using System.Linq.Expressions;

namespace ResturantPos.Models
{
    public interface IRepository <T> where T : class
    {
        Task<IEnumerable<T>> GellAllAsync();

        Task<T> GetByAsync(int id,QueryOptions<T>options);

        Task AddAsync(T entity);

        Task UpdateAsync(T entity);

        Task DeleteAsync(int id);
    }
}
