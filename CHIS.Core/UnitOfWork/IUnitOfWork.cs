using System;
using System.Collections.Generic;
using System.Text;
using CHIS.Core.IRepositories;

namespace CHIS.Core.UnitOfWork
{
     public interface IUnitOfWork : IDisposable
    {
        IAccountRepository Accounts { get; }
        int Complete();
    }
}
