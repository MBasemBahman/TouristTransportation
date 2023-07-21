using Entities.CoreServicesModels.PostModels;
using System.ComponentModel;

namespace Dashboard.Areas.PostEntity.Models
{
    public class PostReactionFilter : DtParameters
    {
        public int Id { get; set; }
    }
    public class PostReactionDto : PostReactionModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}
