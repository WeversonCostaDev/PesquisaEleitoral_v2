using Microsoft.EntityFrameworkCore;
using PesquisaEleitoral_v2.Data;
using PesquisaEleitoral_v2.Repositories.Interfaces;
using System.Linq.Expressions;

namespace PesquisaEleitoral_v2.Repositories
{
    public class Repository<T> : IRepository<T> where T: class
    {
        private AppDbContext _context;
        public Repository(AppDbContext context) 
        {
            _context = context;
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _context
                .Set<T>()
                .FindAsync(id);
        }
        public T Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return entity;
        }
        public void Delete(T entity)
        {
            _context.Set<T>().Remove(entity);
        }

        public async Task<bool> VerifyAsync(Expression<Func<T,bool>> predicate)
        {
            return await _context.Set<T>().AnyAsync(predicate);
        }
    }
}
