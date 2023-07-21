using Entities.EnumData;

namespace Entities.DBModels.DashboardAdministrationModels
{
    [Index(nameof(ViewPath), IsUnique = true)]
    public class DashboardView : LookUpEntity
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(ViewPath))]
        public string ViewPath { get; set; }

        [DisplayName(nameof(Premissions))]
        public IList<AdministrationRolePremission> Premissions { get; set; }

        public List<DashboardViewLang> DashboardViewLangs { get; set; }
    }

 
    public class DashboardViewLang : AuditLangEntity<DashboardView>
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
