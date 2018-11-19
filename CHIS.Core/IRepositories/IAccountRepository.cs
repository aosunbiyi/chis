using System;
using System.Collections.Generic;
using System.Text;
using CHIS.Core.Domain;

namespace CHIS.Core.IRepositories
{
    public interface IAccountRepository : IRepository<accounts>
    {
        IEnumerable<accounts> GetAccountByHotelRepresentativeId(int id);
        IEnumerable<accounts> GetActiveAccounts();
        IEnumerable<accounts> GetTopAccounts();
    }
}
