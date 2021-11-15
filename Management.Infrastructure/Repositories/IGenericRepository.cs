using Management.Infrastructure.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public interface IGenericRepository<T> where T:class
    {
        IEnumerable<T> GetAll();
        IEnumerable<T> Find(Expression<Func<T,bool>> entities);
        IResult Add(T entity);
        IResult Update(T entity);
        IResult Remove(T entity);
    }
}
