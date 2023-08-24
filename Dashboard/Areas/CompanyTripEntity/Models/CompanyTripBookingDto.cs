using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;

namespace Dashboard.Areas.CompanyTripEntity.Models;

public class CompanyTripBookingFilter : DtParameters
{
    public int Id { get; set; }
    
    public int Fk_Account { get; set; }
    public int Fk_CompanyTrip { get; set; }
    public int Fk_Currency { get; set; }
    public int Fk_CompanyTripBookingState { get; set; }
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