using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
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
                                  Name = a.Name,
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

        public Dictionary<string, string> GetAccountsLookUp(AccountParameters parameters)
        {
            return GetAccounts(parameters).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

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
    }
}
