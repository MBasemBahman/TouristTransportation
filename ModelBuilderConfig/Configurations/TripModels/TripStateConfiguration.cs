using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.TripModels;

namespace ModelBuilderConfig.Configurations.TripModels
{
    public class TripStateConfiguration : IEntityTypeConfiguration<TripState>
    {
        public void Configure(EntityTypeBuilder<TripState> builder)
        {
            foreach (TripStateEnum value in Enum.GetValues(typeof(TripStateEnum)))
            {
                _ = builder.HasData(new TripState
                {
                    Id = (int)value,
                    Name = value.ToString()
                });
            }
        }
    }

    public class TripStateLangConfiguration : IEntityTypeConfiguration<TripStateLang>
    {
        public void Configure(EntityTypeBuilder<TripStateLang> builder)
        {
            foreach (LanguageEnum language in Enum.GetValues(typeof(LanguageEnum)))
            {
                foreach (TripStateEnum value in Enum.GetValues(typeof(TripStateEnum)))
                {
                    _ = builder.HasData(new TripStateLang
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
