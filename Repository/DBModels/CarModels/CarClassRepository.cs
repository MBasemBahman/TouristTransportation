using Entities.CoreServicesModels.CarModels;
using Entities.DBModels.CarModels;

namespace Repository.DBModels.CarModels
{
    public class CarClassRepository : RepositoryBase<CarClass>
    {
        public CarClassRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<CarClass> FindAll(CarClassParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_CarCategory);
        }

        public async Task<CarClass> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .Include(a => a.CarClassLangs)
                .SingleOrDefaultAsync();
        }

        public new void Create(CarClass entity)
        {
            entity.CarClassLangs ??= new List<CarClassLang>();
            
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.CarClassLangs.All(b => b.Language != language))
                {
                    entity.CarClassLangs.Add(new CarClassLang
                    {
                        Name = entity.Name,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }
    }

    public static class CarClassRepositoryExtension
    {
        public static IQueryable<CarClass> Filter(
            this IQueryable<CarClass> accounts,
            int id,
            int fk_CarCategory)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_CarCategory == 0 || a.Fk_CarCategory == fk_CarCategory) );
        }
    }
}
