using Entities.CoreServicesModels.PostModels;

namespace API.Areas.PostArea.Models
{
    public class PostAttachmentDto : PostAttachmentModel
    {
        public new string CreatedAt { get; set; }
    }
}