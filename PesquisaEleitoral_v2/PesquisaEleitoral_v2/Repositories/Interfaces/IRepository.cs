using System.Linq.Expressions;

namespace PesquisaEleitoral_v2.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        Task<T?> GetByIdAsync(int id);
        T Create(T entity);
        void Delete(T entity);
        Task<bool> VerifyAsync(Expression<Func<T, bool>> predicate);
    }
}
