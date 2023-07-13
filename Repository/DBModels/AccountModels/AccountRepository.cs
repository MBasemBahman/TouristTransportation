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
                       parameters.EmailAddress);

        }

        public async Task<Account> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
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
            string emailAddress)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (string.IsNullOrEmpty(emailAddress) || a.EmailAddress == emailAddress) );
        }
    }
}
