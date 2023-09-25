using API.Areas.AccountArea.Models;
using API.Areas.CarArea.Models;
using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Areas.TripArea.Models
{
    public class TripCurrentStateDto
    {
        public TripStateDto CurrentTripState { get; set; }
        public List<TripStateDto> NextTripStates { get; set; }
    }
}