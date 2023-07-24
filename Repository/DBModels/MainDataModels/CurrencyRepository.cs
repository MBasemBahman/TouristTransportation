using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;

namespace Repository.DBModels.MainDataModels
{
    public class CurrencyRepository : RepositoryBase<Currency>
    {
        public CurrencyRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Currency> FindAll(CurrencyParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);

        }

        public async Task<Currency> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a=>a.CurrencyLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(Currency entity)
        {
            entity.CurrencyLangs ??= new List<CurrencyLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CurrencyLangs.All(b => b.Language != language))
                {
                    entity.CurrencyLangs.Add(new CurrencyLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            
            base.Create(entity);
        }
    }

    public static class CurrencyRepositoryExtension
    {
        public static IQueryable<Currency> Filter(
            this IQueryable<Currency> accounts,
            int id)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) );
        }
    }
}
