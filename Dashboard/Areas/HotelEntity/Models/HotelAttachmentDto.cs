using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace Dashboard.Areas.HotelEntity.Models
{
    public class HotelAttachmentDto : HotelAttachmentModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}
