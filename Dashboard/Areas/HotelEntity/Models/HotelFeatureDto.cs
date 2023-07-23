using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace Dashboard.Areas.HotelEntity.Models
{
    public class HotelFeatureFilter : DtParameters
    {
        public int Id { get; set; }
        public int Fk_HotelFeatureCategory { get; set; }

    }

    public class HotelFeatureDto : HotelFeatureModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

        [DisplayName(nameof(HotelFeatureCategory))]
        public new HotelFeatureCategoryDto HotelFeatureCategory { get; set; }
    }
}
