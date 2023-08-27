using Entities.CoreServicesModels.PostModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using API.Areas.AccountArea.Models;
using Entities.DBModels.AccountModels;
using Entities.DBModels.PostModels;
using Entities.EnumData;

namespace API.Areas.PostArea.Models
{
    public class PostReactionDto : PostReactionModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Post))]
        public new PostDto Post { get; set; }

        [DisplayName(nameof(Account))]
        public new AccountDto Account { get; set; }

    }

    public class PostReactioEditDto
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }

        [DisplayName(nameof(ReactionEnum))]
        public DBModelsEnum.ReactionEnum ReactionEnum { get; set; }
    }

}
