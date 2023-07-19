using Entities.DBModels.AccountModels;

namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountParameters : RequestParameters
    {
        public string EmailAddress { get; set; }
        public int Fk_AccountType { get; set; }
        public int Fk_AccountState { get; set; }
    }

    public class AccountModel : AuditImageEntity
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

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
    }

    public class AccountCreateOrEditModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

        [DisplayName(nameof(AccountType))]
        [ForeignKey(nameof(AccountType))]
        public int Fk_AccountType { get; set; }

        [DisplayName(nameof(AccountState))]
        [ForeignKey(nameof(AccountState))]
        public int Fk_AccountState { get; set; }

        [DisplayName(nameof(ImageUrl))]
        public string ImageUrl { get; set; }

        [DisplayName(nameof(Phone))]
        [Phone]
        public string Phone { get; set; }

        [DisplayName(nameof(EmailAddress))]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }
}
