namespace Entities.CoreServicesModels.TripModels
{
    public class TripLocationParameters : RequestParameters
    {
        public int Fk_Trip { get; set; }
    }

    public class TripLocationModel : BaseEntity
    {
        [DisplayName(nameof(Trip))]
        [ForeignKey(nameof(Trip))]
        public int Fk_Trip { get; set; }

        [DisplayName(nameof(Trip))]
        public TripModel Trip { get; set; }

        [DisplayName(nameof(Latitude))]
        public decimal Latitude { get; set; }

        [DisplayName(nameof(Longitude))]
        public decimal Longitude { get; set; }
    }
}
