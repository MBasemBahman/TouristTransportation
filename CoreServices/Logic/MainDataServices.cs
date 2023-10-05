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
                                  LastModifiedBy = a.LastModifiedBy,
                                  Country = new CountryModel
                                  {
                                      Name = language != null ? a.Country.CountryLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Country.Name
                                  },
                                  Fk_Country = a.Fk_Country
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
                                  RateInPounds = a.RateInPounds,
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
        
        #region Supplier Services

        public IQueryable<SupplierModel> GetSuppliers(
            SupplierParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Supplier
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new SupplierModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.SupplierLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<SupplierModel>> GetSuppliersPaged(
            SupplierParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<SupplierModel>.ToPagedList(GetSuppliers(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<SupplierModel>> GetSuppliersPaged(
          IQueryable<SupplierModel> data,
         SupplierParameters parameters)
        {
            return await PagedList<SupplierModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Supplier> FindSupplierById(int id, bool trackChanges)
        {
            return await _repository.Supplier.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetSuppliersLookUp(SupplierParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetSuppliers(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public SupplierModel GetSupplierById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetSuppliers(new SupplierParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateSupplier(Supplier entity)
        {
            _repository.Supplier.Create(entity);
        }

        public int GetSuppliersCount()
        {
            return _repository.Supplier.Count();
        }

        public async Task DeleteSupplier(int id)
        {
            Supplier row = await _repository.Supplier.FindById(id, trackChanges: false);

            _repository.Supplier.Delete(row);
        }

        #endregion
        
        #region AppAbout Services
        public IQueryable<AppAboutModel> GetAppAbouts(RequestParameters parameters,
            DBModelsEnum.LanguageEnum? language)
        {
            return _repository.AppAbout
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new AppAboutModel
                       {
                           AboutCompany = language != null ? a.AppAboutLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.AboutCompany).FirstOrDefault() : a.AboutCompany,
                           AboutApp = language != null ? a.AppAboutLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.AboutApp).FirstOrDefault() : a.AboutApp,
                           TermsAndConditions = language != null ? a.AppAboutLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.TermsAndConditions).FirstOrDefault() : a.TermsAndConditions,
                           EarningMoney = language != null ? a.AppAboutLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.EarningMoney).FirstOrDefault() : a.EarningMoney,
                           QuestionsAndAnswer = language != null ? a.AppAboutLangs
                               .Where(b => b.Language == language)
                               .Select(b => b.QuestionsAndAnswer).FirstOrDefault() : a.QuestionsAndAnswer,
                           Phone = a.Phone,
                           WhatsApp = a.WhatsApp,
                           EmailAddress = a.EmailAddress,
                           TwitterUrl = a.TwitterUrl,
                           FacebookUrl = a.FacebookUrl,
                           InstagramUrl = a.InstagramUrl,
                           SnapChatUrl = a.SnapChatUrl,
                           YoutubeUrl = a.YoutubeUrl,
                           TiktokUrl = a.TiktokUrl,
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           CreatedBy = a.CreatedBy,
                           LastModifiedAt = a.LastModifiedAt,
                           LastModifiedBy = a.LastModifiedBy,
                       })
                       .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }


        public async Task<PagedList<AppAboutModel>> GetAppAboutsPaged(
                  RequestParameters parameters,
                  DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<AppAboutModel>.ToPagedList(GetAppAbouts(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<AppAbout> FindAppAboutById(int id, bool trackChanges)
        {
            return await _repository.AppAbout.FindById(id, trackChanges);
        }

        public async Task<AppAbout> FindAppAbout(bool trackChanges)
        {
            return await _repository.AppAbout.Find(trackChanges);
        }

        public void CreateAppAbout(AppAbout appAbout)
        {
            _repository.AppAbout.Create(appAbout);
        }

        public async Task DeleteAppAbout(int id)
        {
            AppAbout appAbout = await FindAppAboutById(id, trackChanges: true);
            _repository.AppAbout.Delete(appAbout);
        }

        public AppAboutModel GetAppAboutById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetAppAbouts(new RequestParameters { Id = id }, language).FirstOrDefault();
        }

        public int GetAppAboutCount()
        {
            return _repository.AppAbout.Count();
        }
        #endregion
    }
}
