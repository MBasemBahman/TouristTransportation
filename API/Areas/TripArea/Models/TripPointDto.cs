using Entities.CoreServicesModels.TripModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace API.Areas.TripArea.Models
{
    public class TripPointDto : TripPointModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Trip))]
        public new TripDto Trip { get; set; }

        [DisplayName(nameof(TripAt))]
        public new string TripAt { get; set; }

        [DisplayName(nameof(LeaveAt))]
        public new string LeaveAt { get; set; }

    }

    public class TripPointCreateDto : TripPointEditDto
    {
        public int Fk_Trip { get; set; }

    
    }

    public class TripPointEditDto 
    {
        [DisplayName(nameof(FromLatitude))]
        public double? FromLatitude { get; set; }

        [DisplayName(nameof(FromLongitude))]
        public double? FromLongitude { get; set; }

        [DisplayName(nameof(ToLatitude))]
        public double? ToLatitude { get; set; }

        [DisplayName(nameof(ToLongitude))]
        public double? ToLongitude { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }

        [DisplayName(nameof(TripAt))]
        public DateTime? TripAt { get; set; }

        [DisplayName(nameof(LeaveAt))]
        public DateTime? LeaveAt { get; set; }

        [DisplayName(nameof(WaitingTime))]
        public double WaitingTime { get; set; }

        [DisplayName(nameof(WaitingTimeCost))]
        public double WaitingTimeCost { get; set; }

    }
}
