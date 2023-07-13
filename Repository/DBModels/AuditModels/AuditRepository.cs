using Entities.CoreServicesModels.AuditModels;
using Entities.DBModels.AuditModels;

namespace Repository.DBModels.AuditModels
{
    public class AuditRepository : RepositoryBase<Audit>
    {
        public AuditRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Audit> FindAll(AuditParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                           parameters.TableName,
                           parameters.CreatedAtFrom,
                           parameters.CreatedAtTo,
                           parameters.TableNames,
                           parameters.SearchTerm,
                           parameters.AuditTypes);
        }

    }

    public static class AuditRepositoryExtension
    {
        public static IQueryable<Audit> Filter(this IQueryable<Audit> data,
            int id,
            string tableName,
            DateTime? createdAtFrom,
            DateTime? createdAtTo,
            List<string> tableNames,
            string searchTerm,
            List<string> auditTypes)
        {
            return data.Where(a => (id == 0 || a.Id == id) &&
              (string.IsNullOrEmpty(searchTerm) || a.KeyValues.Contains(searchTerm)) &&
              (string.IsNullOrEmpty(tableName) || a.TableName == tableName) &&

              // filter with audit type (create)
              (auditTypes == null || !auditTypes.Any() ||
                (auditTypes.Any(b => b == "Create") &&
                 string.IsNullOrEmpty(a.OldValues) &&
                 !string.IsNullOrEmpty(a.NewValues)) ||

                (auditTypes.Any(b => b == "Update") &&
                 !string.IsNullOrEmpty(a.NewValues) &&
                 !string.IsNullOrEmpty(a.OldValues)) ||

                (auditTypes.Any(b => b == "Remove") &&
                 string.IsNullOrEmpty(a.NewValues))
                ) &&

              (tableNames == null || !tableNames.Any() || tableNames.Contains(a.TableName)) &&
              (createdAtFrom == null || a.CreatedAt >= createdAtFrom) &&
              (createdAtTo == null || createdAtFrom == createdAtTo || a.CreatedAt <= createdAtTo));
        }

    }
}
