using Entities.CoreServicesModels.AuditModels;
using System.ComponentModel;
namespace Dashboard.Areas.AuditEntity.Models
{
    public class AuditFilter : DtParameters
    {
        [DisplayName(nameof(AuditType))]
        public List<string> AuditTypes { get; set; }

        [DisplayName("CreatedAt")]
        public DateTime? CreatedAtFrom { get; set; }

        public DateTime? CreatedAtTo { get; set; }

        [DisplayName(nameof(TableName))]
        public string TableName { get; set; }
    }
    public class AuditDto : AuditModel
    {
        [DisplayName(nameof(CreatedAt))]
        public new string CreatedAt { get; set; }
    }

    public enum AuditTableNameEnum
    {

        Branchs = 1,
        BranchRequests,
        Contracts,
        ContractContactPersons,
        ContractRenews,
        Licensess,
        LicensesRenew,
        Permits,
        PermitRenew,
        Employees,
        EmployeeRequests,
        EmployeePassports,
        AdvanceRequests,
        VacationRequests,
        ClaimDuesRequests,
        Custodys,
        Vehicles,
        Companys
    }
}
