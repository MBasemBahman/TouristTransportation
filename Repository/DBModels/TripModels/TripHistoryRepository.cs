using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.TripModels;

namespace Repository.DBModels.TripModels
{
    public class TripHistoryRepository : RepositoryBase<TripHistory>
    {
        public TripHistoryRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<TripHistory> FindAll(TripHistoryParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Trip,
                       parameters.Fk_Supplier,
                       parameters.Fk_Driver,
                       parameters.Fk_TripState);
        }

        public async Task<TripHistory> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(TripHistory entity)
        {
            base.Create(entity);
        }
    }

    public static class TripHistoryRepositoryExtension
    {
        public static IQueryable<TripHistory> Filter(
            this IQueryable<TripHistory> accounts,
            int id,
            int fk_Trip,
            int? fk_Supplier,
            int? fk_Driver,
            int? fk_TripState)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Trip == 0 || a.Fk_Trip == fk_Trip) &&
                                       (fk_Supplier == null || a.Fk_Supplier == fk_Supplier) &&
                                       (fk_Driver == null || a.Fk_Driver == fk_Driver) &&
                                       (fk_TripState == null || a.Fk_TripState == fk_TripState) );
        }
    }
}
