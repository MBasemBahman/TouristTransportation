namespace Entities.DBModels.HotelModels;

public class HotelFeatureCategory : AuditLookUpEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Name)}{PropertyAttributeConstants.ArLang}")]
    public new string Name { get; set; }

    [DisplayName(nameof(HotelFeatures))]
    public List<HotelFeature> HotelFeatures { get; set; }
}