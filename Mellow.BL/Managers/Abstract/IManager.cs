using Mellow.BL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.BL.Managers.Abstract
{
    public interface IManager<T> where T : class
    {
        public Task<MyResult> InsertAsync(T entity, CancellationToken cancellationToken);
        public Task<MyResult> UpdateAsync(T entity, CancellationToken cancellationToken);
        public Task<MyResult> DeleteAsync(T entity, CancellationToken cancellationToken);
        public Task<T?> GetByIdAsync(int id, CancellationToken cancellationToken);
        public Task<T?> GetAsync(CancellationToken cancellationToken, Expression<Func<T, bool>> filter);
        public Task<ICollection<T>?> GetAllAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? filter = null);
        public Task<IQueryable<T>?> GetAllIncludeAsync(CancellationToken cancellationToken, Expression<Func<T, bool>>? filter = null, params Expression<Func<T, object>>[] include);

    }
}
