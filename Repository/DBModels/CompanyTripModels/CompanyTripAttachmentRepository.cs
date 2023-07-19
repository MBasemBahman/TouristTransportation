using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CompanyTripModels
{
    public class CompanyTripAttachmentRepository : RepositoryBase<CompanyTripAttachment>
    {
        public CompanyTripAttachmentRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CompanyTripAttachment> FindAll(CompanyTripAttachmentParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_CompanyTrip);

        }

        public async Task<CompanyTripAttachment> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(CompanyTripAttachment entity)
        {
            base.Create(entity);
        }
    }

    public static class CompanyTripAttachmentRepositoryExtension
    {
        public static IQueryable<CompanyTripAttachment> Filter(
            this IQueryable<CompanyTripAttachment> accounts,
            int id,
            int fk_CompanyTrip)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_CompanyTrip == 0 || a.Fk_CompanyTrip == fk_CompanyTrip) );
        }
    }
}
