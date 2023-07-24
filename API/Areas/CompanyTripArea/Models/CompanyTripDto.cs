using Entities.CoreServicesModels.CompanyTripModels;

namespace API.Areas.CompanyTripArea.Models
{
    public class CompanyTripDto : CompanyTripModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        public IEnumerable<CompanyTripAttachmentDto> Attachments { get; set; }
    }

    public class CompanyTripCreateOrEditDto : CompanyTripCreateOrEditModel
    {
        public int? Fk_Account { get; set; }

        public List<IFormFile> AttachmentFiles { get; set; }
        public List<int> RmvAttachments { get; set; }
    }

}