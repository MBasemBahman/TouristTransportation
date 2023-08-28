using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;

namespace Dashboard.Areas.TripEntity.Models
{
    public class TripPointFilter : DtParameters
    {
        public int Id { get; set; }
        public int Fk_Trip { get; set; }
    }

    public class TripPointDto : TripPointModel
    {
        [DisplayName(nameof(LeaveAt))]
        public new string LeaveAt { get; set; }
        
        [DisplayName(nameof(TripAt))]
        public new string TripAt { get; set; }
        
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

    }
}
