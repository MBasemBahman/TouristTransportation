using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.TripModels;

namespace API.Areas.TripArea.Models
{
    public class TripDto : TripModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }

    public class TripCreateOrEditDto : TripCreateOrEditModel
    {
        public int? Fk_Account { get; set; }

        public List<IFormFile> AttachmentFiles { get; set; }
        public List<int> RmvAttachments { get; set; }
    }

}