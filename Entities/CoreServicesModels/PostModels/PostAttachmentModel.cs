using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.MainDataModels;
using Entities.DBModels.PostModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.PostModels
{
    public class PostAttachmentParameters : RequestParameters
    {
        public int Fk_Post { get; set; }
    }

    public class PostAttachmentModel : AuditEntity
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }
    
        [DisplayName(nameof(Post))]
        public PostModel Post { get; set; }
    
        [DisplayName(nameof(AttachmentUrl))]
        public string AttachmentUrl { get; set; }
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
