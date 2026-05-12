namespace PesquisaEleitoral_v2.Repositories
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        T Create(T entity);
        void Delete(T entity);
    }
}
