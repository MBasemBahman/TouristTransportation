using Entities.CoreServicesModels.HotelModels;

namespace API.Areas.HotelArea.Models
{
    public class HotelDto : HotelModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        public IEnumerable<HotelAttachmentDto> Attachments { get; set; }

        public new HotelDto OldHotel { get; set; }
    }

    public class HotelCreateOrEditDto : HotelCreateOrEditModel
    {
        public new int? Fk_Account { get; set; }
        
        public List<IFormFile> AttachmentFiles { get; set; }
        public List<int> RmvAttachments { get; set; }
    }
    
}