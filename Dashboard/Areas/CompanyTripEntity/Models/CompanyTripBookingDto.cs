using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.MainDataModels;

namespace Dashboard.Areas.CompanyTripEntity.Models;

public class CompanyTripBookingFilter : DtParameters
{
    public int Id { get; set; }
    
    public int Fk_Account { get; set; }
    public int Fk_CompanyTrip { get; set; }
    [DisplayName(nameof(Currency))]
    public int Fk_Currency { get; set; }
    [DisplayName(nameof(CompanyTripBookingState))]
    public int Fk_CompanyTripBookingState { get; set; }
    
    [DisplayName("Date")]
    public DateTime? DateFrom { get; set; }

    public DateTime? DateTo { get; set; }
}

public class CompanyTripBookingDto : CompanyTripBookingModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }
    
    [DisplayName(nameof(Date))]
    public new string Date { get; set; }

    [DisplayName(nameof(LastModifiedAt))]
    public new string LastModifiedAt { get; set; }
}