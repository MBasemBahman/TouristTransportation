using Entities.CoreServicesModels.AuditModels;
namespace CoreServices.Extensions
{
    public static class AuditServiceSearchExtension
    {
        public static IQueryable<AuditModel> Search(this IQueryable<AuditModel> data, string searchColumns, string searchTerm)
        {
            if (string.IsNullOrWhiteSpace(searchTerm) || string.IsNullOrWhiteSpace(searchColumns))
            {
                return data;
            }

            searchTerm = searchTerm.SafeTrim().SafeLower();

            Expression<Func<AuditModel, bool>> expression = SearchQueryBuilder.CreateSearchQuery<AuditModel>(searchColumns, searchTerm);

            return data.Where(expression);
        }


    }

    public static class AuditServiceSortExtension
    {
        public static IQueryable<AuditModel> Sort(this IQueryable<AuditModel> data, string orderByQueryString)
        {
            if (string.IsNullOrWhiteSpace(orderByQueryString))
            {
                return data.OrderBy(a => a.Id);
            }

            string orderQuery = OrderQueryBuilder.CreateOrderQuery<AuditModel>(orderByQueryString);

            return data.OrderBy(orderQuery);
        }


    }
}
