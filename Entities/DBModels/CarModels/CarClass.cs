using Entities.EnumData;

namespace Entities.DBModels.CarModels;

public class CarClass : AuditEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public string Name { get; set; }

    [DisplayName(nameof(CarCategory))]
    [ForeignKey(nameof(CarCategory))]
    public int Fk_CarCategory { get; set; }

    [DisplayName(nameof(CarCategory))]
    public CarCategory CarCategory { get; set; }

    public List<CarClassLang> CarClassLangs { get; set; }
}

public class CarClassLang : AuditLangEntity<CarClass>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}