using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;
using Entities.EnumData;
using Microsoft.AspNetCore.Http;

namespace CoreServices.Logic
{
    public class CompanyTripServices
    {
        private readonly RepositoryManager _repository;

        public CompanyTripServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region CompanyTripState Services

        public IQueryable<CompanyTripStateModel> GetCompanyTripStates(
            CompanyTripStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CompanyTripState
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CompanyTripStateModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CompanyTripStateLangs
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

        public async Task<PagedList<CompanyTripStateModel>> GetCompanyTripStatesPaged(CompanyTripStateParameters parameters, 
            DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CompanyTripStateModel>.ToPagedList(GetCompanyTripStates(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public Dictionary<string, string> GetCompanyTripBookingStatesLookUp(CompanyTripBookingStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripBookingStates(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }
        
        public async Task<PagedList<CompanyTripStateModel>> GetCompanyTripStatesPaged(
          IQueryable<CompanyTripStateModel> data,
         CompanyTripStateParameters parameters)
        {
            return await PagedList<CompanyTripStateModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CompanyTripState> FindCompanyTripStateById(int id, bool trackChanges)
        {
            return await _repository.CompanyTripState.FindById(id, trackChanges);
        }
        
        public Dictionary<string, string> GetCompanyTripStatesLookUp(CompanyTripStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripStates(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }
        
        public CompanyTripStateModel GetCompanyTripStateById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripStates(new CompanyTripStateParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCompanyTripState(CompanyTripState entity)
        {
            _repository.CompanyTripState.Create(entity);
        }

        public int GetCompanyTripStatesCount()
        {
            return _repository.CompanyTripState.Count();
        }

        public async Task DeleteCompanyTripState(int id)
        {
            CompanyTripState account = await _repository.CompanyTripState.FindById(id, trackChanges: false);

            _repository.CompanyTripState.Delete(account);
        }

        #endregion
        
        #region CompanyTrip Attachment Services

        public IQueryable<CompanyTripAttachmentModel> GetCompanyTripAttachments(
            CompanyTripAttachmentParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CompanyTripAttachment
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CompanyTripAttachmentModel
                              {
                                  Id = a.Id,
                                  Fk_CompanyTrip = a.Fk_CompanyTrip,
                                  CompanyTrip = new CompanyTripModel
                                  {
                                      Title = language != null ? a.CompanyTrip.CompanyTripLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Title).FirstOrDefault() : a.CompanyTrip.Title,
                                  },
                                  FileUrl = a.StorageUrl + a.FileUrl,
                                  FileLength = a.FileLength,
                                  FileName = a.FileName,
                                  FileType = a.FileType,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CompanyTripAttachmentModel>> GetCompanyTripAttachmentsPaged(
            CompanyTripAttachmentParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CompanyTripAttachmentModel>.ToPagedList(GetCompanyTripAttachments(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CompanyTripAttachmentModel>> GetCompanyTripAttachmentsPaged(
          IQueryable<CompanyTripAttachmentModel> data,
         CompanyTripAttachmentParameters parameters)
        {
            return await PagedList<CompanyTripAttachmentModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CompanyTripAttachment> FindCompanyTripAttachmentById(int id, bool trackChanges)
        {
            return await _repository.CompanyTripAttachment.FindById(id, trackChanges);
        }
        
        public CompanyTripAttachmentModel GetCompanyTripAttachmentById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripAttachments(new CompanyTripAttachmentParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCompanyTripAttachment(CompanyTripAttachment entity)
        {
            _repository.CompanyTripAttachment.Create(entity);
        }

        public int GetCompanyTripAttachmentsCount()
        {
            return _repository.CompanyTripAttachment.Count();
        }

        public async Task DeleteCompanyTripAttachment(int id)
        {
            CompanyTripAttachment account = await _repository.CompanyTripAttachment.FindById(id, trackChanges: false);

            _repository.CompanyTripAttachment.Delete(account);
        }

        #endregion 
        
        #region CompanyTrip Services

        public IQueryable<CompanyTripModel> GetCompanyTrips(
            CompanyTripParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CompanyTrip
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CompanyTripModel
                              {
                                  Id = a.Id,
                                  Title = language != null ? a.CompanyTripLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Title).FirstOrDefault() : a.Title,
                                  Fk_CompanyTripState = a.Fk_CompanyTripState,
                                  CompanyTripState = new CompanyTripStateModel
                                  {
                                      Name = language != null ? a.CompanyTripState.CompanyTripStateLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.CompanyTripState.Name,
                                  },
                                  Price = a.Price,
                                  Notes = a.Notes,
                                  Description = a.Description,
                                  ImageUrl = !string.IsNullOrEmpty(a.ImageUrl) ? a.StorageUrl + a.ImageUrl : "/trip.png",
                                  AttachmentsCount = a.CompanyTripAttachments.Count,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CompanyTripModel>> GetCompanyTripsPaged(
            CompanyTripParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CompanyTripModel>.ToPagedList(GetCompanyTrips(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public Dictionary<string, string> GetCompanyTripsLookUp(CompanyTripParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTrips(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Title);
        }
        
        public async Task<string> UploadCompanyTripAttachment(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/CompanyTripAttachment");
        }
        
        public async Task<PagedList<CompanyTripModel>> GetCompanyTripsPaged(
          IQueryable<CompanyTripModel> data,
         CompanyTripParameters parameters)
        {
            return await PagedList<CompanyTripModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CompanyTrip> FindCompanyTripById(int id, bool trackChanges)
        {
            return await _repository.CompanyTrip.FindById(id, trackChanges);
        }
        
        public CompanyTripModel GetCompanyTripById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTrips(new CompanyTripParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCompanyTrip(CompanyTrip entity)
        {
            _repository.CompanyTrip.Create(entity);
        }

        public int GetCompanyTripsCount()
        {
            return _repository.CompanyTrip.Count();
        }

        public async Task DeleteCompanyTrip(int id)
        {
            CompanyTrip account = await _repository.CompanyTrip.FindById(id, trackChanges: false);

            _repository.CompanyTrip.Delete(account);
        }

        #endregion 
        
        #region CompanyTripBookingState Services

        public IQueryable<CompanyTripBookingStateModel> GetCompanyTripBookingStates(
            CompanyTripBookingStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CompanyTripBookingState
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CompanyTripBookingStateModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.CompanyTripBookingStateLangs
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

        public async Task<PagedList<CompanyTripBookingStateModel>> GetCompanyTripBookingStatesPaged(CompanyTripBookingStateParameters parameters, 
            DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CompanyTripBookingStateModel>.ToPagedList(GetCompanyTripBookingStates(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CompanyTripBookingStateModel>> GetCompanyTripBookingStatesPaged(
          IQueryable<CompanyTripBookingStateModel> data,
         CompanyTripBookingStateParameters parameters)
        {
            return await PagedList<CompanyTripBookingStateModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CompanyTripBookingState> FindCompanyTripBookingStateById(int id, bool trackChanges)
        {
            return await _repository.CompanyTripBookingState.FindById(id, trackChanges);
        }
        
        public CompanyTripBookingStateModel GetCompanyTripBookingStateById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripBookingStates(new CompanyTripBookingStateParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCompanyTripBookingState(CompanyTripBookingState entity)
        {
            _repository.CompanyTripBookingState.Create(entity);
        }

        public int GetCompanyTripBookingStatesCount()
        {
            return _repository.CompanyTripBookingState.Count();
        }

        public async Task DeleteCompanyTripBookingState(int id)
        {
            CompanyTripBookingState account = await _repository.CompanyTripBookingState.FindById(id, trackChanges: false);

            _repository.CompanyTripBookingState.Delete(account);
        }

        #endregion
        
        #region CompanyTripBooking Services

        public IQueryable<CompanyTripBookingModel> GetCompanyTripBookings(
            CompanyTripBookingParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CompanyTripBooking
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CompanyTripBookingModel
                              {
                                  Id = a.Id,
                                  Fk_Account = a.Fk_Account,
                                  Price = a.Price,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CompanyTripBookingModel>> GetCompanyTripBookingsPaged(CompanyTripBookingParameters parameters, 
            DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CompanyTripBookingModel>.ToPagedList(GetCompanyTripBookings(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CompanyTripBookingModel>> GetCompanyTripBookingsPaged(
          IQueryable<CompanyTripBookingModel> data,
         CompanyTripBookingParameters parameters)
        {
            return await PagedList<CompanyTripBookingModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CompanyTripBooking> FindCompanyTripBookingById(int id, bool trackChanges)
        {
            return await _repository.CompanyTripBooking.FindById(id, trackChanges);
        }
        
        public CompanyTripBookingModel GetCompanyTripBookingById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripBookings(new CompanyTripBookingParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCompanyTripBooking(CompanyTripBooking entity)
        {
            _repository.CompanyTripBooking.Create(entity);
        }

        public int GetCompanyTripBookingsCount()
        {
            return _repository.CompanyTripBooking.Count();
        }

        public async Task DeleteCompanyTripBooking(int id)
        {
            CompanyTripBooking account = await _repository.CompanyTripBooking.FindById(id, trackChanges: false);

            _repository.CompanyTripBooking.Delete(account);
        }

        #endregion
        
        #region CompanyTripBookingHistory Services

        public IQueryable<CompanyTripBookingHistoryModel> GetCompanyTripBookingHistories(
            CompanyTripBookingHistoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.CompanyTripBookingHistory
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new CompanyTripBookingHistoryModel
                              {
                                  Id = a.Id,
                                  Fk_CompanyTripBooking = a.Fk_CompanyTripBooking,
                                  Fk_CompanyTripBookingState = a.Fk_CompanyTripBookingState,
                                  Notes = a.Notes,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<CompanyTripBookingHistoryModel>> GetCompanyTripBookingHistoriesPaged(CompanyTripBookingHistoryParameters parameters, 
            DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<CompanyTripBookingHistoryModel>.ToPagedList(GetCompanyTripBookingHistories(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<CompanyTripBookingHistoryModel>> GetCompanyTripBookingHistoriesPaged(
          IQueryable<CompanyTripBookingHistoryModel> data,
         CompanyTripBookingHistoryParameters parameters)
        {
            return await PagedList<CompanyTripBookingHistoryModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<CompanyTripBookingHistory> FindCompanyTripBookingHistoryById(int id, bool trackChanges)
        {
            return await _repository.CompanyTripBookingHistory.FindById(id, trackChanges);
        }
        
        public CompanyTripBookingHistoryModel GetCompanyTripBookingHistoryById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetCompanyTripBookingHistories(new CompanyTripBookingHistoryParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateCompanyTripBookingHistory(CompanyTripBookingHistory entity)
        {
            _repository.CompanyTripBookingHistory.Create(entity);
        }

        public int GetCompanyTripBookingHistoriesCount()
        {
            return _repository.CompanyTripBookingHistory.Count();
        }

        public async Task DeleteCompanyTripBookingHistory(int id)
        {
            CompanyTripBookingHistory account = await _repository.CompanyTripBookingHistory.FindById(id, trackChanges: false);

            _repository.CompanyTripBookingHistory.Delete(account);
        }

        #endregion
    }
}
