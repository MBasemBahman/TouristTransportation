using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.PostModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.UserModels;
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
            PostParameters parameters)
        {
            return _repository.Post
                              .FindAll(parameters, trackChanges: false)
                              .Select(a => new PostModel
                              {
                                  Id = a.Id,
                                  Fk_Account = a.Fk_Account,
                                  Account = new AccountModel
                                  {
                                      ImageUrl = !string.IsNullOrEmpty(a.Account.ImageUrl) ? a.Account.StorageUrl + a.Account.ImageUrl : "/userImg.png",
                                      User  = new UserModel
                                      {
                                          Name = a.Account.User.Name
                                      }
                                  },
                                  Content = a.Content,
                                  AttachmentsCount = a.PostAttachments.Count,
                                  ReactionCount = a.PostReactions.Count,
                                  IReact = a.PostReactions.Any(b => b.Fk_Account == parameters.Fk_AccountForReaction),
                                  PostAttachments = parameters.IncludeAttachments == true ? a.PostAttachments
                                      .Select(b => new PostAttachmentModel
                                      {
                                          FileName = b.FileName,
                                          FileType = b.FileType,
                                          FileUrl = b.StorageUrl + b.FileUrl,
                                          FileLength = b.FileLength,
                                      }).ToList() : null,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<PostModel>> GetPostsPaged(
            PostParameters parameters)
        {
            return await PagedList<PostModel>.ToPagedList(GetPosts(parameters), parameters.PageNumber, parameters.PageSize);
        }

        public async Task<PagedList<PostModel>> GetPostsPaged(
          IQueryable<PostModel> data,
         PostParameters parameters)
        {
            return await PagedList<PostModel>.ToPagedList(data, parameters.PageNumber, parameters.PageSize);
        }
        
        public async Task<string> UploadPostAttachment(string rootPath, IFormFile file)
        {
            FileUploader uploader = new(rootPath);
            return await uploader.UploadFile(file, "Upload/PostAttachment");
        }

        public async Task<Post> FindPostById(int id, bool trackChanges)
        {
            return await _repository.Post.FindById(id, trackChanges);
        }
        
        public PostModel GetPostById(int id)
        {
            return GetPosts(new PostParameters { Id = id }).SingleOrDefault();
        }
        

        public void AddPost(Post entity)
        {
            _repository.Post.Create(entity);
        }

        public int GetPostsCount()
        {
            return _repository.Post.Count();
        }

        public async Task DeletePost(int id)
        {
            Post post = await _repository.Post.FindById(id, trackChanges: false);

            _repository.Post.Delete(post);
        }
        
        public void DeletePost(Post post)
        {
            _repository.Post.Delete(post);
        }

        #endregion
        
        #region Post Attachment Services

        public IQueryable<PostAttachmentModel> GetPostAttachments(
            PostAttachmentParameters parameters)
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
                                  FileUrl = a.StorageUrl + a.FileUrl,
                                  FileLength = a.FileLength,
                                  FileName = a.FileName,
                                  FileType = a.FileType,
                                  CreatedAt = a.CreatedAt,
                                  CreatedBy = a.CreatedBy,
                                  LastModifiedAt = a.LastModifiedAt,
                                  LastModifiedBy = a.LastModifiedBy,
                              })
                              .Search(parameters.SearchColumns, parameters.SearchTerm)
                              .Sort(parameters.OrderBy);
        }

        public async Task<PagedList<PostAttachmentModel>> GetPostAttachmentsPaged(PostAttachmentParameters parameters)
        {
            return await PagedList<PostAttachmentModel>.ToPagedList(GetPostAttachments(parameters), parameters.PageNumber, parameters.PageSize);
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
        
        public PostAttachmentModel GetPostAttachmentById(int id)
        {
            return GetPostAttachments(new PostAttachmentParameters { Id = id }).SingleOrDefault();
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
        
        public async Task DeletePostAttachment(int id, int fk_PostAccount, int fk_Account)
        {
            PostAttachment postAttachment = await _repository.PostAttachment.FindById(id, trackChanges: false);

            if (fk_PostAccount == fk_Account)
            {
                _repository.PostAttachment.Delete(postAttachment);
            }
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

        public  void DeletePostReaction(int fk_Post,int fk_Account)
        {
            PostReaction postReaction =  _repository.PostReaction.FindAll(new PostReactionParameters
            {
                Fk_Account = fk_Account,
                Fk_Post = fk_Post
            }, trackChanges: false).FirstOrDefault();

            _repository.PostReaction.Delete(postReaction);
        }

        #endregion
    }
}
