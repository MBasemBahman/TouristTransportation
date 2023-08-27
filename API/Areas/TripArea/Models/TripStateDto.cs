using Entities.CoreServicesModels.TripModels;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
namespace API.Areas.TripArea.Models
{
    public class TripStateDto : TripStateModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

    }
}
