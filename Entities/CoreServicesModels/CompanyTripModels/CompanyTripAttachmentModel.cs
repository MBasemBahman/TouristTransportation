using Entities.DBModels.CompanyTripModels;

namespace Entities.CoreServicesModels.CompanyTripModels
{
    public class CompanyTripAttachmentParameters : RequestParameters
    {
        public int Fk_CompanyTrip { get; set; }
    }

    public class CompanyTripAttachmentModel : AuditEntity
    {
        [DisplayName(nameof(CompanyTrip))]
        [ForeignKey(nameof(CompanyTrip))]
        public int Fk_CompanyTrip { get; set; }
    
        [DisplayName(nameof(CompanyTrip))]
        public CompanyTripModel CompanyTrip { get; set; }

        [DisplayName(nameof(AttachmentUrl))]
        public string AttachmentUrl { get; set; }
    }

    public class CompanyTripAttachmentCreateOrEditModel
    {
        [DisplayName(nameof(CompanyTrip))]
        [ForeignKey(nameof(CompanyTrip))]
        public int Fk_CompanyTrip { get; set; }

        [DisplayName(nameof(AttachmentUrl))]
        public string AttachmentUrl { get; set; }

    }
}
