namespace PresupuestitoBack.Repositories.IRepository
{
    public class ICategoryRepository<T> : IDisposable where T : class
    {
        public Task<T> InsertCategory(T entity);
        public Task<T> UpdateCategory(T entity);
        public Task<T> DeleteCategory(int CategoryId);
        public Task<T> GetById(int CategoryId);

        public Task<IEnumerable<T>> GetAll;

    }
}
