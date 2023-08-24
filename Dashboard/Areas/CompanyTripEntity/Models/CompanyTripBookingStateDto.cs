using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;

namespace Dashboard.Areas.CompanyTripEntity.Models;

public class CompanyTripBookingStateFilter : DtParameters
{
    public int Id { get; set; }
}

public class CompanyTripBookingStateDto : CompanyTripBookingStateModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }

    [DisplayName(nameof(LastModifiedAt))]
    public new string LastModifiedAt { get; set; }
}