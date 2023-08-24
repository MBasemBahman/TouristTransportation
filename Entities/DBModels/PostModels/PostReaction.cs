using Entities.DBModels.AccountModels;
using Entities.EnumData;

namespace Entities.DBModels.PostModels;

public class PostReaction : BaseEntity
{
    [DisplayName(nameof(Post))]
    [ForeignKey(nameof(Post))]
    public int Fk_Post { get; set; }

    [DisplayName(nameof(Post))]
    public Post Post { get; set; }

    [DisplayName(nameof(Account))]
    [ForeignKey(nameof(Account))]
    public int Fk_Account { get; set; }

    [DisplayName(nameof(Account))]
    public Account Account { get; set; }

    [DisplayName(nameof(Reaction))]
    public DBModelsEnum.ReactionEnum Reaction { get; set; }
}