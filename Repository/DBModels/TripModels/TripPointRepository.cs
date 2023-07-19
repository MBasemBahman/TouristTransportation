using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.TripModels;

namespace Repository.DBModels.TripModels
{
    public class TripPointRepository : RepositoryBase<TripPoint>
    {
        public TripPointRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<TripPoint> FindAll(TripPointParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Trip);
        }

        public async Task<TripPoint> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(TripPoint entity)
        {
            base.Create(entity);
        }
    }

    public static class TripPointRepositoryExtension
    {
        public static IQueryable<TripPoint> Filter(
            this IQueryable<TripPoint> accounts,
            int id,
            int fk_Trip)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Trip == 0 || a.Fk_Trip == fk_Trip) );
        }
    }
}
