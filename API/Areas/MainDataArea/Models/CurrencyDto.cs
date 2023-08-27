using Entities.CoreServicesModels.MainDataModels;

namespace API.Areas.MainDataArea.Models
{
    public class CurrencyDto : CurrencyModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }
}