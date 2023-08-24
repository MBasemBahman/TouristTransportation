using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.PostModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.PostModels
{
    public class PostReactionParameters : RequestParameters
    {
        public int Fk_Post { get; set; }
        public int Fk_Account { get; set; }
    }

    public class PostReactionModel : AuditEntity
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName(nameof(Post))]
        public PostModel Post { get; set; }

        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(Account))]
        public AccountModel Account { get; set; }

        [DisplayName(nameof(ReactionEnum))]
        public DBModelsEnum.ReactionEnum ReactionEnum { get; set; }
    }

    public class PostReactionCreateOrEditModel
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(ReactionEnum))]
        public DBModelsEnum.ReactionEnum ReactionEnum { get; set; }
    }
}
