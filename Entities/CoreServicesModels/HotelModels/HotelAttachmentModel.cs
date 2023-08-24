﻿using Entities.DBModels.HotelModels;

namespace Entities.CoreServicesModels.HotelModels
{
    public class HotelAttachmentParameters : RequestParameters
    {
        public int Fk_Hotel { get; set; }
    }

    public class HotelAttachmentModel : AuditAttachmentEntity
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(Hotel))]
        public HotelModel Hotel { get; set; }
    }

    public class HotelAttachmentCreateOrEditModel
    {
        [DisplayName(nameof(Hotel))]
        [ForeignKey(nameof(Hotel))]
        public int Fk_Hotel { get; set; }

        [DisplayName(nameof(AttachmentUrl))]
        public string AttachmentUrl { get; set; }

    }
}
