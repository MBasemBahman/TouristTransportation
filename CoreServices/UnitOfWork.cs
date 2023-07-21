using CoreServices.Logic;
using Microsoft.Extensions.Configuration;

namespace CoreServices
{
    public class UnitOfWork
    {
        private readonly RepositoryManager _repository;
        private readonly IConfiguration _config;
        private UserService _userService;
        private LogServices _logServices;
        private DashboardAdministrationServices _dashboardAdministrationServices;
        private AuditServices _auditServices;
        private AccountServices _accountServices;
        private MainDataServices _mainDataServices;
        private CompanyTripServices _companyTripServices;
        private CarServices _carServices;
        private HotelServices _hotelServices;
        private PostServices _postServices;
        private TripServices _tripServices;

        public UnitOfWork(RepositoryManager repository, IConfiguration config)
        {
            _repository = repository;
            _config = config;
        }

        public async Task Save()
        {
            await _repository.Save();
        }

        public LogServices Log
        {
            get
            {
                _logServices ??= new LogServices(_repository);
                return _logServices;
            }
        }
        public UserService User
        {
            get
            {
                _userService ??= new UserService(_repository);
                return _userService;
            }
        }

        public DashboardAdministrationServices DashboardAdministration
        {
            get
            {
                _dashboardAdministrationServices ??= new DashboardAdministrationServices(_repository);
                return _dashboardAdministrationServices;
            }
        }

        public AuditServices Audit
        {
            get
            {
                _auditServices ??= new AuditServices(_repository);
                return _auditServices;
            }
        }

        public AccountServices Account
        {
            get
            {
                _accountServices ??= new AccountServices(_repository, _config);
                return _accountServices;
            }
        }
        
        public MainDataServices MainData
        {
            get
            {
                _mainDataServices ??= new MainDataServices(_repository);
                return _mainDataServices;
            }
        }
        
        public CompanyTripServices CompanyTrip
        {
            get
            {
                _companyTripServices ??= new CompanyTripServices(_repository);
                return _companyTripServices;
            }
        }
        
        public CarServices Car
        {
            get
            {
                _carServices ??= new CarServices(_repository);
                return _carServices;
            }
        }
        
        public HotelServices Hotel
        {
            get
            {
                _hotelServices ??= new HotelServices(_repository);
                return _hotelServices;
            }
        }
        
        public PostServices Post
        {
            get
            {
                _postServices ??= new PostServices(_repository);
                return _postServices;
            }
        }
        
        public TripServices Trip
        {
            get
            {
                _tripServices ??= new TripServices(_repository);
                return _tripServices;
            }
        }
        
    }
}