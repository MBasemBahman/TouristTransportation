using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.TripModels;

namespace Repository.DBModels.TripModels
{
    public class TripLocationRepository : RepositoryBase<TripLocation>
    {
        public TripLocationRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<TripLocation> FindAll(TripLocationParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Trip);
        }

        public async Task<TripLocation> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(TripLocation entity)
        {
            base.Create(entity);
        }
    }

    public static class TripLocationRepositoryExtension
    {
        public static IQueryable<TripLocation> Filter(
            this IQueryable<TripLocation> accounts,
            int id,
            int fk_Trip)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Trip == 0 || a.Fk_Trip == fk_Trip));
        }
    }
}
