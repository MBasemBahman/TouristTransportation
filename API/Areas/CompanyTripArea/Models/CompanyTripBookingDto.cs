using Entities.CoreServicesModels.CompanyTripModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.CompanyTripModels;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace API.Areas.CompanyTripArea.Models
{
    public class CompanyTripBookingDto : CompanyTripBookingModel
    {
    }

    public class CompanyTripBookingCreateModel : CompanyTripBookingEditModel
    {
        public int Fk_CompanyTrip { get; set; }

        public int Fk_Currency { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }

        [DisplayName(nameof(MembersCount))]
        public int MembersCount { get; set; }

        [DisplayName(nameof(Date))]
        public DateTime Date { get; set; }
    }

    public class CompanyTripBookingEditModel
    {
        public int Fk_CompanyTripBookingState { get; set; }

    }
}
