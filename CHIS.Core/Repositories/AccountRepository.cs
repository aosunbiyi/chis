using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using CHIS.Core.Repositories;
using CHIS.Core.IRepositories;
using CHIS.Core.Domain;

namespace CHIS.Core.Repositories
{
    public class AccountRepository : Repository<accounts>, IAccountRepository
    {

        public AccountRepository(hotel_dbContext context):base(context)
        {
        }
        public IEnumerable<accounts> GetAccountByHotelRepresentativeId(int id)
        {
           return HotelContext.accounts.Where(a => a.hotel_representative_id == id).ToList();
        }

        public IEnumerable<accounts> GetActiveAccounts()
        {
            throw new NotImplementedException();
        }

        public IEnumerable<accounts> GetTopAccounts()
        {
            throw new NotImplementedException();
        }

        public hotel_dbContext HotelContext
        {
            get { return Context as hotel_dbContext; }
        }
    }
}
