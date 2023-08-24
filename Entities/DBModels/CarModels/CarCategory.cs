using Entities.EnumData;

namespace Entities.DBModels.CarModels;

public class CarCategory : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(CarClasses))]
    public List<CarClass> CarClasses { get; set; }

    public List<CarCategoryLang> CarCategoryLangs { get; set; }
}

public class CarCategoryLang : AuditLangEntity<CarCategory>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}