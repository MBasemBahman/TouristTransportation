using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Models
{
    public class HotelAttachmentDto : HotelAttachmentModel
    {
        public new string CreatedAt { get; set; }
    }
}