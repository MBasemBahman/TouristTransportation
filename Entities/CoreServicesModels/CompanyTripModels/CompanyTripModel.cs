using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.CompanyTripModels
{
    public class CompanyTripParameters : RequestParameters
    {
        public int Fk_CompanyTripState { get; set; }
    }

    public class CompanyTripModel : AuditImageEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Title)}{PropertyAttributeConstants.ArLang}")]
        public string Title { get; set; }

        [DisplayName(nameof(CompanyTripState))]
        [ForeignKey(nameof(CompanyTripState))]
        public int Fk_CompanyTripState { get; set; }
    
        [DisplayName(nameof(CompanyTripState))]
        public CompanyTripStateModel CompanyTripState { get; set; }
    
        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        
        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }

        [DisplayName(nameof(AttachmentsCount))]
        public int AttachmentsCount { get; set; }
    }

    public class CompanyTripCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Title)}{PropertyAttributeConstants.ArLang}")]
        public string Title { get; set; }

        [DisplayName(nameof(CompanyTripState))]
        [ForeignKey(nameof(CompanyTripState))]
        public int Fk_CompanyTripState { get; set; }

        [DisplayName(nameof(Description))]
        [DataType(DataType.MultilineText)]
        public string Description { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
        
        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }

        [DisplayName(nameof(StorageUrl))]
        [DataType(DataType.Url, ErrorMessage = PropertyAttributeConstants.TypeValidationMsg)]
        [Url]
        public string StorageUrl { get; set; }
        
        public List<CompanyTripLangModel> CompanyTripLangs { get; set; }
    }
    
    public class CompanyTripLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName(nameof(Title))]
        public string Title { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
