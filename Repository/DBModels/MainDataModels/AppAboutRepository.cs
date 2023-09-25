using Entities.DBModels.MainDataModels;
using Entities.RequestFeatures;


namespace Repository.DBModels.MainDataModels
{
    public class AppAboutRepository : RepositoryBase<AppAbout>
    {
        public AppAboutRepository(BaseContext context) : base(context)
        {
        }

        public IQueryable<AppAbout> FindAll(RequestParameters parameters, bool trackChanges)
        {
            return FindByCondition(a => true, trackChanges)
                   .Filter(parameters.Id);
        }

        public async Task<AppAbout> FindById(int id, bool trackChanges)
        {
            return await FindByCondition(a => a.Id == id, trackChanges)
                        .Include(a => a.AppAboutLangs)
                        .FirstOrDefaultAsync();
        }

        public async Task<AppAbout> Find(bool trackChanges)
        {
            return await FindByCondition(a => true, trackChanges)
                        .Include(a => a.AppAboutLangs)
                        .FirstOrDefaultAsync();
        }

        public new void Create(AppAbout entity)
        { 
            entity.AppAboutLangs ??= new List<AppAboutLang>();

            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                if (entity.AppAboutLangs.All(b => b.Language != language))
                {
                    entity.AppAboutLangs.Add(new AppAboutLang
                    {
                        AboutCompany = entity.AboutCompany,
                        AboutApp = entity.AboutApp,
                        TermsAndConditions = entity.TermsAndConditions,
                        QuestionsAndAnswer = entity.QuestionsAndAnswer,
                        Language = language
                    });
                }
            }
            base.Create(entity);
        }

        public new void Delete(AppAbout entity)
        {
            base.Delete(entity);
        }


        public new int Count()
        {
            return base.Count();
        }
    }

    public static class AppAboutRepositoryExtension
    {
        public static IQueryable<AppAbout> Filter(this IQueryable<AppAbout> AppAbouts, int id)
        {
            return AppAbouts.Where(a => id == 0 || a.Id == id);
        }

    }
}
