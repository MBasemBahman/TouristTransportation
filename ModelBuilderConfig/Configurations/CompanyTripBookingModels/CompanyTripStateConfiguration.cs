using Entities.DBModels.CompanyTripModels;

namespace ModelBuilderConfig.Configurations.CompanyTripBookingModels
{
    public class CompanyTripStateConfiguration : IEntityTypeConfiguration<CompanyTripState>
    {
        public void Configure(EntityTypeBuilder<CompanyTripState> builder)
        {
            foreach (CompanyTripStateEnum value in Enum.GetValues(typeof(CompanyTripStateEnum)))
            {
                _ = builder.HasData(new CompanyTripState
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class CompanyTripStateLangConfiguration : IEntityTypeConfiguration<CompanyTripStateLang>
    {
        public void Configure(EntityTypeBuilder<CompanyTripStateLang> builder)
        {
            int index = 1;
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (CompanyTripStateEnum value in Enum.GetValues(typeof(CompanyTripStateEnum)))
                {
                    _ = builder.HasData(new CompanyTripStateLang
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
