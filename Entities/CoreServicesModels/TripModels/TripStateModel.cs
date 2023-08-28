using Entities.EnumData;

namespace Entities.CoreServicesModels.TripModels
{
    public class TripStateParameters : RequestParameters
    {

    }

    public class TripStateModel : AuditLookUpEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }
    }

    public class TripStateCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }
        [DisplayName(nameof(ColorCode))]
        public string ColorCode { get; set; }

        public List<TripStateLangModel> TripStateLangs { get; set; }
    }

    public class TripStateLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
