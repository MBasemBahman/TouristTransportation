using BaseDB;
using Entities.AuthenticationModels;
using Microsoft.EntityFrameworkCore;
using ModelBuilderConfig.Configurations.DashboardAdministrationModels;
using TenantConfiguration;
using static TenantConfiguration.TenantData;

namespace DevelopmentDAL
{
    public class DevelopmentContext : BaseContext
    {
        public DevelopmentContext(DbContextOptions options, UserAuthenticatedDto user) : base(options, user)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            TenantConfig config = new(TenantEnvironments.Development);

            #region DashboardAdministrationModels

            _ = modelBuilder.ApplyConfiguration(new DashboardViewConfiguration(config.DashboardViews));
            _ = modelBuilder.ApplyConfiguration(new DashboardViewLangConfiguration(config.DashboardViews));

            #endregion
        }
    }
}
