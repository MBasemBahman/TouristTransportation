namespace Entities.DBModels.MainDataModels;

public class Supplier : AuditEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName(nameof(Name))]
    public string Name { get; set; }
}