using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IRepository;
using PocketBook.Data;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace PocketBook.Core.Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected ApplicationDbContext _context;
        protected DbSet<T> dbSet;
        protected readonly ILogger _logger;

        public GenericRepository(
            ApplicationDbContext context,
            ILogger logger
        )
        {
            _context = context;
            _logger = logger;
            dbSet = _context.Set<T>();
        }

        public virtual async Task<IEnumerable<T>> All()
        {
            return await dbSet.ToListAsync();
        }

        public virtual async Task<T> GetById(Guid id)
        {
            return await dbSet.FindAsync(id);
        }

        public virtual async Task<bool> Add(T entity)
        {
            await dbSet.AddAsync(entity);
            return true;
        }

        public virtual Task<bool> Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public virtual Task<bool> Upsert(T entity)
        {
            throw new NotImplementedException();
        }  
    }
}