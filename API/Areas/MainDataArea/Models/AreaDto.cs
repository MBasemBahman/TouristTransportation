using Entities.CoreServicesModels.MainDataModels;

namespace API.Areas.MainDataArea.Models
{
    public class AreaDto : AreaModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }
    }
}