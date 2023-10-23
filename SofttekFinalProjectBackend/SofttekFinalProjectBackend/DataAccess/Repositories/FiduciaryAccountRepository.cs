using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SofttekFinalProjectBackend.DataAccess.Repositories.Interfaces;
using SofttekFinalProjectBackend.Entities;
using System.Security.Principal;

namespace SofttekFinalProjectBackend.DataAccess.Repositories
{
    public class FiduciaryAccountRepository : Repository<FiduciaryAccount>, IFiduciaryAccountRepository
    {
        private readonly IMapper _mapper;

        public FiduciaryAccountRepository(ContextDB contextDB, IMapper mapper) : base(contextDB)
        {
            _mapper = mapper;

        }
        public virtual async Task<List<FiduciaryAccount>> GetAllAccountInPesos()
        {
            try
            {
                var fiduciaryAccounts = await base.GetAll();

                fiduciaryAccounts = fiduciaryAccounts.Where(fiduciaryAccount => fiduciaryAccount.TypeOfAccount == TypeOfAccount.Pesos).ToList();
                return fiduciaryAccounts;
            }
            catch (Exception)
            {
                return null;
            }
        }
        public virtual async Task<FiduciaryAccount> GetAccount(string cbu, string alias, string accountNumber)
        {
            try
            {
                cbu = cbu.ToLower();
                alias = alias.ToLower(); 
                accountNumber = accountNumber.ToLower(); 

                var entity = await _contextDB.Set<FiduciaryAccount>()
                    .FirstOrDefaultAsync(account =>
                        account.Cbu.ToLower() == cbu ||
                        account.Alias.ToLower() == alias ||
                        account.AccountNumber.ToLower() == accountNumber);

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }



        public virtual async Task<FiduciaryAccount> GetAccountInPesos(int userId)
        {
            try
            {
                var entity = await _contextDB.Set<FiduciaryAccount>()
                    .FirstOrDefaultAsync(account =>
                        account.UserId == userId &&
                        account.TypeOfAccount == TypeOfAccount.Pesos);

                return entity;
            }
            catch (Exception)
            {
                return null;
            }
        }

    }
}
