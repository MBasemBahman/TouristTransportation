using System.ComponentModel;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.DBModels.CompanyTripModels;

namespace Dashboard.Areas.CompanyTripEntity.Models
{
    public class CompanyTripAttachmentDto : CompanyTripAttachmentModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }
}
