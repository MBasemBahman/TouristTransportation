using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.CompanyTripModels;

namespace Repository.DBModels.CarModels
{
    public class CarCategoryRepository : RepositoryBase<CarCategory>
    {
        public CarCategoryRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CarCategory> FindAll(CarCategoryParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<CarCategory> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.CarCategoryLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(CarCategory entity)
        {
            entity.CarCategoryLangs ??= new List<CarCategoryLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CarCategoryLangs.All(b => b.Language != language))
                {
                    entity.CarCategoryLangs.Add(new CarCategoryLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class CarCategoryRepositoryExtension
    {
        public static IQueryable<CarCategory> Filter(
            this IQueryable<CarCategory> accounts,
            int id)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) );
        }
    }
}
