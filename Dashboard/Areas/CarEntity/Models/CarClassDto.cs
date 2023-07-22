using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CarModels;
using System.ComponentModel;

namespace Dashboard.Areas.CarEntity.Models
{
    public class CarClassFilter : DtParameters
    {
        public int Id { get; set; }
        public int Fk_CarCategory { get; set; }
    }

    public class CarClassDto : CarClassModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

        [DisplayName(nameof(CarCategory))]
        public new CarCategoryDto CarCategory { get; set; }
    }
}
