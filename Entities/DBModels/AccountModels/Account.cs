using Entities.DBModels.MainDataModels;
using Entities.DBModels.PostModels;
using Entities.DBModels.UserModels;

namespace Entities.DBModels.AccountModels;

public class Account : AuditImageEntity
{
    [DisplayName(nameof(User))]
    [ForeignKey(nameof(User))]
    public int? Fk_User { get; set; }

    [DisplayName(nameof(User))]
    public User User { get; set; }

    [DisplayName(nameof(Supplier))]
    [ForeignKey(nameof(Supplier))]
    public int? Fk_Supplier { get; set; }

    [DisplayName(nameof(Supplier))]
    public Supplier Supplier { get; set; }
    
    [DisplayName(nameof(Posts))]
    public List<Post> Posts { get; set; }
}