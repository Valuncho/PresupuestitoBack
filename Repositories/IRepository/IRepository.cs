using System.Linq.Expressions;

namespace PresupuestitoBack.Repositories.IRepositories
{
    public interface IRepository<T> where T : class
    {

        Task<List<T>> GetAll(Expression<Func<T, bool>>? filter = null);
        Task<T> GetById(Expression<Func<T, bool>>? filter = null, bool tracked = true);
        Task<bool> Insert(T entity);
        Task<bool> Update(T entity);

    }
}
