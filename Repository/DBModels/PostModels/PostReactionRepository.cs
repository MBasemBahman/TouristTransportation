using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;

namespace Repository.DBModels.PostModels
{
    public class PostReactionRepository : RepositoryBase<PostReaction>
    {
        public PostReactionRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<PostReaction> FindAll(PostReactionParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Post,
                       parameters.Fk_Account);

        }

        public async Task<PostReaction> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges).SingleOrDefaultAsync();
        }

        public new void Create(PostReaction entity)
        {
            base.Create(entity);
        }
    }

    public static class PostReactionRepositoryExtension
    {
        public static IQueryable<PostReaction> Filter(
            this IQueryable<PostReaction> accounts,
            int id,
            int fk_Post,
            int fk_Account)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Post == 0 || a.Fk_Post == fk_Post) &&
                                       (fk_Account == 0 || a.Fk_Account == fk_Account) );
        }
    }
}
