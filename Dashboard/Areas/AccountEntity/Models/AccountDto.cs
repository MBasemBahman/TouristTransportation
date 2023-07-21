using Entities.CoreServicesModels.AccountModels;
using System.ComponentModel;

namespace Dashboard.Areas.AccountEntity.Models;

public class AccountFilter : DtParameters
{
    public int Id { get; set; }

}

public class AccountDto : AccountModel
{
    [DisplayName(nameof(CreatedAt))]
    public new string CreatedAt { get; set; }

    [DisplayName(nameof(LastModifiedAt))]
    public new string LastModifiedAt { get; set; }
}