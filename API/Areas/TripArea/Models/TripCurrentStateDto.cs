using API.Areas.AccountArea.Models;
using API.Areas.CarArea.Models;
using Entities.CoreServicesModels.TripModels;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace API.Areas.TripArea.Models
{
    public class TripCurrentStateDto
    {
        public int Fk_CurrentTripState { get; set; }
        public List<int> Fk_NextTripStates { get; set; }
    }
}