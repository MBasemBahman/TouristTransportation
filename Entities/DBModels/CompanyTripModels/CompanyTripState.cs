using Entities.EnumData;

namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripState : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(CompanyTrips))]
    public List<CompanyTrip> CompanyTrips { get; set; }
    
    public List<CompanyTripStateLang> CompanyTripStateLangs { get; set; }
}

public class CompanyTripStateLang : AuditLangEntity<CompanyTripState>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}