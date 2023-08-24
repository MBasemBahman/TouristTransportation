namespace Entities.DBModels.CompanyTripModels;

public class CompanyTripAttachment : AuditAttachmentEntity
{
    [DisplayName(nameof(CompanyTrip))]
    [ForeignKey(nameof(CompanyTrip))]
    public int Fk_CompanyTrip { get; set; }

    [DisplayName(nameof(CompanyTrip))]
    public CompanyTrip CompanyTrip { get; set; }

    [DisplayName(nameof(AttachmentUrl))]
    public string AttachmentUrl { get; set; }
}