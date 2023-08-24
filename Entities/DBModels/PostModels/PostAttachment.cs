namespace Entities.DBModels.PostModels;

public class PostAttachment : AuditAttachmentEntity
{
    [DisplayName(nameof(Post))]
    [ForeignKey(nameof(Post))]
    public int Fk_Post { get; set; }

    [DisplayName(nameof(Post))]
    public Post Post { get; set; }
}