using Entities.DBModels.AccountModels;

namespace ModelBuilderConfig.Configurations.AccountModels
{
    public class AccountStateConfiguration : IEntityTypeConfiguration<AccountState>
    {
        public void Configure(EntityTypeBuilder<AccountState> builder)
        {
            foreach (AccountStateEnum value in Enum.GetValues(typeof(AccountStateEnum)))
            {
                _ = builder.HasData(new AccountState
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class AccountStateLangConfiguration : IEntityTypeConfiguration<AccountStateLang>
    {
        public void Configure(EntityTypeBuilder<AccountStateLang> builder)
        {
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (AccountStateEnum value in Enum.GetValues(typeof(AccountStateEnum)))
                {
                    _ = builder.HasData(new AccountStateLang
                    {
                        Id = (int)value,
                        Fk_Source = (int)value,
                        Name = value.ToString(),
                        Language = language
                    });
                }
            }
        }
    }
}
