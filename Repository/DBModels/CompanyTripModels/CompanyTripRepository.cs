using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CompanyTripModels
{
    public class CompanyTripRepository : RepositoryBase<CompanyTrip>
    {
        public CompanyTripRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CompanyTrip> FindAll(CompanyTripParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_CompanyTripState);

        }

        public async Task<CompanyTrip> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(CompanyTrip entity)
        {
            entity.CompanyTripLangs ??= new List<CompanyTripLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CompanyTripLangs.All(b => b.Language != language))
                {
                    entity.CompanyTripLangs.Add(new CompanyTripLang
                    {
                        Title = entity.Title,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class CompanyTripRepositoryExtension
    {
        public static IQueryable<CompanyTrip> Filter(
            this IQueryable<CompanyTrip> accounts,
            int id,
            int? fk_CompanyTripState)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_CompanyTripState == null || a.Fk_CompanyTripState == fk_CompanyTripState) );
        }
    }
}
