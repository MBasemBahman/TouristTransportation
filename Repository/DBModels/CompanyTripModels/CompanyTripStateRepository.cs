using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CompanyTripModels
{
    public class CompanyTripStateRepository : RepositoryBase<CompanyTripState>
    {
        public CompanyTripStateRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CompanyTripState> FindAll(CompanyTripStateParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<CompanyTripState> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.CompanyTripStateLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(CompanyTripState entity)
        {
            entity.CompanyTripStateLangs ??= new List<CompanyTripStateLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CompanyTripStateLangs.All(b => b.Language != language))
                {
                    entity.CompanyTripStateLangs.Add(new CompanyTripStateLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class CompanyTripStateRepositoryExtension
    {
        public static IQueryable<CompanyTripState> Filter(
            this IQueryable<CompanyTripState> accounts,
            int id)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) );
        }
    }
}
