using Mellow.BL.Managers.Abstract;
using Mellow.BL.Models;
using Mellow.DAL.DbContexts;
using Mellow.DAL.GenericRepository.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Mellow.BL.Managers.Concrete
{
    public class Manager<T> :Repository<T>, IManager<T> where T : class
    {
        public Manager(AppDbcontext db) : base(db)
        {
        }

        public async  Task<MyResult> DeleteAsync(T entity, CancellationToken cancellationToken)
        {

            MyResult result = new MyResult();
            var affectedRows=  await base.DeleteAsync(entity, cancellationToken);
            if(affectedRows > 0)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Errors = new List<MyError> { new MyError {Code="", Message = "Delete operation failed" } };
            }
            return result;
        }



        public async Task<MyResult> InsertAsync(T entity, CancellationToken cancellationToken)
        {
            MyResult result = new MyResult();
            var affectedRows = await base.InsertAsync(entity, cancellationToken);
            if (affectedRows > 0)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Errors = new List<MyError> { new MyError { Code = "", Message = "Create operation failed" } };
            }
            return result;
        }

        public async Task<MyResult> UpdateAsync(T entity, CancellationToken cancellationToken)
        {
            MyResult result = new MyResult();
            var affectedRows = await base.UpdateAsync(entity, cancellationToken);
            if (affectedRows > 0)
            {
                result.Success = true;
            }
            else
            {
                result.Success = false;
                result.Errors = new List<MyError> { new MyError { Code = "", Message = "Update operation failed" } };
            }
            return result;
        }
    }
}
