using Entities.DBModels.PostModels;
using Repository.DBModels.AccountModels;
using Repository.DBModels.AuditModels;
using Repository.DBModels.CompanyTripModels;
using Repository.DBModels.DashboardAdministrationModels;
using Repository.DBModels.HotelModels;
using Repository.DBModels.LogModels;
using Repository.DBModels.MainDataModels;
using Repository.DBModels.PostModels;

namespace Repository
{
    public class RepositoryManager
    {
        private readonly BaseContext _dBContext;

        #region private

        #region LogModels
        private LogRepository _logRepository;
        #endregion

        #region UserModels
        private UserRepository _userRepository;
        private DeviceRepository _deviceRepository;
        private VerificationRepository _verificationRepository;
        private RefreshTokenRepository _refreshTokenRepository;
        #endregion

        #region DashboardAdministrationModels

        private AdministrationRolePremissionRepository _administrationRolePremissionRepository;
        private DashboardAccessLevelRepository _dashboardAccessLevelRepository;
        private DashboardAdministrationRoleRepository _dashboardAdministrationRoleRepository;
        private DashboardAdministratorRepository _dashboardAdministratorRepository;
        private DashboardViewRepository _dashboardViewRepository;

        #endregion

        #region Audit Models
        private AuditRepository _auditRepository;
        #endregion

        #region Account
        
        private AccountRepository _accountRepository;
        
        #endregion
        
        #region MainData Models
        
        private CountryRepository _countryRepository;
        private CurrencyRepository _currencyRepository;
        private AreaRepository _areaRepository;
        
        #endregion
        
        #region Hotel Models
        
        private HotelRepository _hotelRepository;
        private HotelAttachmentRepository _hotelAttachmentRepository;
        private HotelFeatureRepository _hotelFeatureRepository;
        private HotelFeatureCategoryRepository _hotelFeatureCategoryRepository;
        private HotelSelectedFeaturesRepository _hotelSelectedFeaturesRepository;
        
        #endregion
        
        #region Post Models
        
        private PostRepository _postRepository;
        private PostAttachmentRepository _postAttachmentRepository;
        private PostReactionRepository _postReactionRepository;
        
        #endregion

        #region CompanyTrip Models

        private CompanyTripAttachmentRepository _companyTripAttachmentRepository;
        private CompanyTripBookingHistoryRepository _companyTripBookingHistoryRepository;
        private CompanyTripBookingRepository _companyTripBookingRepository;
        private CompanyTripBookingStateRepository _companyTripBookingStateRepository;
        private CompanyTripRepository _companyTripRepository;
        private CompanyTripStateRepository _companyTripStateRepository;

        #endregion
        
        #endregion

        public RepositoryManager(BaseContext dBContext)
        {
            _dBContext = dBContext;
        }

        public async Task Save()
        {
            _ = await _dBContext.SaveChangesAsync();
        }

        #region Public

        #region LogModels
        public LogRepository Log
        {
            get
            {
                _logRepository ??= new LogRepository(_dBContext);
                return _logRepository;
            }
        }
        #endregion

        #region UserModels

        public UserRepository User
        {
            get
            {
                _userRepository ??= new UserRepository(_dBContext);
                return _userRepository;
            }
        }

        public DeviceRepository Device
        {
            get
            {
                _deviceRepository ??= new DeviceRepository(_dBContext);
                return _deviceRepository;
            }
        }


        public VerificationRepository Verification
        {
            get
            {
                _verificationRepository ??= new VerificationRepository(_dBContext);
                return _verificationRepository;
            }
        }


        public RefreshTokenRepository RefreshToken
        {
            get
            {
                _refreshTokenRepository ??= new RefreshTokenRepository(_dBContext);
                return _refreshTokenRepository;
            }
        }

        #endregion

        #region DashboardAdministrationModels

        public AdministrationRolePremissionRepository AdministrationRolePremission
        {
            get
            {
                _administrationRolePremissionRepository ??= new AdministrationRolePremissionRepository(_dBContext);
                return _administrationRolePremissionRepository;
            }
        }

        public DashboardAccessLevelRepository DashboardAccessLevel
        {
            get
            {
                _dashboardAccessLevelRepository ??= new DashboardAccessLevelRepository(_dBContext);
                return _dashboardAccessLevelRepository;
            }
        }

        public DashboardAdministrationRoleRepository DashboardAdministrationRole
        {
            get
            {
                _dashboardAdministrationRoleRepository ??= new DashboardAdministrationRoleRepository(_dBContext);
                return _dashboardAdministrationRoleRepository;
            }
        }

