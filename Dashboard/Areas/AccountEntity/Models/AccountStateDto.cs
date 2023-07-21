using Entities.CoreServicesModels.AccountModels;
using System.ComponentModel;

namespace Dashboard.Areas.AccountEntity.Models
{
    public class AccountStateFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class AccountStateDto : AccountStateModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}
