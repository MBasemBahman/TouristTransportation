using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.UserModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.MainDataModels;

namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountParameters : RequestParameters
    {
        public string EmailAddress { get; set; }
        public int Fk_AccountType { get; set; }
        public int Fk_AccountState { get; set; }
        public int Fk_Supplier { get; set; }
        public int? Fk_User { get; set; }
    }

    public class AccountModel : AuditImageEntity
    {
        [DisplayName(nameof(ImageUrl))]
        public new string ImageUrl { get; set; }

        [DisplayName(nameof(Phone))]
        [Phone]
        public string Phone { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountType))]
        public AccountTypeModel AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        [ForeignKey(nameof(AccountState))]
        public int Fk_AccountState { get; set; }

        [DisplayName(nameof(AccountState))]
        public AccountStateModel AccountState { get; set; }
        
        [DisplayName(nameof(EmailAddress))]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName(nameof(User))] 
        public int? Fk_User { get; set; }
        
        [DisplayName(nameof(User))]
        public UserModel User { get; set; }

        [DisplayName(nameof(Supplier))]
        [ForeignKey(nameof(Supplier))]
        public int? Fk_Supplier { get; set; }

        [DisplayName(nameof(Supplier))]
        public SupplierModel Supplier { get; set; }

    }

    public class AccountCreateOrEditModel
    {
        [DisplayName(nameof(AccountType))]
        [ForeignKey(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        [ForeignKey(nameof(AccountState))]
        public int Fk_AccountState { get; set; }

        [DisplayName(nameof(User))]
        public UserCreateModel User { get; set; }
        
        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }

        [DisplayName(nameof(Supplier))]
        [ForeignKey(nameof(Supplier))]
        public int? Fk_Supplier { get; set; }

        [DisplayName(nameof(Phone))]
        [Phone]
        public string Phone { get; set; }

        [DisplayName(nameof(EmailAddress))]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
