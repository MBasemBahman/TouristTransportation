using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.EnumData;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;

namespace CoreServices.Logic
{
    public class AccountServices
    {
        private readonly RepositoryManager _repository;
        private readonly IConfiguration _config;

        public AccountServices(RepositoryManager repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        #region Account Services

        public IQueryable<AccountModel> GetAccounts(
            AccountParameters parameters)
        {
            return _repository.Account
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AccountModel
                              {
                                  Id = a.Id,
                                  Phone = a.Phone,
                                  EmailAddress = a.EmailAddress,
                                  ImageUrl = a.StorageUrl + a.ImageUrl,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<AccountModel>> GetAccountsPaged(
            AccountParameters parameters)
        {
            return await PagedList<AccountModel>.ToPagedList(GetAccounts(parameters), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<AccountModel>> GetAccountsPaged(
          IQueryable<AccountModel> data,
         AccountParameters parameters)
        {
            return await PagedList<AccountModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Account> FindAccountById(int id, bool trackChanges)
        {
            return await _repository.Account.FindById(id, trackChanges);
        }

        public async Task<string> UploadAccountImage(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/Account");
        }

        // public Dictionary<string, string> GetAccountsLookUp(AccountParameters parameters)
        // {
        //     return GetAccounts(parameters).ToDictionary(a => a.Id.ToString(), a => a.Name);
        // }

        public AccountModel GetAccountById(int id)
        {
            return GetAccounts(new AccountParameters { Id = id }).SingleOrDefault();
        }

        public AccountModel GetAccountByEmailAddress(string emailAddress)
        {
            return !string.IsNullOrEmpty(emailAddress) ?
                GetAccounts(new AccountParameters { EmailAddress = emailAddress }).SingleOrDefault() : null;
        }

        public void CreateAccount(Account entity)
        {
            _repository.Account.Create(entity);
        }

        public int GetAccountsCount()
        {
            return _repository.Account.Count();
        }

        public async Task DeleteAccount(int id)
        {
            Account account = await _repository.Account.FindById(id, trackChanges: false);

            _repository.Account.Delete(account);
        }

        #endregion
        
        #region AccountType Services

        public IQueryable<AccountTypeModel> GetAccountTypes(
            AccountTypeParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.AccountType
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AccountTypeModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.AccountTypeLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  ColorCode = a.ColorCode,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<AccountTypeModel>> GetAccountTypesPaged(
            AccountTypeParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<AccountTypeModel>.ToPagedList(GetAccountTypes(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<AccountTypeModel>> GetAccountTypesPaged(
          IQueryable<AccountTypeModel> data,
         AccountTypeParameters parameters)
        {
            return await PagedList<AccountTypeModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<AccountType> FindAccountTypeById(int id, bool trackChanges)
        {
            return await _repository.AccountType.FindById(id, trackChanges);
        }

        public AccountTypeModel GetAccountTypeById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetAccountTypes(new AccountTypeParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateAccountType(AccountType entity)
        {
            _repository.AccountType.Create(entity);
        }

        public int GetAccountTypesCount()
        {
            return _repository.AccountType.Count();
        }

        public async Task DeleteAccountType(int id)
        {
            AccountType account = await _repository.AccountType.FindById(id, trackChanges: false);

            _repository.AccountType.Delete(account);
        }

        #endregion
        
        #region AccountState Services

        public IQueryable<AccountStateModel> GetAccountStates(
            AccountStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.AccountState
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new AccountStateModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.AccountStateLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  ColorCode = a.ColorCode,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<AccountStateModel>> GetAccountStatesPaged(
            AccountStateParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<AccountStateModel>.ToPagedList(GetAccountStates(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<AccountStateModel>> GetAccountStatesPaged(
          IQueryable<AccountStateModel> data,
         AccountStateParameters parameters)
        {
            return await PagedList<AccountStateModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<AccountState> FindAccountStateById(int id, bool trackChanges)
        {
            return await _repository.AccountState.FindById(id, trackChanges);
        }

        public AccountStateModel GetAccountStateById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetAccountStates(new AccountStateParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateAccountState(AccountState entity)
        {
            _repository.AccountState.Create(entity);
        }

        public int GetAccountStatesCount()
        {
            return _repository.AccountState.Count();
        }

        public async Task DeleteAccountState(int id)
        {
            AccountState account = await _repository.AccountState.FindById(id, trackChanges: false);

            _repository.AccountState.Delete(account);
        }

        #endregion
    }
}
