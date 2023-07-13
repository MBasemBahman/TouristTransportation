using Entities.DBModels.TripModels;

namespace Entities.DBModels.CarModels;

public class CarClass : AuditEntity
{
    [DisplayName(nameof(TripState))]
    [ForeignKey(nameof(TripState))]
    public int Fk_TripState { get; set; }
    
    [DisplayName(nameof(TripState))]
    public TripState TripState { get; set; }
}