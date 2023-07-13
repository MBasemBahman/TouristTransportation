namespace Entities.CoreServicesModels.AccountModels
{
    public class AccountParameters : RequestParameters
    {
        public string EmailAddress { get; set; }
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

        [DisplayName(nameof(EmailAddress))]
        [EmailAddress]
        public string EmailAddress { get; set; }
    }

    public class AccountCreateOrEditModel
    {
        [DisplayName(nameof(Name))]
        [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
        public string Name { get; set; }

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
