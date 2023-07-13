namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripBookingState : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(CompanyTripBookings))]
    public List<CompanyTripBooking> CompanyTripBookings { get; set; }
}