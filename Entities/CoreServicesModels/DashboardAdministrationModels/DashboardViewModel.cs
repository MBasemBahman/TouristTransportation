using Entities.EnumData;

namespace Entities.CoreServicesModels.DashboardAdministrationModels
{
    public class DashboardViewParameters : RequestParameters
    {
        public int Fk_Role { get; set; }
    }

    public class DashboardViewModel : LookUpEntity
    {
        [DisplayName(nameof(ViewPath))]
        public string ViewPath { get; set; }

        [DisplayName(nameof(PremissionsCount))]
        public int PremissionsCount { get; set; }

    }

    public class DashboardViewCreateOrEditModel
    {
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(ViewPath))]
        public string ViewPath { get; set; }

        public List<DashboardViewLangModel> DashboardViewLangs { get; set; }
    }

    public class DashboardViewLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
