using Entities.EnumData;

namespace Entities.DBModels.MainDataModels;

public class Currency : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(RateInPounds))]
    public double RateInPounds { get; set; }

    public List<CurrencyLang> CurrencyLangs { get; set; }
}

public class CurrencyLang : AuditLangEntity<Currency>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}