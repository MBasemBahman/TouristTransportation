using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.HotelModels;

namespace Dashboard.Areas.HotelEntity.Models;

public class HotelFilter : DtParameters
{
    public int Id { get; set; }
}

public class HotelDto : HotelModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }

    [DisplayName(nameof(LastModifiedAt))]
    public new string LastModifiedAt { get; set; }
}