using Entities.DBModels.AccountModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.MainDataModels;

namespace Entities.DBModels.TripModels;

public class Trip : AuditEntity
{
    [DisplayName(nameof(Client))]
    [ForeignKey(nameof(Client))]
    public int Fk_Client { get; set; }

    [DisplayName(nameof(Client))]
    public Account Client { get; set; }

    [DisplayName(nameof(Supplier))]
    [ForeignKey(nameof(Supplier))]
    public int? Fk_Supplier { get; set; }

    [DisplayName(nameof(Supplier))]
    public Supplier Supplier { get; set; }

    [DisplayName(nameof(Driver))]
    [ForeignKey(nameof(Driver))]
    public int? Fk_Driver { get; set; }

    [DisplayName(nameof(Driver))]
    public Account Driver { get; set; }

    [DisplayName(nameof(CarClass))]
    [ForeignKey(nameof(CarClass))]
    public int? Fk_CarClass { get; set; }

    [DisplayName(nameof(CarClass))]
    public CarClass CarClass { get; set; }

    [DisplayName(nameof(TripState))]
    [ForeignKey(nameof(TripState))]
    public int Fk_TripState { get; set; }

    [DisplayName(nameof(TripState))]
    public TripState TripState { get; set; }

    [DisplayName(nameof(TripAt))]
    public DateTime? TripAt { get; set; }

    [DisplayName(nameof(Price))]
    public double Price { get; set; }

    [DisplayName(nameof(WaitingPrice))]
    public double WaitingPrice { get; set; }

    [DisplayName(nameof(MembersCount))]
    public int MembersCount { get; set; }

    [DisplayName(nameof(Notes))]
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }

    [DisplayName(nameof(TripPoints))]
    public List<TripPoint> TripPoints { get; set; }

    [DisplayName(nameof(TripHistories))]
    public List<TripHistory> TripHistories { get; set; }

    [DisplayName(nameof(TripLocations))]
    public List<TripLocation> TripLocations { get; set; }
}