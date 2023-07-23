using Entities.CoreServicesModels.CarModels;
using System.ComponentModel;

namespace Dashboard.Areas.CarEntity.Models
{
    public class CarCategoryFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class CarCategoryDto : CarCategoryModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}
