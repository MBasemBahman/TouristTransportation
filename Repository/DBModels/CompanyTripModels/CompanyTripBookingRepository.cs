using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CompanyTripModels
{
    public class CompanyTripBookingRepository : RepositoryBase<CompanyTripBooking>
    {
        public CompanyTripBookingRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CompanyTripBooking> FindAll(CompanyTripBookingParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_CompanyTrip,
                       parameters.Fk_Account,
                       parameters.Fk_Currency,
                       parameters.Fk_CompanyTripBookingState);

        }

        public async Task<CompanyTripBooking> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(CompanyTripBooking entity)
        {
            base.Create(entity);
        }
    }

    public static class CompanyTripBookingRepositoryExtension
    {
        public static IQueryable<CompanyTripBooking> Filter(
            this IQueryable<CompanyTripBooking> accounts,
            int id,
            int fk_CompanyTrip,
            int fk_Account,
            int fk_Currency,
            int fk_CompanyTripBookingState)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_CompanyTrip == 0 || a.Fk_CompanyTrip == fk_CompanyTrip) &&
                                       (fk_Account == 0 || a.Fk_Account == fk_Account) &&
                                       (fk_Currency == 0 || a.Fk_Currency == fk_Currency) &&
                                       (fk_CompanyTripBookingState == 0 || a.Fk_CompanyTripBookingState == fk_CompanyTripBookingState));
        }
    }
}
