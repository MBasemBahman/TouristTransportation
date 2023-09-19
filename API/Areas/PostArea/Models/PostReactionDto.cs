using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;
using Entities.EnumData;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;

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

    public class PostReactionEditDto
    {
        [DisplayName(nameof(Post))]
        [ForeignKey(nameof(Post))]
        public int Fk_Post { get; set; }
    }

}
