using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.CompanyTripModels;

namespace Dashboard.Areas.CompanyTripEntity.Models;

public class CompanyTripFilter : DtParameters
{
    public int Id { get; set; }
    
    [DisplayName(nameof(CompanyTripState))]
    public int Fk_CompanyTripState { get; set; }
}

public class CompanyTripDto : CompanyTripModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }

    [DisplayName(nameof(LastModifiedAt))]
    public new string LastModifiedAt { get; set; }
}