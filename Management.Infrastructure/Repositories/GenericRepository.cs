using Management.Infrastructure.Utilities.Results;
using Management.Model.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Management.Infrastructure.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly ManagementDBContext _context;
        public GenericRepository(ManagementDBContext context)
        {
            _context = context;
        }
        public IResult Add(T entity)
        {
            using (_context)
            {
                var addedEntity = _context.Entry(entity);
                addedEntity.State = EntityState.Added;
                _context.SaveChanges();
                return new Result(true);
            }
        }
        public IEnumerable<T> Find(Expression<Func<T, bool>> entities=null)
        {
            using (_context)
            {
                return entities == null
                   ? _context.Set<T>().ToList()
                   : _context.Set<T>().Where(entities).ToList();
            }
        }
        public IEnumerable<T> GetAll()
        {
            using (_context)
            {
               return  _context.Set<T>().ToList();
            }
        }
        public IResult Update(T entity)
        {
            using (_context)
            {
                var updateedEntity = _context.Entry(entity);
                updateedEntity.State = EntityState.Modified;
                _context.SaveChanges();
                return new Result(true);
            }
        }
        public IResult Remove(T entity)
        {
            using (_context)
            {
                var deletedEntity = _context.Entry(entity);
                deletedEntity.State = EntityState.Deleted;
                _context.SaveChanges();
                return new Result(true);
            }
        }

    }
}
