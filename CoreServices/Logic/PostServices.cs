using Entities.CoreServicesModels.PostModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.DBModels.PostModels;
using Entities.DBModels.MainDataModels;
using Entities.EnumData;
using Microsoft.AspNetCore.Http;

namespace CoreServices.Logic
{
    public class PostServices
    {
        private readonly RepositoryManager _repository;

        public PostServices(RepositoryManager repository)
        {
            _repository = repository;
        }

        #region Post Services

        public IQueryable<PostModel> GetPosts(
            PostParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.Post
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new PostModel
                              {
                                  Id = a.Id,
                                  Fk_Account = a.Fk_Account,
                                  Content = a.Content,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<PostModel>> GetPostsPaged(
            PostParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<PostModel>.ToPagedList(GetPosts(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<PostModel>> GetPostsPaged(
          IQueryable<PostModel> data,
         PostParameters parameters)
        {
            return await PagedList<PostModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<Post> FindPostById(int id, bool trackChanges)
        {
            return await _repository.Post.FindById(id, trackChanges);
        }
        
        public PostModel GetPostById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetPosts(new PostParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreatePost(Post entity)
        {
            _repository.Post.Create(entity);
        }

        public int GetPostsCount()
        {
            return _repository.Post.Count();
        }

        public async Task DeletePost(int id)
        {
            Post account = await _repository.Post.FindById(id, trackChanges: false);

            _repository.Post.Delete(account);
        }

        #endregion
        
        #region Post Attachment Services

        public IQueryable<PostAttachmentModel> GetPostAttachments(
            PostAttachmentParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.PostAttachment
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new PostAttachmentModel
                              {
                                  Id = a.Id,
                                  Fk_Post = a.Fk_Post,
                                  Post = new PostModel
                                  {
                                      Content = a.Post.Content,
                                  },
                                  AttachmentUrl = a.AttachmentUrl,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<PostAttachmentModel>> GetPostAttachmentsPaged(
            PostAttachmentParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<PostAttachmentModel>.ToPagedList(GetPostAttachments(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<PostAttachmentModel>> GetPostAttachmentsPaged(
          IQueryable<PostAttachmentModel> data,
         PostAttachmentParameters parameters)
        {
            return await PagedList<PostAttachmentModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PostAttachment> FindPostAttachmentById(int id, bool trackChanges)
        {
            return await _repository.PostAttachment.FindById(id, trackChanges);
        }
        
        public PostAttachmentModel GetPostAttachmentById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetPostAttachments(new PostAttachmentParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreatePostAttachment(PostAttachment entity)
        {
            _repository.PostAttachment.Create(entity);
        }

        public int GetPostAttachmentsCount()
        {
            return _repository.PostAttachment.Count();
        }

        public async Task DeletePostAttachment(int id)
        {
            PostAttachment account = await _repository.PostAttachment.FindById(id, trackChanges: false);

            _repository.PostAttachment.Delete(account);
        }

        #endregion
        
        #region PostReaction Services

        public IQueryable<PostReactionModel> GetPostReactions(
            PostReactionParameters parameters, DBModelsEnum.LanguageEnum? language)
        {
            return _repository.PostReaction
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new PostReactionModel
                              {
                                  Id = a.Id,
                                  Fk_Post = a.Fk_Post,
                                  Post = new PostModel
                                  {
                                      Content = a.Post.Content,
                                  },
                                  Fk_Account = a.Fk_Account,
                                  CreatedAt = a.CreatedAt,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<PostReactionModel>> GetPostReactionsPaged(
            PostReactionParameters parameters , DBModelsEnum.LanguageEnum? language)
        {
            return await PagedList<PostReactionModel>.ToPagedList(GetPostReactions(parameters, language), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<PostReactionModel>> GetPostReactionsPaged(
          IQueryable<PostReactionModel> data,
         PostReactionParameters parameters)
        {
            return await PagedList<PostReactionModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PostReaction> FindPostReactionById(int id, bool trackChanges)
        {
            return await _repository.PostReaction.FindById(id, trackChanges);
        }
        
        public PostReactionModel GetPostReactionById(int id, DBModelsEnum.LanguageEnum? language)
        {
            return GetPostReactions(new PostReactionParameters { Id = id }, language).SingleOrDefault();
        }
        

        public void CreatePostReaction(PostReaction entity)
        {
            _repository.PostReaction.Create(entity);
        }

        public int GetPostReactionsCount()
        {
            return _repository.PostReaction.Count();
        }

        public async Task DeletePostReaction(int id)
        {
            PostReaction account = await _repository.PostReaction.FindById(id, trackChanges: false);

            _repository.PostReaction.Delete(account);
        }

        #endregion
    }
}
