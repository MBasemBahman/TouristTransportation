using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;

namespace Repository.DBModels.AccountModels
{
    public class AccountRepository : RepositoryBase<Account>
    {
        public AccountRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Account> FindAll(AccountParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.EmailAddress,
                       parameters.Fk_AccountState,
                       parameters.Fk_AccountType,
                       parameters.Fk_Supplier,
                       parameters.Fk_User);

        }

        public async Task<Account> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.User)
                .SingleOrDefaultAsync();
        }

        public new void Create(Account entity)
        {
            
            base.Create(entity);
        }
    }

    public static class AccountRepositoryExtension
    {
        public static IQueryable<Account> Filter(
            this IQueryable<Account> accounts,
            int id,
            string emailAddress,
            int fk_AccountState,
            int fk_AccountType,
            int fk_Supplier,
            int? fk_User)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (string.IsNullOrEmpty(emailAddress) || a.EmailAddress == emailAddress) &&
                                       (fk_AccountState == 0 || a.Fk_AccountState == fk_AccountState) &&
                                       (fk_Supplier == 0 || a.Fk_Supplier == fk_Supplier) &&
                                       (fk_AccountType == 0 || a.Fk_AccountType == fk_AccountType) &&
                                       (fk_User == null || a.Fk_User == fk_User) );
        }
    }
}
