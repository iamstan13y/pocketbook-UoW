using System;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IRepository;
using PocketBook.Data;
using PocketBook.Models;

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
    }
}