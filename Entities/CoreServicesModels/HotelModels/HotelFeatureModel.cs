using Entities.DBModels.HotelModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelFeatureParameters : RequestParameters
    {
        public int Fk_HotelFeatureCategory { get; set; }
    }

    public class HotelFeatureModel : AuditLookUpEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }
        
        [DisplayName(nameof(HotelFeatureCategory))]
        [ForeignKey(nameof(HotelFeatureCategory))]
        public int Fk_HotelFeatureCategory { get; set; }
    
        [DisplayName(nameof(HotelFeatureCategory))]
        public HotelFeatureCategoryModel HotelFeatureCategory { get; set; }
    }

    public class HotelFeatureCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }
        
        [DisplayName(nameof(HotelFeatureCategory))]
        [ForeignKey(nameof(HotelFeatureCategory))]
        public int Fk_HotelFeatureCategory { get; set; }

        public List<HotelFeatureLangModel> HotelFeatureLangs { get; set; }
    }
    
    public class HotelFeatureLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
