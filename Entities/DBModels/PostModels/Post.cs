using Entities.DBModels.AccountModels;

namespace Entities.DBModels.PostModels;

public class Post : AuditEntity
{
    [DisplayName(nameof(Account))]
    [ForeignKey(nameof(Account))]
    public int Fk_Account { get; set; }
    
    [DisplayName(nameof(Account))]
    public Account Account { get; set; }
    
    [DisplayName(nameof(Content))]
    [DataType(DataType.MultilineText)]
    public string Content { get; set; }

    [DisplayName(nameof(PostAttachments))]
    public List<PostAttachment> PostAttachments { get; set; }
    
    [DisplayName(nameof(PostReactions))]
    public List<PostReaction> PostReactions { get; set; }
}