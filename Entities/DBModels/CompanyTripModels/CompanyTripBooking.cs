using Entities.DBModels.AccountModels;
using Entities.DBModels.MainDataModels;

namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripBooking : AuditEntity
{
    [DisplayName(nameof(Account))]
    [ForeignKey(nameof(Account))]
    public int Fk_Account { get; set; }
    
    [DisplayName(nameof(Account))]
    public Account Account { get; set; }
    
    [DisplayName(nameof(CompanyTrip))]
    [ForeignKey(nameof(CompanyTrip))]
    public int Fk_CompanyTrip { get; set; }
    
    [DisplayName(nameof(CompanyTrip))]
    public CompanyTrip CompanyTrip { get; set; }
    
    [DisplayName(nameof(Currency))]
    [ForeignKey(nameof(Currency))]
    public int Fk_Currency { get; set; }
    
    [DisplayName(nameof(Currency))]
    public Currency Currency { get; set; }
    
    [DisplayName(nameof(CompanyTripBookingState))]
    [ForeignKey(nameof(CompanyTripBookingState))]
    public int Fk_CompanyTripBookingState { get; set; }
    
    [DisplayName(nameof(CompanyTripBookingState))]
    public CompanyTripBookingState CompanyTripBookingState { get; set; }
    
    [DisplayName(nameof(Notes))]
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }

    [DisplayName(nameof(Price))]
    public double Price { get; set; }
    
    [DisplayName(nameof(CurrencyRate))]
    public double CurrencyRate { get; set; }
    
    [DisplayName(nameof(MembersCount))]
    public int MembersCount { get; set; }
    
    [DisplayName(nameof(Date))]
    public DateTime Date { get; set; }

    [DisplayName(nameof(CompanyTripBookingHistories))]
    public List<CompanyTripBookingHistory> CompanyTripBookingHistories { get; set; }
}