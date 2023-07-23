using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;

namespace Dashboard.Areas.TripEntity.Models
{
    public class TripStateFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class TripStateDto : TripStateModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

    }
}
