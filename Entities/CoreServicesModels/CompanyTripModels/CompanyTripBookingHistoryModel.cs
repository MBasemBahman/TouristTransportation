using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.MainDataModels;

namespace Entities.CoreServicesModels.CompanyTripModels
{
    public class CompanyTripBookingHistoryParameters : RequestParameters
    {
        public int Fk_CompanyTripBooking { get; set; }
        public int CompanyTripBookingState { get; set; }
    }

    public class CompanyTripBookingHistoryModel : AuditEntity
    {
        [DisplayName(nameof(CompanyTripBooking))]
        [ForeignKey(nameof(CompanyTripBooking))]
        public int Fk_CompanyTripBooking { get; set; }
    
        [DisplayName(nameof(CompanyTripBooking))]
        public CompanyTripBookingModel CompanyTripBooking { get; set; }
        
        [DisplayName(nameof(CompanyTripBookingState))]
        [ForeignKey(nameof(CompanyTripBookingState))]
        public int Fk_CompanyTripBookingState { get; set; }
    
        [DisplayName(nameof(CompanyTripBookingState))]
        public CompanyTripBookingStateModel CompanyTripBookingState { get; set; }
        
        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

    public class CompanyTripBookingHistoryCreateOrEditModel
    {
        [DisplayName(nameof(CompanyTripBooking))]
        [ForeignKey(nameof(CompanyTripBooking))]
        public int Fk_CompanyTripBooking { get; set; }

        [DisplayName(nameof(CompanyTripBookingState))]
        [ForeignKey(nameof(CompanyTripBookingState))]
        public int Fk_CompanyTripBookingState { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

    }
}
