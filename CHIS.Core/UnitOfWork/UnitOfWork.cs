using System;
using System.Collections.Generic;
using System.Text;
using CHIS.Core.IRepositories;
using CHIS.Core.Repositories;
using CHIS.Core.Domain;

namespace CHIS.Core.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly hotel_dbContext _context;
        public IAccountRepository Accounts { get; private set; }

        public UnitOfWork(hotel_dbContext context)
        {
            _context = context;
            Accounts = new AccountRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
