using API.Areas.AccountArea.Models;
using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;

namespace API.Areas.TripArea.Models
{
    public class TripHistoryDto : TripHistoryModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Trip))]
        public new TripDto Trip { get; set; }

        [DisplayName(nameof(Driver))]
        public new AccountDto Driver { get; set; }

        [DisplayName(nameof(TripState))]
        public new TripStateDto TripState { get; set; }
    }
}
