using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.CarModels;
using Entities.DBModels.MainDataModels;
using Entities.DBModels.TripModels;

namespace Entities.CoreServicesModels.TripModels
{
    public class TripParameters : RequestParameters
    {
        public int Fk_Account { get; set; }
        public int Fk_Client { get; set; }
        public int? Fk_Supplier { get; set; }
        public int? Fk_Driver { get; set; }
        public int? Fk_CarClass { get; set; }
        public int? Fk_TripState { get; set; }
    }

    public class TripModel : AuditEntity
    {
        [DisplayName(nameof(Client))]
        [ForeignKey(nameof(Client))]
        public int Fk_Client { get; set; }

        [DisplayName(nameof(Client))]
        public AccountModel Client { get; set; }

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

        [DisplayName(nameof(CarClass))]
        [ForeignKey(nameof(CarClass))]
        public int? Fk_CarClass { get; set; }

        [DisplayName(nameof(CarClass))]
        public CarClassModel CarClass { get; set; }

        [DisplayName(nameof(TripState))]
        [ForeignKey(nameof(TripState))]
        public int Fk_TripState { get; set; }

        [DisplayName(nameof(TripState))]
        public TripStateModel TripState { get; set; }

        [DisplayName(nameof(TripAt))]
        public DateTime? TripAt { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }

        [DisplayName(nameof(WaitingPrice))]
        public double WaitingPrice { get; set; }

        [DisplayName(nameof(MembersCount))]
        public int MembersCount { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

    public class TripCreateOrEditModel
    {
        [DisplayName(nameof(Fk_Client))]
        [ForeignKey(nameof(Fk_Client))]
        public int Fk_Client { get; set; }

        [DisplayName(nameof(Supplier))]
        [ForeignKey(nameof(Supplier))]
        public int? Fk_Supplier { get; set; }

        [DisplayName(nameof(Fk_Driver))]
        [ForeignKey(nameof(Fk_Driver))]
        public int? Fk_Driver { get; set; }

        [DisplayName(nameof(CarClass))]
        [ForeignKey(nameof(CarClass))]
        public int? Fk_CarClass { get; set; }

        [DisplayName(nameof(TripState))]
        [ForeignKey(nameof(TripState))]
        public int Fk_TripState { get; set; }

        [DisplayName(nameof(TripAt))]
        public DateTime? TripAt { get; set; }

        [DisplayName(nameof(Price))]
        public double Price { get; set; }

        [DisplayName(nameof(WaitingPrice))]
        public double WaitingPrice { get; set; }

        [DisplayName(nameof(MembersCount))]
        public int MembersCount { get; set; }

        [DisplayName(nameof(Notes))]
        [DataType(DataType.MultilineText)]
        public string Notes { get; set; }
    }

}
