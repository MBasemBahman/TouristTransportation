namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripState : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(CompanyTrips))]
    public List<CompanyTrip> CompanyTrips { get; set; }
}