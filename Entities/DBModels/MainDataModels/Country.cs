namespace Entities.DBModels.MainDataModels;

public class Country : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    // public List<CountryLang> CountryLangs { get; set; }
}

// public class CountryLang : AuditLangEntity<Country>
// {
//     [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
//     public string Name { get; set; }
//
//     [DisplayName($"{nameof(Language)}")]
//     public string Language { get; set; }
// }