using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.TripModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.CarModels
{
    public class CarClassParameters : RequestParameters
    {
        public int Fk_CarCategory { get; set; }
    }

    public class CarClassModel : AuditEntity
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(CarCategory))]
        [ForeignKey(nameof(CarCategory))]
        public int Fk_CarCategory { get; set; }
    
        [DisplayName(nameof(CarCategory))]
        public CarCategoryModel CarCategory { get; set; }
    }

    public class CarClassCreateOrEditModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
        public string Name { get; set; }

        [DisplayName(nameof(CarCategory))]
        [ForeignKey(nameof(CarCategory))]
        public int Fk_CarCategory { get; set; }


        public List<CarClassLangModel> CarClassLangs { get; set; }
    }
    
    public class CarClassLangModel
    {
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.EnLang}")]
        public string Name { get; set; }
        
        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
