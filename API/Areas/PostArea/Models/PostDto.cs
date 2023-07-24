using Entities.CoreServicesModels.PostModels;

namespace API.Areas.PostArea.Models
{
    public class PostDto : PostModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        public IEnumerable<PostAttachmentDto> Attachments { get; set; }
    }

    public class PostCreateOrEditDto : PostCreateOrEditModel
    {
        public List<IFormFile> AttachmentFiles { get; set; }

        public List<int> RmvAttachments { get; set; }
    }

}