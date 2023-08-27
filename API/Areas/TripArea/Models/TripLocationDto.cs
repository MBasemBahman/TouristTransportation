using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;
namespace API.Areas.TripArea.Models
{
    public class TripLocationDto : TripLocationModel
    {
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(Trip))]
        public new TripDto Trip { get; set; }
    }

    public class TripLocationCreateDto
    {
        public int Fk_Trip { get; set; }

        [DisplayName(nameof(Latitude))]
        public decimal Latitude { get; set; }

        [DisplayName(nameof(Longitude))]
        public decimal Longitude { get; set; }
    }
}
