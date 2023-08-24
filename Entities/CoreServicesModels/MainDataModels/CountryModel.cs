using Entities.EnumData;

namespace Entities.CoreServicesModels.MainDataModels
{
    public class CountryParameters : RequestParameters
    {

    }

    public class CountryModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }
    }

    public class CountryCreateOrEditModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        public List<CountryLangModel> CountryLangs { get; set; }
    }

    public class CountryLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
