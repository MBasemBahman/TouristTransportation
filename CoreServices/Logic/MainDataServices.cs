using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace CoreServices.Logic
{
    public class MainDataServices
    {
        private readonly RepositoryManager _repository;

        public MainDataServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Country Services

        public IQueryable<CountryModel> GetCountries(
            CountryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Country
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CountryModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CountryLangs
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

        public async Task<PagedList<CountryModel>> GetCountriesPaged(
            CountryParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CountryModel>.ToPagedList(GetCountries(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CountryModel>> GetCountriesPaged(
          IQueryable<CountryModel> data,
         CountryParameters parameters)
        {
            return await PagedList<CountryModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Country> FindCountryById(int id, bool trackChanges)
        {
            return await _repository.Country.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetCountriesLookUp(CountryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCountries(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public CountryModel GetCountryById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCountries(new CountryParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCountry(Country entity)
        {
            _repository.Country.Create(entity);
        }

        public int GetCountriesCount()
        {
            return _repository.Country.Count();
        }

        public async Task DeleteCountry(int id)
        {
            Country account = await _repository.Country.FindById(id, trackChanges: false);

            _repository.Country.Delete(account);
        }

        #endregion
        
        #region Area Services

        public IQueryable<AreaModel> GetAreas(
            AreaParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Area
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AreaModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.AreaLangs
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

        public async Task<PagedList<AreaModel>> GetAreasPaged(
            AreaParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<AreaModel>.ToPagedList(GetAreas(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<AreaModel>> GetAreasPaged(
          IQueryable<AreaModel> data,
         AreaParameters parameters)
        {
            return await PagedList<AreaModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Area> FindAreaById(int id, bool trackChanges)
        {
            return await _repository.Area.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetAreasLookUp(AreaParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetAreas(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public AreaModel GetAreaById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetAreas(new AreaParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateArea(Area entity)
        {
            _repository.Area.Create(entity);
        }

        public int GetAreasCount()
        {
            return _repository.Area.Count();
        }

        public async Task DeleteArea(int id)
        {
            Area row = await _repository.Area.FindById(id, trackChanges: false);

            _repository.Area.Delete(row);
        }

        #endregion
        
        #region Currency Services

        public IQueryable<CurrencyModel> GetCurrencies(
            CurrencyParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Currency
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CurrencyModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CurrencyLangs
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

        public async Task<PagedList<CurrencyModel>> GetCurrenciesPaged(
            CurrencyParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CurrencyModel>.ToPagedList(GetCurrencies(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CurrencyModel>> GetCurrenciesPaged(
          IQueryable<CurrencyModel> data,
         CurrencyParameters parameters)
        {
            return await PagedList<CurrencyModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Currency> FindCurrencyById(int id, bool trackChanges)
        {
            return await _repository.Currency.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetCurrenciesLookUp(CurrencyParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCurrencies(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public CurrencyModel GetCurrencyById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCurrencies(new CurrencyParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCurrency(Currency entity)
        {
            _repository.Currency.Create(entity);
        }

        public int GetCurrenciesCount()
        {
            return _repository.Currency.Count();
        }

        public async Task DeleteCurrency(int id)
        {
            Currency row = await _repository.Currency.FindById(id, trackChanges: false);

            _repository.Currency.Delete(row);
        }

        #endregion
    }
}
