using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;

namespace Dashboard.Areas.TripEntity.Models
{
    public class TripFilter : DtParameters
    {
        public int Id { get; set; }
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
