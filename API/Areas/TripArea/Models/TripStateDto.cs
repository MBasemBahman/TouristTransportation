﻿using Entities.CoreServicesModels.TripModels;
namespace API.Areas.TripArea.Models
{
    public class TripStateDto : TripStateModel
    {
        public new string LastModifiedAt { get; set; }

        public new string CreatedAt { get; set; }

    }
}
