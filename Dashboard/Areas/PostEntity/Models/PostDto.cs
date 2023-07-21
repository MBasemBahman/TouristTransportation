using Entities.CoreServicesModels.PostModels;
using System.ComponentModel;

namespace Dashboard.Areas.PostEntity.Models
{
    public class PostFilter : DtParameters
    {
        public int Id { get; set; }
    }
    public class PostDto : PostModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}
