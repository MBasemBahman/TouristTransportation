using Entities.DBModels.TripModels;
using Entities.EnumData;

namespace Entities.DBModels.CarModels;

public class CarClass : AuditEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public string Name { get; set; }
    
    [DisplayName(nameof(TripState))]
    [ForeignKey(nameof(TripState))]
    public int Fk_TripState { get; set; }
    
    [DisplayName(nameof(TripState))]
    public TripState TripState { get; set; }

    public List<CarClassLang> CarClassLangs { get; set; }
}

public class CarClassLang : AuditLangEntity<CarClass>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}