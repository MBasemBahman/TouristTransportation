using API.Areas.AccountArea.Models;
using API.Areas.CarArea.Models;
using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Areas.TripArea.Models
{
    public class TripDto : TripModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Client))]
        public new AccountDto Client { get; set; }

        [DisplayName(nameof(Driver))]
        public new AccountDto Driver { get; set; }

        [DisplayName(nameof(CarClass))]
        public new CarClassDto CarClass { get; set; }

        [DisplayName(nameof(TripState))]
        public new TripStateDto TripState { get; set; }

        [DisplayName(nameof(TripAt))]
        public new string TripAt { get; set; }

        [DisplayName(nameof(TripPoints))]
        public List<TripPointDto> TripPoints { get; set; }

        [DisplayName(nameof(TripHistories))]
        public List<TripHistoryDto> TripHistories { get; set; }

        [DisplayName(nameof(TripLocations))]
        public List<TripLocationDto> TripLocations { get; set; }
    }

    public class TripEditDto
    {
        public int? Fk_CarClass { get; set; }

        [DisplayName(nameof(TripAt))]
        public DateTime? TripAt { get; set; }

        [DisplayName(nameof(MembersCount))]
        public int MembersCount { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }


    public class TripCreateDto : TripEditDto
    {
        public List<TripPointCreateDto> TripPoints { get; set; }
    }
}