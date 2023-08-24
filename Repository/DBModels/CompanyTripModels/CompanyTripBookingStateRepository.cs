using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CompanyTripModels
{
    public class CompanyTripBookingStateRepository : RepositoryBase<CompanyTripBookingState>
    {
        public CompanyTripBookingStateRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CompanyTripBookingState> FindAll(CompanyTripBookingStateParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<CompanyTripBookingState> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(CompanyTripBookingState entity)
        {
            entity.CompanyTripBookingStateLangs ??= new List<CompanyTripBookingStateLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CompanyTripBookingStateLangs.All(b => b.Language != language))
                {
                    entity.CompanyTripBookingStateLangs.Add(new CompanyTripBookingStateLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class CompanyTripBookingStateRepositoryExtension
    {
        public static IQueryable<CompanyTripBookingState> Filter(
            this IQueryable<CompanyTripBookingState> accounts,
            int id)
        {
            return accounts.Where(a => id == 0 || a.Id == id);
        }
    }
}
