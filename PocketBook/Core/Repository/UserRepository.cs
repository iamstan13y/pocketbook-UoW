using System.Collections.Generic;
using System;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IRepository;
using PocketBook.Data;
using PocketBook.Models;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace PocketBook.Core.Repository
{
    public class UserRepository : GenericRepository<User>, IUserRepository
    {
        public UserRepository(
            ApplicationDbContext context,
            ILogger logger
        ) : base(context, logger)
        {
            
        }

        public override async Task<IEnumerable<User>> All()
        {
            try
            {
                return await dbSet.ToListAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "{Repo} All method error", typeof(UserRepository));
                return new List<User>();
            }
        }
    }
}