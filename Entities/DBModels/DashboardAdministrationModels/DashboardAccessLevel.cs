using Entities.EnumData;

namespace Entities.DBModels.DashboardAdministrationModels
{
    public class DashboardAccessLevel : LookUpEntity
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(CreateAccess))]
        public bool CreateAccess { get; set; }

        [DisplayName(nameof(EditAccess))]
        public bool EditAccess { get; set; }

        [DisplayName(nameof(ViewAccess))]
        public bool ViewAccess { get; set; }

        [DisplayName(nameof(DeleteAccess))]
        public bool DeleteAccess { get; set; }

        [DisplayName(nameof(ExportAccess))]
        public bool ExportAccess { get; set; }

        [DisplayName(nameof(Premissions))]
        public IList<AdministrationRolePremission> Premissions { get; set; }
    }
}
