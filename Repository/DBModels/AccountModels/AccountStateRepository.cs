﻿using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.TripModels;

namespace Repository.DBModels.AccountModels
{
    public class AccountStateRepository : RepositoryBase<AccountState>
    {
        public AccountStateRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<AccountState> FindAll(AccountStateParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<AccountState> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a=>a.AccountStateLangs).SingleOrDefaultAsync();
        }

        public new void Create(AccountState entity)
        {
            entity.AccountStateLangs ??= new List<AccountStateLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.AccountStateLangs.All(b => b.Language != language))
                {
                    entity.AccountStateLangs.Add(new AccountStateLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class AccountStateRepositoryExtension
    {
        public static IQueryable<AccountState> Filter(
            this IQueryable<AccountState> accounts,
            int id)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) );
        }
    }
}
