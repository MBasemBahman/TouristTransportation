using Entities.CoreServicesModels.MainDataModels;
using System.ComponentModel;

namespace Dashboard.Areas.MainDataEntity.Models
{
   
    public class CurrencyFilter : DtParameters
    {
        public int Id { get; set; }
    }

    public class CurrencyDto : CurrencyModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }

        [DisplayName(nameof(LastModifiedAt))]
        public new string LastModifiedAt { get; set; }
    }
}
