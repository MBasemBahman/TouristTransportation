using Entities.DBModels.AccountModels;
using Entities.EnumData;

namespace Entities.DBModels.DashboardAdministrationModels
{
    public class DashboardAdministrationRole : LookUpEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(Premissions))]
        public IList<AdministrationRolePremission> Premissions { get; set; }

        [DisplayName(nameof(Administrators))]
        public IList<DashboardAdministrator> Administrators { get; set; }

        public List<DashboardAdministrationRoleLang> DashboardAdministrationRoleLangs { get; set; }

    }



    public class DashboardAdministrationRoleLang : AuditLangEntity<DashboardAdministrationRole>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
