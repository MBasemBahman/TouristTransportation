using Entities.CoreServicesModels.AccountModels;

namespace API.Areas.AccountArea.Models
{
    public class AccountDto : AccountModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }

    public class AccountCreateOrEditDto : AccountCreateOrEditModel
    {
        public int? Fk_Account { get; set; }

        public List<IFormFile> AttachmentFiles { get; set; }
        public List<int> RmvAttachments { get; set; }
    }

}