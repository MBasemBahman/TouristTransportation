using Entities.EnumData;

namespace Entities.CoreServicesModels.MainDataModels
{
    public class CurrencyParameters : RequestParameters
    {

    }

    public class CurrencyModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(RateInPounds))]
        public double RateInPounds { get; set; }
    }

    public class CurrencyCreateOrEditModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        [DisplayName(nameof(RateInPounds))]
        public double RateInPounds { get; set; }

        public List<CurrencyLangModel> CurrencyLangs { get; set; }
    }

    public class CurrencyLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
