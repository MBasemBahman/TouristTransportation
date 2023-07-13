namespace Entities.DBModels.MainDataModels;

public class Currency : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }
    
    [DisplayName(nameof(RateInPounds))]
    public double RateInPounds { get; set; }
}