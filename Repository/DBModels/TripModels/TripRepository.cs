using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.TripModels;

namespace Repository.DBModels.TripModels
{
    public class TripRepository : RepositoryBase<Trip>
    {
        public TripRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Trip> FindAll(TripParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Account,
                       parameters.Fk_Client,
                       parameters.Fk_Supplier,
                       parameters.Fk_Driver,
                       parameters.Fk_CarClass,
                       parameters.Fk_TripState);
        }

        public async Task<Trip> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(Trip entity)
        {
            base.Create(entity);
        }
    }

    public static class TripRepositoryExtension
    {
        public static IQueryable<Trip> Filter(
            this IQueryable<Trip> accounts,
            int id,
            int fk_Account,
            int fk_Client,
            int? fk_Supplier,
            int? fk_Driver,
            int? fk_CarClass,
            int? fk_TripState)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Account == 0 || a.Fk_Client == fk_Account || a.Fk_Driver == fk_Account) &&
                                       (fk_Client == 0 || a.Fk_Client == fk_Client) &&
                                       (fk_Supplier == null || a.Fk_Supplier == fk_Supplier) &&
                                       (fk_Driver == null || a.Fk_Driver == fk_Driver) &&
                                       (fk_CarClass == null || a.Fk_CarClass == fk_CarClass) &&
                                       (fk_TripState == null || a.Fk_TripState == fk_TripState));
        }
    }
}
