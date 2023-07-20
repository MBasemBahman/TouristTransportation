using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.MainDataModels
{
    public class AreaParameters : RequestParameters
    {
        public int Fk_Country { get; set; }
    }

    public class AreaModel : AuditLookUpEntity
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public new string Name { get; set; }

        [DisplayName(nameof(Country))]
        public int Fk_Country { get; set; }

        [DisplayName(nameof(Country))]
        public CountryModel Country { get; set; }
    }

    public class AreaCreateOrEditModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        [DisplayName(nameof(Country))]
        public int Fk_Country { get; set; }

        public List<AreaLangModel> AreaLangs { get; set; }
    }
    
    public class AreaLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
