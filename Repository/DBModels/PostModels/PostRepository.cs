using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;

namespace Repository.DBModels.PostModels
{
    public class PostRepository : RepositoryBase<Post>
    {
        public PostRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<Post> FindAll(PostParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Account);

        }

        public async Task<Post> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(Post entity)
        {
            base.Create(entity);
        }
    }

    public static class PostRepositoryExtension
    {
        public static IQueryable<Post> Filter(
            this IQueryable<Post> accounts,
            int id,
            int fk_Account)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Account == 0 || a.Fk_Account == fk_Account));
        }
    }
}
