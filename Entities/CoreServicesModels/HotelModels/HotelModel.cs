using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelParameters : RequestParameters
    {
        public int? Fk_Area { get; set; }
        public bool? IncludeSelectedFeature { get; set; }
    }

    public class HotelModel : AuditImageEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(BookingUrl))]
        public string BookingUrl { get; set; }
    
        [DisplayName(nameof(LocationUrl))]
        public string LocationUrl { get; set; }
    
        [DisplayName(nameof(Address))]
        public string Address { get; set; }
    
        [DisplayName(nameof(Area))]
        [ForeignKey(nameof(Area))]
        public int? Fk_Area { get; set; }
    
        [DisplayName(nameof(Area))]
        public AreaModel Area { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))] 
        public double Rate { get; set; }
        
        [DisplayName(nameof(AttachmentsCount))]
        public int AttachmentsCount { get; set; }
        
        [DisplayName(nameof(AttachmentsCount))]
        public List<HotelSelectedFeaturesWithCategoryModel> HotelSelectedFeatures { get; set; }
    }

    public class HotelCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public new string Name { get; set; }

        [DisplayName(nameof(BookingUrl))]
        public string BookingUrl { get; set; }
    
        [DisplayName(nameof(LocationUrl))]
        public string LocationUrl { get; set; }
    
        [DisplayName(nameof(Address))]
        public string Address { get; set; }
    
        [DisplayName(nameof(Area))]
        [ForeignKey(nameof(Area))]
        public int? Fk_Area { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Rate))] 
        public double Rate { get; set; }

        public List<HotelLangModel> HotelLangs { get; set; }
        public List<int> HotelFeatures { get; set; }
    }
    
    public class HotelLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Name))]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
