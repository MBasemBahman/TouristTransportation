using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.TripModels;

namespace Repository.DBModels.TripModels
{
    public class TripStateRepository : RepositoryBase<TripState>
    {
        public TripStateRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<TripState> FindAll(TripStateParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<TripState> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.TripStateLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(TripState entity)
        {
            entity.TripStateLangs ??= new List<TripStateLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.TripStateLangs.All(b => b.Language != language))
                {
                    entity.TripStateLangs.Add(new TripStateLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class TripStateRepositoryExtension
    {
        public static IQueryable<TripState> Filter(
            this IQueryable<TripState> accounts,
            int id)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) );
        }
    }
}