        public DashboardAdministratorRepository DashboardAdministrator
        {
            get
            {
                _dashboardAdministratorRepository ??= new DashboardAdministratorRepository(_dBContext);
                return _dashboardAdministratorRepository;
            }
        }

        public DashboardViewRepository DashboardView
        {
            get
            {
                _dashboardViewRepository ??= new DashboardViewRepository(_dBContext);
                return _dashboardViewRepository;
            }
        }

        #endregion

        #region Audit Models
        public AuditRepository Audit
        {
            get
            {
                _auditRepository ??= new AuditRepository(_dBContext);
                return _auditRepository;
            }
        }
        #endregion

        #region Account
        public AccountRepository Account
        {
            get
            {
                _accountRepository ??= new AccountRepository(_dBContext);
                return _accountRepository;
            }
        }
        #endregion

        #region MainData Models
        
        public CountryRepository Country
        {
            get
            {
                _countryRepository ??= new CountryRepository(_dBContext);
                return _countryRepository;
            }
        }
        
        public CurrencyRepository Currency
        {
            get
            {
                _currencyRepository ??= new CurrencyRepository(_dBContext);
                return _currencyRepository;
            }
        }
        
        public AreaRepository Area
        {
            get
            {
                _areaRepository ??= new AreaRepository(_dBContext);
                return _areaRepository;
            }
        }
        
        #endregion

        #region Hotel Models

        public HotelRepository Hotel
        {
            get
            {
                _hotelRepository ??= new HotelRepository(_dBContext);
                return _hotelRepository;
            }
        }
        
        public HotelAttachmentRepository HotelAttachment
        {
            get
            {
                _hotelAttachmentRepository ??= new HotelAttachmentRepository(_dBContext);
                return _hotelAttachmentRepository;
            }
        }
        
        public HotelFeatureRepository HotelFeature
        {
            get
            {
                _hotelFeatureRepository ??= new HotelFeatureRepository(_dBContext);
                return _hotelFeatureRepository;
            }
        }
        
        public HotelFeatureCategoryRepository HotelFeatureCategory
        {
            get
            {
                _hotelFeatureCategoryRepository ??= new HotelFeatureCategoryRepository(_dBContext);
                return _hotelFeatureCategoryRepository;
            }
        }
        
        public HotelSelectedFeaturesRepository HotelSelectedFeatures
        {
            get
            {
                _hotelSelectedFeaturesRepository ??= new HotelSelectedFeaturesRepository(_dBContext);
                return _hotelSelectedFeaturesRepository;
            }
        }
        
        #endregion

        #region Post Models

        public PostRepository Post
        {
            get
            {
                _postRepository ??= new PostRepository(_dBContext);
                return _postRepository;
            }
        }
        
        public PostAttachmentRepository PostAttachment
        {
            get
            {
                _postAttachmentRepository ??= new PostAttachmentRepository(_dBContext);
                return _postAttachmentRepository;
            }
        }
        
        public PostReactionRepository PostReaction
        {
            get
            {
                _postReactionRepository ??= new PostReactionRepository(_dBContext);
                return _postReactionRepository;
            }
        }
        
        #endregion
        
        #region CompanyTrip Models

        public CompanyTripAttachmentRepository CompanyTripAttachment
        {
            get
            {
                _companyTripAttachmentRepository ??= new CompanyTripAttachmentRepository(_dBContext);
                return _companyTripAttachmentRepository;
            }
        }
        
        public CompanyTripBookingHistoryRepository CompanyTripBookingHistory
        {
            get
            {
                _companyTripBookingHistoryRepository ??= new CompanyTripBookingHistoryRepository(_dBContext);
                return _companyTripBookingHistoryRepository;
            }
        }
        
        public CompanyTripBookingRepository CompanyTripBooking
        {
            get
            {
                _companyTripBookingRepository ??= new CompanyTripBookingRepository(_dBContext);
                return _companyTripBookingRepository;
            }
        }
        
        public CompanyTripBookingStateRepository CompanyTripBookingState
        {
            get
            {
                _companyTripBookingStateRepository ??= new CompanyTripBookingStateRepository(_dBContext);
                return _companyTripBookingStateRepository;
            }
        }
        
        public CompanyTripRepository CompanyTrip
        {
            get
            {
                _companyTripRepository ??= new CompanyTripRepository(_dBContext);
                return _companyTripRepository;
            }
        }
        
        public CompanyTripStateRepository CompanyTripState
        {
            get
            {
                _companyTripStateRepository ??= new CompanyTripStateRepository(_dBContext);
                return _companyTripStateRepository;
            }
        }
        
        #endregion
        
        #endregion
    }
}
