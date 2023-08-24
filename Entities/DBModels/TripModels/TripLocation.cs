namespace Entities.DBModels.TripModels
{
    public class TripLocation : BaseEntity
    {
        [DisplayName(nameof(Trip))]
        [ForeignKey(nameof(Trip))]
        public int Fk_Trip { get; set; }

        [DisplayName(nameof(Trip))]
        public Trip Trip { get; set; }

        [DisplayName(nameof(Latitude))]
        public decimal Latitude { get; set; }

        [DisplayName(nameof(Longitude))]
        public decimal Longitude { get; set; }
    }
}
