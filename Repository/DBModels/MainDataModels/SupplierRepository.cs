using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;

namespace Repository.DBModels.MainDataModels
{
    public class SupplierRepository : RepositoryBase<Supplier>
    {
        public SupplierRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Supplier> FindAll(SupplierParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);

        }

        public async Task<Supplier> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(Supplier entity)
        {
            entity.SupplierLangs ??= new List<SupplierLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.SupplierLangs.All(b => b.Language != language))
                {
                    entity.SupplierLangs.Add(new SupplierLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class SupplierRepositoryExtension
    {
        public static IQueryable<Supplier> Filter(
            this IQueryable<Supplier> accounts,
            int id)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) );
        }
    }
}
