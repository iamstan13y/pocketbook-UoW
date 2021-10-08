using System;
using Microsoft.Extensions.Logging;
using PocketBook.Core.IConfiguration;
using PocketBook.Core.IRepository;
using PocketBook.Core.Repository;

namespace PocketBook.Data
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly ApplicationDbContext _context;
        private readonly ILogger _logger;

        public IUserRepository Users { get; private set; }

        public UnitOfWork(
            ApplicationDbContext context,
            ILoggerFactory loggerFactory
        )
        {
            _context = context;
            _logger = loggerFactory.CreateLogger("logs");

            Users = new UserRepository(_context, _logger);
        }
    }
}