using Entities.CoreServicesModels.MainDataModels;
using System.ComponentModel;

namespace Dashboard.Areas.MainDataEntity.Models
{
  
    public class AreaFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class AreaDto : AreaModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }

        [DisplayName(nameof(Country))]
        public new CountryDto Country { get; set; }
    }
}
