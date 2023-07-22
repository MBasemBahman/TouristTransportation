using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.PostModels;

namespace Repository.DBModels.PostModels
{
    public class PostAttachmentRepository : RepositoryBase<PostAttachment>
    {
        public PostAttachmentRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<PostAttachment> FindAll(PostAttachmentParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id,
                       parameters.Fk_Post);

        }

        public async Task<PostAttachment> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                .SingleOrDefaultAsync();
        }

        public new void Create(PostAttachment entity)
        {
            base.Create(entity);
        }
    }

    public static class PostAttachmentRepositoryExtension
    {
        public static IQueryable<PostAttachment> Filter(
            this IQueryable<PostAttachment> accounts,
            int id,
            int fk_Post)
        {
            return accounts.Where(a => (id == 0 || a.Id == id) &&
                                       (fk_Post == 0 || a.Fk_Post == fk_Post) );
        }
    }
}
