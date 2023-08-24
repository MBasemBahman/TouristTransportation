namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripBookingHistory : AuditEntity
{
    [DisplayName(nameof(CompanyTripBooking))]
    [ForeignKey(nameof(CompanyTripBooking))]
    public int Fk_CompanyTripBooking { get; set; }

    [DisplayName(nameof(CompanyTripBooking))]
    public CompanyTripBooking CompanyTripBooking { get; set; }

    [DisplayName(nameof(CompanyTripBookingState))]
    [ForeignKey(nameof(CompanyTripBookingState))]
    public int Fk_CompanyTripBookingState { get; set; }

    [DisplayName(nameof(CompanyTripBookingState))]
    public CompanyTripBookingState CompanyTripBookingState { get; set; }

    [DisplayName(nameof(Notes))]
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }
}