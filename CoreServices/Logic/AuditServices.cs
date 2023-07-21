using Entities.CoreServicesModels.AuditModels;
using Entities.DBModels.AuditModels;

namespace CoreServices.Logic
{
    public class AuditServices
    {
        private readonly RepositoryManager _repository;

        public AuditServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Audit Services

        public IQueryable<AuditModel> GetAudits(AuditParameters parameters, bool otherLang)
        {
            return _repository.Audit
                       .FindAll(parameters, trackChanges: false)
                       .Select(a => new AuditModel
                       {
                           Id = a.Id,
                           CreatedAt = a.CreatedAt,
                           KeyValues = a.KeyValues,
                           NewValues = a.NewValues,
                           OldValues = a.OldValues,
                           CreatedBy = a.CreatedBy,
                           TableName = a.TableName,
                           AuditType = string.IsNullOrEmpty(a.OldValues) && !string.IsNullOrEmpty(a.NewValues) ?
                           new AuditType
                           {
                               Name = otherLang ? "Create" : "إنشاء",
                               ColorCode = "Green"

                           } : !string.IsNullOrEmpty(a.NewValues) && !string.IsNullOrEmpty(a.OldValues) ?
                           new AuditType
                           {
                               Name = otherLang ? "Update" : "تعديل",
                               ColorCode = "Orange"

                           } : new AuditType
                           {
                               Name = otherLang ? "Remove" : "حذف",
                               ColorCode = "Red"

                           },
                       })
                       // .Search(parameters.SearchColumns, parameters.SearchTerm)
                       .Sort(parameters.OrderBy);
        }


        public int GetAuditsCount()
        {
            return _repository.Audit.Count();
        }

        public AuditModel GetAuditbyId(int id, bool otherLang)
        {
            return GetAudits(new AuditParameters { Id = id }, otherLang).SingleOrDefault();
        }


        public async Task<PagedList<AuditModel>> GetAuditsPaged(
             AuditParameters parameters, bool otherLang)
        {
            return await PagedList<AuditModel>.ToPagedList(GetAudits(parameters, otherLang), parameters.PageNumber, parameters.PageSize);
        }


        public async Task DeleteAudit(int id)
        {
            Audit Audit = await _repository.Audit.FindByCondition(a => a.Id == id, trackChanges: false).FirstAsync();
            _repository.Audit.Delete(Audit);
        }


        #endregion

    }
}
