using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.UserModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using Dashboard.Areas.MainDataEntity.Models;

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

    [DisplayName(nameof(AccountType))]
    public new AccountTypeDto AccountType { get; set; }

    [DisplayName(nameof(AccountState))]
    public new AccountStateDto AccountState { get; set; }

    [DisplayName(nameof(Supplier))]
    public new SupplierDto Supplier { get; set; }
}