using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.HotelModels;

namespace Dashboard.Areas.CompanyTripEntity.Models;

public class CompanyTripFilter : DtParameters
{
    public int Id { get; set; }
}

public class CompanyTripDto : CompanyTripModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }

    [DisplayName(nameof(LastModifiedAt))]
    public new string LastModifiedAt { get; set; }
}