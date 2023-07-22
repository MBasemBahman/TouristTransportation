using Entities.CoreServicesModels.AccountModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;

namespace Entities.CoreServicesModels.PostModels
{
    public class PostParameters : RequestParameters
    {
        public int Fk_Account { get; set; }
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
    }

    public class PostCreateOrEditModel
    {
        [DisplayName(nameof(Account))]
        [ForeignKey(nameof(Account))]
        public int Fk_Account { get; set; }

        [DisplayName(nameof(Content))]
        [DataType(DataType.MultilineText)]
        [Required]
        public string Content { get; set; }
    }
}
