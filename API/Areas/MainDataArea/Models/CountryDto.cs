using Entities.CoreServicesModels.MainDataModels;

namespace API.Areas.MainDataArea.Models
{
    public class CountryDto : CountryModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }
}