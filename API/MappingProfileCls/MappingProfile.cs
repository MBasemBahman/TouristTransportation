using API.Areas.CompanyTripArea.Models;
using API.Areas.HotelArea.Models;
using API.Areas.PostArea.Models;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.PostModels;

namespace API.MappingProfileCls
{
    public class MappingProfile : Profile
    {
        private readonly AppSettings _appSettings;

        public MappingProfile(IOptions<AppSettings> appSettings)
        {
            _appSettings = appSettings.Value;

            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AllowNullCollections = false;
            });

            CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            CreateMap<DateTime?, string>().ConvertUsing(new DateTimeNullableTypeConverter());
            CreateMap<string, string>().ConvertUsing(new StringTypeConverter());
            CreateMap<TimeSpan, string>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<TimeSpan?, string>().ConvertUsing(new TimeSpanNullableTypeConverter());
            CreateMap<string, List<string>>().ConvertUsing(new ListOfStringTypeConverter());

            #region PostModels

            #region PostModels

            _ = CreateMap<PostModel, PostDto>();
            _ = CreateMap<PostCreateOrEditDto, Post>();
            _ = CreateMap<Post, PostCreateOrEditDto>();

            #endregion

            #region PostAttachment Models

            _ = CreateMap<PostAttachment, PostAttachmentDto>().ReverseMap();
            _ = CreateMap<PostAttachmentModel, PostAttachmentDto>().ReverseMap();

            #endregion

            #endregion

            #region HotelModels

            #region HotelModels

            _ = CreateMap<HotelModel, HotelDto>();
            _ = CreateMap<HotelCreateOrEditDto, Hotel>();
            _ = CreateMap<Hotel, HotelCreateOrEditDto>();

            #endregion

            #region HotelAttachment Models

            _ = CreateMap<HotelAttachment, HotelAttachmentDto>().ReverseMap();
            _ = CreateMap<HotelAttachmentModel, HotelAttachmentDto>().ReverseMap();

            #endregion

            #endregion
            
            #region CompanyTripModels

            #region CompanyTripModels

            _ = CreateMap<CompanyTripModel, CompanyTripDto>();
            _ = CreateMap<CompanyTripCreateOrEditDto, CompanyTrip>();
            _ = CreateMap<CompanyTrip, CompanyTripCreateOrEditDto>();

            #endregion

            #region CompanyTripAttachment Models

            _ = CreateMap<CompanyTripAttachment, CompanyTripAttachmentDto>().ReverseMap();
            _ = CreateMap<CompanyTripAttachmentModel, CompanyTripAttachmentDto>().ReverseMap();

            #endregion

            #endregion
        }

        public class DateTimeNullableTypeConverter : ITypeConverter<DateTime?, string>
        {
            public string Convert(DateTime? source, string destination, ResolutionContext context)
            {
                return source == null ? "" : source.Value.ToString(ApiConstants.DateTimeStringFormat, CultureInfo.InvariantCulture);
            }
        }

        public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
        {
            public string Convert(DateTime source, string destination, ResolutionContext context)
            {
                return source.ToString(ApiConstants.DateTimeStringFormat, CultureInfo.InvariantCulture);
            }
        }

        public class TimeSpanNullableTypeConverter : ITypeConverter<TimeSpan?, string>
        {
            public string Convert(TimeSpan? source, string destination, ResolutionContext context)
            {
                return source == null ? "" : new DateTime(source.Value.Ticks).ToString(ApiConstants.TimeFormat, CultureInfo.InvariantCulture);
            }
        }

        public class TimeSpanTypeConverter : ITypeConverter<TimeSpan, string>
        {
            public string Convert(TimeSpan source, string destination, ResolutionContext context)
            {
                return new DateTime(source.Ticks).ToString(ApiConstants.TimeFormat, CultureInfo.InvariantCulture);
            }
        }

        public class StringTypeConverter : ITypeConverter<string, string>
        {
            public string Convert(string source, string destination, ResolutionContext context)
            {
                if (!string.IsNullOrEmpty(source) && source.StartsWith("http"))
                {
                    source = source.Replace(" ", "%20");

                }

                return source;
            }
        }

        public class ListOfStringTypeConverter : ITypeConverter<string, List<string>>
        {
            public List<string> Convert(string source, List<string> destination, ResolutionContext context)
            {
                return !string.IsNullOrEmpty(source) ? source.Split(',').ToList() : null;
            }
        }
    }
}
