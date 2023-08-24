using Entities.EnumData;

namespace Entities.DBModels.TripModels;

public class TripState : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    public List<TripStateLang> TripStateLangs { get; set; }
}

public class TripStateLang : AuditLangEntity<TripState>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}