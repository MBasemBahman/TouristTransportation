using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;
using Microsoft.AspNetCore.Http;

namespace CoreServices.Logic
{
    public class HotelServices
    {
        private readonly RepositoryManager _repository;

        public HotelServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Hotel Services

        public IQueryable<HotelModel> GetHotels(
            HotelParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Hotel
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.HotelLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  Address = a.Address,
                                  Description = a.Description,
                                  Rate = a.Rate,
                                  AttachmentsCount = a.HotelAttachments.Count,
                                  BookingUrl = a.BookingUrl,
                                  Fk_Area = a.Fk_Area,
                                  Area = new AreaModel
                                  {
                                      Name = language != null ? a.Area.AreaLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  },
                                  HotelSelectedFeatures = parameters.IncludeSelectedFeature == true ? a.HotelSelectedFeatures
                                      .GroupBy(b => b.HotelFeature.HotelFeatureCategory)
                                      .SelectMany(group => group.Select(b => new HotelSelectedFeaturesModel
                                      {
                                          HotelFeature = new HotelFeatureModel
                                          { 
                                              Id = b.Fk_HotelFeature,
                                              // You can add more properties of HotelFeatureModel if needed
                                          }
                                      })).ToList() : null,
                                  ImageUrl = a.StorageUrl + a.ImageUrl,
                                  LocationUrl = a.LocationUrl,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelModel>> GetHotelsPaged(
            HotelParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<HotelModel>.ToPagedList(GetHotels(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<HotelModel>> GetHotelsPaged(
          IQueryable<HotelModel> data,
         HotelParameters parameters)
        {
            return await PagedList<HotelModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Hotel> FindHotelById(int id, bool trackChanges)
        {
            return await _repository.Hotel.FindById(id, trackChanges);
        }

        public Dictionary<string, string> GetHotelsLookUp(HotelParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotels(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public Dictionary<string, string> GetHotelFeaturesLookUp(HotelFeatureParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotelFeatures(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public Dictionary<string, string> GetHotelFeatureCategorysLookUp(HotelFeatureCategoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotelFeatureCategories(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }

        public HotelModel GetHotelById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotels(new HotelParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateHotel(Hotel entity)
        {
            _repository.Hotel.Create(entity);
        }

        public int GetHotelsCount()
        {
            return _repository.Hotel.Count();
        }

        public async Task DeleteHotel(int id)
        {
            Hotel account = await _repository.Hotel.FindById(id, trackChanges: false);

            _repository.Hotel.Delete(account);
        }

        #endregion
        
        #region Hotel Attachment Services

        public IQueryable<HotelAttachmentModel> GetHotelAttachments(
            HotelAttachmentParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.HotelAttachment
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelAttachmentModel
                              {
                                  Id = a.Id,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Hotel = new HotelModel
                                  {
                                      Name = language != null ? a.Hotel.HotelLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.Hotel.Name, 
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

        public async Task<PagedList<HotelAttachmentModel>> GetHotelAttachmentsPaged(
            HotelAttachmentParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<HotelAttachmentModel>.ToPagedList(GetHotelAttachments(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<HotelAttachmentModel>> GetHotelAttachmentsPaged(
          IQueryable<HotelAttachmentModel> data,
         HotelAttachmentParameters parameters)
        {
            return await PagedList<HotelAttachmentModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelAttachment> FindHotelAttachmentById(int id, bool trackChanges)
        {
            return await _repository.HotelAttachment.FindById(id, trackChanges);
        }
        
        public async Task<string> UploadHotelAttachment(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/Hotel");
        }

        public HotelAttachmentModel GetHotelAttachmentById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotelAttachments(new HotelAttachmentParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateHotelAttachment(HotelAttachment entity)
        {
            _repository.HotelAttachment.Create(entity);
        }

        public int GetHotelAttachmentsCount()
        {
            return _repository.HotelAttachment.Count();
        }

        public async Task DeleteHotelAttachment(int id)
        {
            HotelAttachment account = await _repository.HotelAttachment.FindById(id, trackChanges: false);

            _repository.HotelAttachment.Delete(account);
        }

        #endregion
        
        #region HotelFeature Services

        public IQueryable<HotelFeatureModel> GetHotelFeatures(
            HotelFeatureParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.HotelFeature
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelFeatureModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.HotelFeatureLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  Fk_HotelFeatureCategory = a.Fk_HotelFeatureCategory,
                                  HotelFeatureCategory = new HotelFeatureCategoryModel
                                  {
                                      Name = language != null ? a.HotelFeatureCategory.HotelFeatureCategoryLangs
                                          .Where(b => b.Language == language)
                                          .Select(b => b.Name).FirstOrDefault() : a.HotelFeatureCategory.Name,
                                  },
                                  ColorCode = a.ColorCode,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelFeatureModel>> GetHotelFeaturesPaged(
            HotelFeatureParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<HotelFeatureModel>.ToPagedList(GetHotelFeatures(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<HotelFeatureModel>> GetHotelFeaturesPaged(
          IQueryable<HotelFeatureModel> data,
         HotelFeatureParameters parameters)
        {
            return await PagedList<HotelFeatureModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public void UpdateHotelFeatures(int fk_Hotel, List<int> hotelFeatures)
        {
            if (!hotelFeatures.Any()) return;

            List<int> oldIds = _repository.HotelSelectedFeatures.FindAll(new HotelSelectedFeaturesParameters
            {
                Fk_Hotel = fk_Hotel
            }, trackChanges: false).Select(a => a.Fk_HotelFeature).ToList();

            List<int> newIds = hotelFeatures.Except(oldIds).ToList();

            foreach (int fk_HotelFeature in newIds)
            {
                _repository.HotelSelectedFeatures.Create(new HotelSelectedFeatures
                {
                    Fk_Hotel = fk_Hotel,
                    Fk_HotelFeature = fk_HotelFeature,
                });
            }
            
            List<int> removedIds = oldIds.Except(hotelFeatures).ToList();
            
            foreach (int fk_HotelFeature in removedIds)
            {
                HotelSelectedFeatures entity = _repository.HotelSelectedFeatures
                    .FindAll(new HotelSelectedFeaturesParameters
                    {
                        Fk_Hotel = fk_Hotel,
                        Fk_HotelFeature = fk_HotelFeature
                    }, trackChanges: false)
                    .FirstOrDefault();
                
                _repository.HotelSelectedFeatures.Delete(entity);
            }
        }
        
        public async Task<HotelFeature> FindHotelFeatureById(int id, bool trackChanges)
        {
            return await _repository.HotelFeature.FindById(id, trackChanges);
        }

        public HotelFeatureModel GetHotelFeatureById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotelFeatures(new HotelFeatureParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateHotelFeature(HotelFeature entity)
        {
            _repository.HotelFeature.Create(entity);
        }

        public int GetHotelFeaturesCount()
        {
            return _repository.HotelFeature.Count();
        }

        public async Task DeleteHotelFeature(int id)
        {
            HotelFeature account = await _repository.HotelFeature.FindById(id, trackChanges: false);

            _repository.HotelFeature.Delete(account);
        }

        #endregion
        
        #region HotelFeatureCategory Services

        public IQueryable<HotelFeatureCategoryModel> GetHotelFeatureCategories(
            HotelFeatureCategoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.HotelFeatureCategory
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelFeatureCategoryModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.HotelFeatureCategoryLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Name,
                                  ColorCode = a.ColorCode,
                                  HotelFeatures = parameters.IncludeHotelFeatures == true ? 
                                      a.HotelFeatures.Select(b => new HotelFeatureModel
                                      {
                                          Id = b.Id,
                                          Name = language != null ? b.HotelFeatureLangs
                                              .Where(c => c.Language == language)
                                              .Select(c => c.Name).FirstOrDefault() : b.Name,
                                      }).ToList() : null,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelFeatureCategoryModel>> GetHotelFeatureCategoriesPaged(
            HotelFeatureCategoryParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<HotelFeatureCategoryModel>.ToPagedList(GetHotelFeatureCategories(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<HotelFeatureCategoryModel>> GetHotelFeatureCategoriesPaged(
          IQueryable<HotelFeatureCategoryModel> data,
         HotelFeatureCategoryParameters parameters)
        {
            return await PagedList<HotelFeatureCategoryModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelFeatureCategory> FindHotelFeatureCategoryById(int id, bool trackChanges)
        {
            return await _repository.HotelFeatureCategory.FindById(id, trackChanges);
        }

        public HotelFeatureCategoryModel GetHotelFeatureCategoryById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotelFeatureCategories(new HotelFeatureCategoryParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateHotelFeatureCategory(HotelFeatureCategory entity)
        {
            _repository.HotelFeatureCategory.Create(entity);
        }

        public int GetHotelFeatureCategoriesCount()
        {
            return _repository.HotelFeatureCategory.Count();
        }

        public async Task DeleteHotelFeatureCategory(int id)
        {
            HotelFeatureCategory account = await _repository.HotelFeatureCategory.FindById(id, trackChanges: false);

            _repository.HotelFeatureCategory.Delete(account);
        }

        #endregion
        
        #region HotelSelectedFeatures Services

        public IQueryable<HotelSelectedFeaturesModel> GetHotelSelectedFeatures(
            HotelSelectedFeaturesParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.HotelSelectedFeatures
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new HotelSelectedFeaturesModel
                              {
                                  Id = a.Id,
                                  Fk_Hotel = a.Fk_Hotel,
                                  Fk_HotelFeature = a.Fk_HotelFeature,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<HotelSelectedFeaturesModel>> GetHotelSelectedFeaturesPaged(
            HotelSelectedFeaturesParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<HotelSelectedFeaturesModel>.ToPagedList(GetHotelSelectedFeatures(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<HotelSelectedFeaturesModel>> GetHotelSelectedFeaturesPaged(
          IQueryable<HotelSelectedFeaturesModel> data,
         HotelSelectedFeaturesParameters parameters)
        {
            return await PagedList<HotelSelectedFeaturesModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<HotelSelectedFeatures> FindHotelSelectedFeaturesById(int id, bool trackChanges)
        {
            return await _repository.HotelSelectedFeatures.FindById(id, trackChanges);
        }

        public HotelSelectedFeaturesModel GetHotelSelectedFeaturesById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetHotelSelectedFeatures(new HotelSelectedFeaturesParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreateHotelSelectedFeatures(HotelSelectedFeatures entity)
        {
            _repository.HotelSelectedFeatures.Create(entity);
        }

        public int GetHotelSelectedFeaturesCount()
        {
            return _repository.HotelSelectedFeatures.Count();
        }

        public async Task DeleteHotelSelectedFeatures(int id)
        {
            HotelSelectedFeatures account = await _repository.HotelSelectedFeatures.FindById(id, trackChanges: false);

            _repository.HotelSelectedFeatures.Delete(account);
        }

        #endregion
    }
}
