using Entities.EnumData;

namespace Entities.CoreServicesModels.CompanyTripModels
{
    public class CompanyTripStateParameters : RequestParameters
    {

    }

    public class CompanyTripStateModel : AuditLookUpEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }
    }

    public class CompanyTripStateCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }


        public List<CompanyTripStateLangModel> CompanyTripStateLangs { get; set; }
    }

    public class CompanyTripStateLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
