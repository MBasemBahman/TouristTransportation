using Entities.CoreServicesModels.AccountModels;
using System.ComponentModel;

namespace Dashboard.Areas.AccountEntity.Models
{
  
    public class AccountTypeFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class AccountTypeDto : AccountTypeModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

     
    }
}
