namespace Entities.DBModels.TripModels;

public class TripPoint : AuditEntity
{
    [DisplayName(nameof(Trip))]
    [ForeignKey(nameof(Trip))]
    public int Fk_Trip { get; set; }

    [DisplayName(nameof(Trip))]
    public Trip Trip { get; set; }

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
    public double WaitingTimeCost => Trip?.WaitingPrice * WaitingTime ?? 0; // In Minutes
}