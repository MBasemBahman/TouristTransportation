using Entities.DBModels.MainDataModels;
using Entities.DBModels.PostModels;

namespace Entities.DBModels.AccountModels;

public class Account : AuditImageEntity
{
    [DisplayName(nameof(Name))]
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Name { get; set; }

    [DisplayName(nameof(Phone))]
    [Phone]
    public string Phone { get; set; }

    [DisplayName(nameof(EmailAddress))]
    [EmailAddress]
    public string EmailAddress { get; set; }

    [DisplayName(nameof(Supplier))]
    [ForeignKey(nameof(Supplier))]
    public int? Fk_Supplier { get; set; }

    [DisplayName(nameof(Supplier))]
    public Supplier Supplier { get; set; }
    
    [DisplayName(nameof(Posts))]
    public List<Post> Posts { get; set; }
}