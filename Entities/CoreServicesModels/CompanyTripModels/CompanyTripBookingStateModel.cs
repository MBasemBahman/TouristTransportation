using Entities.EnumData;

namespace Entities.CoreServicesModels.CompanyTripModels
{
    public class CompanyTripBookingStateParameters : RequestParameters
    {

    }

    public class CompanyTripBookingStateModel : AuditLookUpEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }
    }

    public class CompanyTripBookingStateCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        public List<CompanyTripBookingStateLangModel> CompanyTripBookingStateLangs { get; set; }
    }

    public class CompanyTripBookingStateLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
