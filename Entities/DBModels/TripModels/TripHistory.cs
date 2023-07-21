using Entities.DBModels.AccountModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.MainDataModels;

namespace Entities.DBModels.TripModels;

public class TripHistory : AuditEntity
{
    [DisplayName(nameof(Trip))]
    [ForeignKey(nameof(Trip))]
    public int Fk_Trip { get; set; }
    
    [DisplayName(nameof(Trip))]
    public Trip Trip { get; set; }
    
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
    
    [DisplayName(nameof(TripState))]
    [ForeignKey(nameof(TripState))]
    public int? Fk_TripState { get; set; }
    
    [DisplayName(nameof(TripState))]
    public TripState TripState { get; set; }
    
    [DisplayName(nameof(Notes))] 
    [DataType(DataType.MultilineText)]
    public string Notes { get; set; }
}