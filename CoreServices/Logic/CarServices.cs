using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.CarModels;
using Entities.EnumData;

namespace CoreServices.Logic
{
    public class CarServices
    {
        private readonly RepositoryManager _repository;

        public CarServices(RepositoryManager repository)
        {
            _repository = repository;
        }
        
        #region CarCategory Services

        public IQueryable<CarCategoryModel> GetCarCategories(
            CarCategoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CarCategory
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CarCategoryModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CarCategoryLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  ColorCode = a.ColorCode,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CarCategoryModel>> GetCarCategoriesPaged(
            CarCategoryParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CarCategoryModel>.ToPagedList(GetCarCategories(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CarCategoryModel>> GetCarCategoriesPaged(
          IQueryable<CarCategoryModel> data,
         CarCategoryParameters parameters)
        {
            return await PagedList<CarCategoryModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CarCategory> FindCarCategoryById(int id, bool trackChanges)
        {
            return await _repository.CarCategory.FindById(id, trackChanges);
        }

        public CarCategoryModel GetCarCategoryById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCarCategories(new CarCategoryParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCarCategory(CarCategory entity)
        {
            _repository.CarCategory.Create(entity);
        }

        public int GetCarCategoriesCount()
        {
            return _repository.CarCategory.Count();
        }
        public Dictionary<string, string> GetCarCategoriesLookUp(CarCategoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCarCategories(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public async Task DeleteCarCategory(int id)
        {
            CarCategory account = await _repository.CarCategory.FindById(id, trackChanges: false);

            _repository.CarCategory.Delete(account);
        }

        #endregion
        
        #region CarClass Services

        public IQueryable<CarClassModel> GetCarClasses(
            CarClassParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CarClass
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CarClassModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CarClassLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  Fk_CarCategory = a.Fk_CarCategory,
                                  CarCategory = new CarCategoryModel
                                  {
                                    Name  = language != null ? a.CarCategory.CarCategoryLangs
                                        .Where(b => b.Language == language)
                                        .Select(b => b.Name).FirstOrDefault() : a.CarCategory.Name,
                                  },
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CarClassModel>> GetCarClassesPaged(
            CarClassParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CarClassModel>.ToPagedList(GetCarClasses(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CarClassModel>> GetCarClassesPaged(
          IQueryable<CarClassModel> data,
         CarClassParameters parameters)
        {
            return await PagedList<CarClassModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CarClass> FindCarClassById(int id, bool trackChanges)
        {
            return await _repository.CarClass.FindById(id, trackChanges);
        }

        public CarClassModel GetCarClassById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCarClasses(new CarClassParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCarClass(CarClass entity)
        {
            _repository.CarClass.Create(entity);
        }

        public int GetCarClassesCount()
        {
            return _repository.CarClass.Count();
        }

        public async Task DeleteCarClass(int id)
        {
            CarClass account = await _repository.CarClass.FindById(id, trackChanges: false);

            _repository.CarClass.Delete(account);
        }

        #endregion
    }
}
