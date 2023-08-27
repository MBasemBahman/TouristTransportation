using Entities.CoreServicesModels.CompanyTripModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

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
        public new string Notes { get; set; }

        [DisplayName(nameof(MembersCount))]
        public int MembersCount { get; set; }

        [DisplayName(nameof(Date))]
        public DateTime Date { get; set; }
    }

    public class CompanyTripBookingEditModel
    {
        public int Fk_CompanyTripBookingState { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }
}
