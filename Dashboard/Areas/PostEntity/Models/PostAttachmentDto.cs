using Entities.CoreServicesModels.PostModels;
using System.ComponentModel;

namespace Dashboard.Areas.PostEntity.Models
{
    public class PostAttachmentFilter : DtParameters
    {
        public int Id { get; set; }
        public int Fk_Post { get; set; }

    }
    public class PostAttachmentDto : PostAttachmentModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }


        [DisplayName(nameof(Post))]
        public new PostDto Post { get; set; }
    }

    public class PostAttachmentEditDto
    {
        public int Id { get; set; }

        [DisplayName(nameof(FileName))]
        public string FileName { get; set; }
    }

}