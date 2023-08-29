using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;

namespace Dashboard.Areas.TripEntity.Models
{
    public class TripFilter : DtParameters
    {
        public int Id { get; set; }
        
        public int Fk_Account { get; set; }
        [DisplayName("Client")]
        public int Fk_Client { get; set; }
        [DisplayName("Supplier")]
        public int? Fk_Supplier { get; set; }
        [DisplayName("Driver")]
        public int? Fk_Driver { get; set; }
        [DisplayName("CarClass")]
        public int? Fk_CarClass { get; set; }
        [DisplayName("TripState")]
        public int? Fk_TripState { get; set; }
    }

    public class TripDto : TripModel
    {
        [DisplayName(nameof(TripAt))]
        public new string TripAt { get; set; }
        
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

    }
}
