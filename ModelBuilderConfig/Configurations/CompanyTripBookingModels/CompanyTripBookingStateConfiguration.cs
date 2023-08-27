using Entities.DBModels.AccountModels;
using Entities.DBModels.CompanyTripModels;

namespace ModelBuilderConfig.Configurations.CompanyTripBookingModels
{
    public class CompanyTripBookingStateConfiguration : IEntityTypeConfiguration<CompanyTripBookingState>
    {
        public void Configure(EntityTypeBuilder<CompanyTripBookingState> builder)
        {
            foreach (CompanyTripBookingStateEnum value in Enum.GetValues(typeof(CompanyTripBookingStateEnum)))
            {
                _ = builder.HasData(new CompanyTripBookingState
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }

        public class CompanyTripBookingStateLangConfiguration : IEntityTypeConfiguration<CompanyTripBookingStateLang>
        {
            public void Configure(EntityTypeBuilder<CompanyTripBookingStateLang> builder)
            {
                int index = 1;
                foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
                {
                    foreach (CompanyTripBookingStateEnum value in Enum.GetValues(typeof(CompanyTripBookingStateEnum)))
                    {
                        _ = builder.HasData(new CompanyTripBookingStateLang
                        {
                            Id = index++,
                            Fk_Source = (int)value,
                            Name = value.ToString(),
                            Language = language
                        });
                    }
                }
            }
        }
    }
}
