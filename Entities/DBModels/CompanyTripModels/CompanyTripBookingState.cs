using Entities.EnumData;

namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripBookingState : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(CompanyTripBookings))]
    public List<CompanyTripBooking> CompanyTripBookings { get; set; }
    
    public List<CompanyTripBookingStateLang> CompanyTripBookingStateLangs { get; set; }
}

public class CompanyTripBookingStateLang : AuditLangEntity<CompanyTripBookingState>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}