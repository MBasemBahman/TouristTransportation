using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.PostModels
{
    public class PostParameters : RequestParameters
    {
        public int Fk_Account { get; set; }
        public int Fk_AccountForReaction { get; set; }
        public bool? IncludeAttachments { get; set; }
    }

    public class PostModel : AuditEntity
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }
    
        [DisplayName(nameof(Account))]
        public AccountModel Account { get; set; }
    
        [DisplayName(nameof(Content))]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }

        [DisplayName(nameof(AttachmentsCount))]
        public int AttachmentsCount { get; set; }
        
        [DisplayName(nameof(ReactionCount))]
        public int ReactionCount { get; set; }
        
        [DisplayName(nameof(IReact))]
        public bool IReact { get; set; }
        
        [DisplayName(nameof(PostAttachments))] 
        public List<PostAttachmentModel> PostAttachments { get; set; }
    }

    public class PostCreateOrEditModel
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(Content))]
        [DataType(DataType.MultilineText)]
        public string Content { get; set; }
    }
}
