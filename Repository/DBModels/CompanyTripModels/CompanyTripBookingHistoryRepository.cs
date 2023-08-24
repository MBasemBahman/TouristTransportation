using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CompanyTripModels
{
    public class CompanyTripBookingHistoryRepository : RepositoryBase<CompanyTripBookingHistory>
    {
        public CompanyTripBookingHistoryRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CompanyTripBookingHistory> FindAll(CompanyTripBookingHistoryParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_CompanyTripBooking);

        }

        public async Task<CompanyTripBookingHistory> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(CompanyTripBookingHistory entity)
        {
            base.Create(entity);
        }
    }

    public static class CompanyTripBookingHistoryRepositoryExtension
    {
        public static IQueryable<CompanyTripBookingHistory> Filter(
            this IQueryable<CompanyTripBookingHistory> accounts,
            int id,
            int fk_CompanyTripBooking)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_CompanyTripBooking == 0 || a.Fk_CompanyTripBooking == fk_CompanyTripBooking));
        }
    }
}
