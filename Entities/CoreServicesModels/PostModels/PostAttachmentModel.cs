using Entities.DBModels.PostModels;

namespace Entities.CoreServicesModels.PostModels
{
    public class PostAttachmentParameters : RequestParameters
    {
        public int Fk_Post { get; set; }
    }

    public class PostAttachmentModel : AuditAttachmentEntity
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName(nameof(Post))]
        public PostModel Post { get; set; }
    }

    public class PostAttachmentCreateOrEditModel
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName(nameof(AttachmentUrl))]
        public string AttachmentUrl { get; set; }
    }
}
