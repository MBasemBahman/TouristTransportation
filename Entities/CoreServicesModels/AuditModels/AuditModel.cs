namespace Entities.CoreServicesModels.AuditModels
{
    public class AuditParameters : RequestParameters
    {
        [DisplayName(nameof(AuditType))]
        public List<string> AuditTypes { get; set; }

        [DisplayName(nameof(TableName))]
        public string TableName { get; set; }

        [DisplayName("CreatedAt")]
        public DateTime? CreatedAtFrom { get; set; }

        public DateTime? CreatedAtTo { get; set; }

        public List<string> TableNames { get; set; }
    }
    public class AuditModel : BaseEntity
    {
        [DisplayName(nameof(TableName))]
        public string TableName { get; set; }

        [DisplayName(nameof(KeyValues))]
        public string KeyValues { get; set; }

        [DisplayName(nameof(OldValues))]
        public string OldValues { get; set; }

        [DisplayName(nameof(NewValues))]
        public string NewValues { get; set; }

        [DisplayName(nameof(CreatedBy))]
        public string CreatedBy { get; set; }

        [DisplayName(nameof(AuditType))]
        public AuditType AuditType { get; set; }
    }


    public class AuditType
    {
        public string Name { get; set; }

        public string ColorCode { get; set; }
    }
}
