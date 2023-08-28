using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.TripModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.TripModels;
using Entities.EnumData;

namespace CoreServices.Logic
{
    public class TripServices
    {
        private readonly RepositoryManager _repository;

        public TripServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region TripState Services

        public IQueryable<TripStateModel> GetTripStates(
            TripStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.TripState
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new TripStateModel
                              {
                                  Id = a.Id,
                                  Name = language != null ? a.TripStateLangs
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

        public async Task<PagedList<TripStateModel>> GetTripStatesPaged(
            TripStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<TripStateModel>.ToPagedList(GetTripStates(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<TripStateModel>> GetTripStatesPaged(
          IQueryable<TripStateModel> data,
         TripStateParameters parameters)
        {
            return await PagedList<TripStateModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<TripState> FindTripStateById(int id, bool trackChanges)
        {
            return await _repository.TripState.FindById(id, trackChanges);
        }

        public TripStateModel GetTripStateById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetTripStates(new TripStateParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateTripState(TripState entity)
        {
            _repository.TripState.Create(entity);
        }

        public int GetTripStatesCount()
        {
            return _repository.TripState.Count();
        }

        public async Task DeleteTripState(int id)
        {
            TripState account = await _repository.TripState.FindById(id, trackChanges: false);

            _repository.TripState.Delete(account);
        }

        #endregion

        #region Trip Services

        public IQueryable<TripModel> GetTrips(
            TripParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Trip
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new TripModel
                              {
                                  Id = a.Id,
                                  Fk_TripState = a.Fk_TripState,
                                  Fk_Client = a.Fk_Client,
                                  Fk_Driver = a.Fk_Driver,
                                  Fk_Supplier = a.Fk_Supplier,
                                  Fk_CarClass = a.Fk_CarClass,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                                  Price = a.Price,
                                  MembersCount = a.MembersCount,
                                  Notes = a.Notes,
                                  TripState = new TripStateModel
                                  {
                                      Id = a.Fk_TripState,
                                      Name = language != null ? a.TripState.TripStateLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.TripState.Name,
                                  },
                                  TripAt = a.TripAt,
                                  WaitingPrice = a.WaitingPrice,
                                  CarClass = a.Fk_CarClass != null ? new CarClassModel
                                  {
                                      Name = language != null ? a.CarClass.CarClassLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.CarClass.Name,
                                      Fk_CarCategory = a.CarClass.Fk_CarCategory,
                                      CarCategory = new CarCategoryModel
                                      {
                                          Name = language != null ? a.CarClass.CarCategory.CarCategoryLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.CarClass.CarCategory.Name,

                                      }
                                  } : null,
                                  Driver = a.Fk_Driver != null ?
                                  new AccountModel
                                  {
                                      Fk_User = a.Driver.Fk_User,
                                      User = a.Driver.Fk_User != null ? new UserModel
                                      {
                                          Name = a.Driver.User.Name

                                      } : null
                                  } : null,
                                  Supplier = a.Fk_Supplier != null ?
                                  new SupplierModel
                                  {
                                      Name = language != null ? a.Supplier.SupplierLangs
                                      .Where(b => b.Language == language)
                                      .Select(b => b.Name).FirstOrDefault() : a.Supplier.Name,
                                  } : null,
                                  Client = new AccountModel
                                  {
                                      Fk_User = a.Client.Fk_User,
                                      User = a.Client.Fk_User != null ? new UserModel
                                      {
                                          Name = a.Client.User.Name

                                      } : null
                                  }
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<TripModel>> GetTripsPaged(
            TripParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<TripModel>.ToPagedList(GetTrips(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public Dictionary<string, string> GetTripStatesLookUp(TripStateParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return GetTripStates(parameters, language).ToDictionary(a => a.Id.ToString(), a => a.Name);
        }
        
        public async Task<PagedList<TripModel>> GetTripsPaged(
          IQueryable<TripModel> data,
         TripParameters parameters)
        {
            return await PagedList<TripModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Trip> FindTripById(int id, bool trackChanges)
        {
            return await _repository.Trip.FindById(id, trackChanges);
        }

        public TripModel GetTripById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetTrips(new TripParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateTrip(Trip entity)
        {
            entity.TripHistories = new List<TripHistory> { new TripHistory()
            {
                Fk_Driver = entity.Fk_Driver,
                Fk_Supplier = entity.Fk_Supplier,
                Fk_TripState = entity.Fk_TripState,
                CreatedBy = entity.CreatedBy
            }};
            _repository.Trip.Create(entity);
        }

        public int GetTripsCount()
        {
            return _repository.Trip.Count();
        }


        public void UpdateTripHistory(Trip trip, string notes)
        {
            TripHistory tripHistory = _repository.TripHistory.FindAll(new TripHistoryParameters
            {
                Fk_Trip = trip.Id
            }, trackChanges: false).OrderByDescending(a => a.Id).FirstOrDefault();


            if (tripHistory.Fk_Driver != trip.Fk_Driver ||
                tripHistory.Fk_TripState != trip.Fk_TripState ||
                tripHistory.Fk_Supplier != trip.Fk_Supplier)
            {
                _repository.TripHistory.Create(new TripHistory
                {
                    Fk_Driver = trip.Fk_Driver,
                    Fk_Supplier = trip.Fk_Supplier,
                    Fk_TripState = trip.Fk_TripState,
                    Notes = notes,
                    Fk_Trip = trip.Id
                });
            }
        }
        public async Task DeleteTrip(int id)
        {
            Trip account = await _repository.Trip.FindById(id, trackChanges: false);

            _repository.Trip.Delete(account);
        }

        #endregion

        #region TripPoint Services

        public IQueryable<TripPointModel> GetTripPoints(
            TripPointParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.TripPoint
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new TripPointModel
                              {
                                  Id = a.Id,
                                  Fk_Trip = a.Fk_Trip,
                                  FromLatitude = a.FromLatitude,
                                  FromLongitude = a.FromLongitude,
                                  ToLatitude = a.ToLatitude,
                                  ToLongitude = a.ToLongitude,
                                  Price = a.Price,
                                  TripAt = a.TripAt,
                                  LeaveAt = a.LeaveAt,
                                  WaitingTime = a.WaitingTime,
                                  WaitingTimeCost = a.WaitingTimeCost,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<TripPointModel>> GetTripPointsPaged(
            TripPointParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<TripPointModel>.ToPagedList(GetTripPoints(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<TripPointModel>> GetTripPointsPaged(
          IQueryable<TripPointModel> data,
         TripPointParameters parameters)
        {
            return await PagedList<TripPointModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<TripPoint> FindTripPointById(int id, bool trackChanges)
        {
            return await _repository.TripPoint.FindById(id, trackChanges);
        }

        public TripPointModel GetTripPointById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetTripPoints(new TripPointParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateTripPoint(TripPoint entity)
        {
            _repository.TripPoint.Create(entity);
        }

        public int GetTripPointsCount()
        {
            return _repository.TripPoint.Count();
        }

        public async Task DeleteTripPoint(int id)
        {
            TripPoint account = await _repository.TripPoint.FindById(id, trackChanges: false);

            _repository.TripPoint.Delete(account);
        }

        #endregion

        #region TripHistory Services

        public IQueryable<TripHistoryModel> GetTripHistories(
            TripHistoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.TripHistory
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new TripHistoryModel
                              {
                                  Id = a.Id,
                                  Fk_Trip = a.Fk_Trip,
                                  Fk_Driver = a.Fk_Driver,
                                  Fk_Supplier = a.Fk_Supplier,
                                  Fk_TripState = a.Fk_TripState,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<TripHistoryModel>> GetTripHistoriesPaged(
            TripHistoryParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<TripHistoryModel>.ToPagedList(GetTripHistories(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<TripHistoryModel>> GetTripHistoriesPaged(
          IQueryable<TripHistoryModel> data,
         TripHistoryParameters parameters)
        {
            return await PagedList<TripHistoryModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<TripHistory> FindTripHistoryById(int id, bool trackChanges)
        {
            return await _repository.TripHistory.FindById(id, trackChanges);
        }

        public TripHistoryModel GetTripHistoryById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetTripHistories(new TripHistoryParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateTripHistory(TripHistory entity)
        {
            _repository.TripHistory.Create(entity);
        }

        public int GetTripHistoriesCount()
        {
            return _repository.TripHistory.Count();
        }

        public async Task DeleteTripHistory(int id)
        {
            TripHistory account = await _repository.TripHistory.FindById(id, trackChanges: false);

            _repository.TripHistory.Delete(account);
        }

        #endregion

        #region TripLocation Services

        public IQueryable<TripLocationModel> GetTripLocations(
            TripLocationParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.TripLocation
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new TripLocationModel
                              {
                                  Id = a.Id,
                                  Fk_Trip = a.Fk_Trip,
                                  Latitude = a.Latitude,
                                  Longitude = a.Longitude,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public object GetLatestTripLocations(TripLocationParameters parameters)
        {
            return _repository.Trip.FindAll(new TripParameters(), trackChanges: false)
                
                .Select(a => new LatestTripLocationModel
                {
                    TripLocation = a.TripLocations
                        .OrderByDescending(b => b.CreatedAt).Select(b => new TripLocationModel
                        {
                            Trip = new TripModel
                            {
                                Fk_TripState = b.Trip.Fk_TripState,
                            },
                            Latitude = b.Latitude,
                            Longitude = b.Longitude,
                            CreatedAt = b.CreatedAt
                        }).FirstOrDefault()
                }).ToList();
        }
        
        public async Task<PagedList<TripLocationModel>> GetTripLocationsPaged(
            TripLocationParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<TripLocationModel>.ToPagedList(GetTripLocations(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<TripLocationModel>> GetTripLocationsPaged(
          IQueryable<TripLocationModel> data,
         TripLocationParameters parameters)
        {
            return await PagedList<TripLocationModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<TripLocation> FindTripLocationById(int id, bool trackChanges)
        {
            return await _repository.TripLocation.FindById(id, trackChanges);
        }

        public TripLocationModel GetTripLocationById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetTripLocations(new TripLocationParameters { Id = id }, language).SingleOrDefault();
        }


        public void CreateTripLocation(TripLocation entity)
        {
            _repository.TripLocation.Create(entity);
        }

        public int GetTripLocationsCount()
        {
            return _repository.TripLocation.Count();
        }

        public async Task DeleteTripLocation(int id)
        {
            TripLocation tripLocation = await _repository.TripLocation.FindById(id, trackChanges: false);

            _repository.TripLocation.Delete(tripLocation);
        }

        #endregion

    }
}
