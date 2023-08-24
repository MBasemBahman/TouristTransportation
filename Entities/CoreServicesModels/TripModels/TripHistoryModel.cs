using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.MainDataModels;
using Entities.DBModels.TripModels;

namespace Entities.CoreServicesModels.TripModels
{
    public class TripHistoryParameters : RequestParameters
    {
        public int Fk_Trip { get; set; }
        public int? Fk_Supplier { get; set; }
        public int? Fk_Driver { get; set; }
        public int? Fk_TripState { get; set; }
    }

    public class TripHistoryModel : AuditEntity
    {
        [DisplayName(nameof(Trip))]
        [ForeignKey(nameof(Trip))]
        public int Fk_Trip { get; set; }

        [DisplayName(nameof(Trip))]
        public TripModel Trip { get; set; }

        [DisplayName(nameof(Supplier))]
        [ForeignKey(nameof(Supplier))]
        public int? Fk_Supplier { get; set; }

        [DisplayName(nameof(Supplier))]
        public SupplierModel Supplier { get; set; }

        [DisplayName(nameof(Driver))]
        [ForeignKey(nameof(Driver))]
        public int? Fk_Driver { get; set; }

        [DisplayName(nameof(Driver))]
        public AccountModel Driver { get; set; }

        [DisplayName(nameof(TripState))]
        [ForeignKey(nameof(TripState))]
        public int? Fk_TripState { get; set; }

        [DisplayName(nameof(TripState))]
        public TripStateModel TripState { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

    public class TripHistoryCreateOrEditModel
    {
        [DisplayName(nameof(Trip))]
        [ForeignKey(nameof(Trip))]
        public int Fk_Trip { get; set; }

        [DisplayName(nameof(Supplier))]
        [ForeignKey(nameof(Supplier))]
        public int? Fk_Supplier { get; set; }

        [DisplayName(nameof(Fk_Driver))]
        [ForeignKey(nameof(Fk_Driver))]
        public int? Fk_Driver { get; set; }

        [DisplayName(nameof(TripState))]
        [ForeignKey(nameof(TripState))]
        public int? Fk_TripState { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

}
