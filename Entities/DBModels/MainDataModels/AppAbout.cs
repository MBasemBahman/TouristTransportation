using Entities.EnumData;

namespace Entities.DBModels.MainDataModels
{
    public class AppAbout : AuditEntity
    {
        [DisplayName(nameof(AboutCompany))]
        [DataType(DataType.MultilineText)]
        public string AboutCompany { get; set; }

        [DisplayName(nameof(AboutApp))]
        [DataType(DataType.MultilineText)]
        public string AboutApp { get; set; }

        [DisplayName(nameof(TermsAndConditions))]
        [DataType(DataType.MultilineText)]
        public string TermsAndConditions { get; set; }

        [DisplayName(nameof(QuestionsAndAnswer))]
        [DataType(DataType.MultilineText)]
        public string QuestionsAndAnswer { get; set; }

        [DisplayName(nameof(Phone))]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string Phone { get; set; }

        [DisplayName(nameof(WhatsApp))]
        [DataType(DataType.PhoneNumber)]
        [Phone]
        public string WhatsApp { get; set; }

        [DisplayName(nameof(EmailAddress))]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string EmailAddress { get; set; }

        [DisplayName(nameof(TwitterUrl))]
        [DataType(DataType.Url)]
        [Url]
        public string TwitterUrl { get; set; }

        [DisplayName(nameof(FacebookUrl))]
        [DataType(DataType.Url)]
        [Url]
        public string FacebookUrl { get; set; }

        [DisplayName(nameof(InstagramUrl))]
        [DataType(DataType.Url)]
        [Url]
        public string InstagramUrl { get; set; }

        [DisplayName(nameof(SnapChatUrl))]
        [DataType(DataType.Url)]
        [Url]
        public string SnapChatUrl { get; set; }

        [DisplayName(nameof(TiktokUrl))]
        [DataType(DataType.Url)]
        [Url]
        public string TiktokUrl { get; set; }

        [DisplayName(nameof(YoutubeUrl))]
        [DataType(DataType.Url)]
        [Url]
        public string YoutubeUrl { get; set; }

        public List<AppAboutLang> AppAboutLangs { get; set; }
    }

    public class AppAboutLang : LangEntity<AppAbout>
    {
        [DisplayName(nameof(AboutCompany))]
        [DataType(DataType.MultilineText)]
        public string AboutCompany { get; set; }

        [DisplayName(nameof(AboutApp))]
        [DataType(DataType.MultilineText)]
        public string AboutApp { get; set; }

        [DisplayName(nameof(TermsAndConditions))]
        [DataType(DataType.MultilineText)]
        public string TermsAndConditions { get; set; }

        [DisplayName(nameof(QuestionsAndAnswer))]
        [DataType(DataType.MultilineText)]
        public string QuestionsAndAnswer { get; set; }

        [DisplayName(nameof(Language))]
        public DBModelsEnum.LanguageEnum Language { get; set; }
    }
}
