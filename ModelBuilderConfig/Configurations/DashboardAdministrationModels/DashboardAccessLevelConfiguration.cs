using Entities.DBModels.DashboardAdministrationModels;

namespace ModelBuilderConfig.Configurations.DashboardAdministrationModels
{
    public class DashboardAccessLevelConfiguration : IEntityTypeConfiguration<DashboardAccessLevel>
    {
        public void Configure(EntityTypeBuilder<DashboardAccessLevel> builder)
        {
            _ = builder.HasData(new DashboardAccessLevel
            {
                Id = (int)DashboardAccessLevelEnum.FullAccess,
                Name = DashboardAccessLevelEnum.FullAccess.ToString(),
                ViewAccess = true,
                CreateAccess = true,
                EditAccess = true,
                DeleteAccess = true,
                ExportAccess = true
            });

            _ = builder.HasData(new DashboardAccessLevel
            {
                Id = (int)DashboardAccessLevelEnum.DataControl,
                Name = DashboardAccessLevelEnum.DataControl.ToString(),
                ViewAccess = true,
                CreateAccess = true,
                EditAccess = true,
                DeleteAccess = false,
                ExportAccess = true
            });

            _ = builder.HasData(new DashboardAccessLevel
            {
                Id = (int)DashboardAccessLevelEnum.Viewer,
                Name = DashboardAccessLevelEnum.Viewer.ToString(),
                ViewAccess = true,
                CreateAccess = false,
                EditAccess = false,
                DeleteAccess = false,
                ExportAccess = false
            });
        }
    }

}
