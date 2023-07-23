using Entities.CoreServicesModels.HotelModels;
using System.ComponentModel;

namespace Dashboard.Areas.HotelEntity.Models
{
    public class HotelFeatureCategoryFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class HotelFeatureCategoryDto : HotelFeatureCategoryModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}

