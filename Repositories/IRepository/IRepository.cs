﻿using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {
        public Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> GetById(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        public Task<bool> Update(T entity);
        public Task<bool> Delete(int id);
        public Task<bool> Insert(T entity);
    }
}
