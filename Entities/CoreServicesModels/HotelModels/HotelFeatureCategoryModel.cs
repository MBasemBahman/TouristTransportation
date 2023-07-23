using Entities.DBModels.HotelModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelFeatureCategoryParameters : RequestParameters
    {
        public bool? IncludeHotelFeatures { get; set; }
    }

    public class HotelFeatureCategoryModel : AuditLookUpEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }

        public List<HotelFeatureModel> HotelFeatures { get; set; }
    }

    public class HotelFeatureCategoryCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public  string Name { get; set; }

        public List<HotelFeatureCategoryLangModel> HotelFeatureCategoryLangs { get; set; }
    }
    
    public class HotelFeatureCategoryLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
