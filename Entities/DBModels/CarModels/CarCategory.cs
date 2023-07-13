namespace Entities.DBModels.CarModels;

public class CarCategory : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(CarClasses))]
    public List<CarClass> CarClasses { get; set; }
}