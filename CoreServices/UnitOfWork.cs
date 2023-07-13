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
        
    }
}