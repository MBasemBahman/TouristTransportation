using Entities.EnumData;

namespace Entities.DBModels.CompanyTripModels;

public class CompanyTrip : AuditImageEntity
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    [DisplayName($"{nameof(Title)}{PropertyAttributeConstants.ArLang}")]
    public string Title { get; set; }

    [DisplayName(nameof(CompanyTripState))]
    [ForeignKey(nameof(CompanyTripState))]
    public int Fk_CompanyTripState { get; set; }
    
    [DisplayName(nameof(CompanyTripState))]
    public CompanyTripState CompanyTripState { get; set; }
    
    [DisplayName(nameof(Description))]
    [DataType(DataType.MultilineText)]
    public string Description { get; set; }

    [DisplayName(nameof(Price))]
    public double Price { get; set; }

    [DisplayName(nameof(Notes))]
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }

    [DisplayName(nameof(CompanyTripAttachments))]
    public List<CompanyTripAttachment> CompanyTripAttachments { get; set; }
    
    public List<CompanyTripLang> CompanyTripLangs { get; set; }
}

public class CompanyTripLang : AuditLangEntity<CompanyTrip>
{
    [Required(ErrorMessage = PropertyAttributeConstants.RequiredMsg)]
    public string Title { get; set; }

    [DisplayName(nameof(Language))]
    public DBModelsEnum.LanguageEnum Language { get; set; }
}