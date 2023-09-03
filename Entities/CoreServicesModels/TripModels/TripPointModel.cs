using Entities.DBModels.TripModels;

namespace Entities.CoreServicesModels.TripModels
{
    public class TripPointParameters : RequestParameters
    {
        public int Fk_Trip { get; set; }
    }

    public class TripPointModel : BaseEntity
    {
        [DisplayName(nameof(Trip))]
        [ForeignKey(nameof(Trip))]
        public int Fk_Trip { get; set; }

        [DisplayName(nameof(Trip))]
        public TripModel Trip { get; set; }

        [DisplayName(nameof(FromAddress))]
        public string FromAddress { get; set; }

        [DisplayName(nameof(FromLatitude))]
        public double? FromLatitude { get; set; }

        [DisplayName(nameof(FromLongitude))]
        public double? FromLongitude { get; set; }

        [DisplayName(nameof(ToAddress))]
        public string ToAddress { get; set; }

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
        public double WaitingTime { get; set; } // In Minutes

        [DisplayName(nameof(WaitingTimeCost))]
        public double WaitingTimeCost { get; set; } // In Minutes
    }

    public class TripPointCreateOrEditModel
    {
        [DisplayName(nameof(Trip))]
        [ForeignKey(nameof(Trip))]
        public int Fk_Trip { get; set; }

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
        public double WaitingTime { get; set; } // In Minutes
        
        [DisplayName(nameof(FromAddress))] 
        public string FromAddress { get; set; }
        
        [DisplayName(nameof(ToAddress))] 
        public string ToAddress { get; set; }
    }

}
