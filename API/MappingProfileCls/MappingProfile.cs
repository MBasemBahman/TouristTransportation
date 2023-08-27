using API.Areas.AccountArea.Models;
using API.Areas.CarArea.Models;
using API.Areas.CompanyTripArea.Models;
using API.Areas.HotelArea.Models;
using API.Areas.MainDataArea.Models;
using API.Areas.PostArea.Models;
using API.Areas.TripArea.Models;
using API.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CarModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.HotelModels;
using Entities.CoreServicesModels.MainDataModels;
using Entities.CoreServicesModels.PostModels;
using Entities.CoreServicesModels.TripModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.HotelModels;
using Entities.DBModels.PostModels;
using Entities.DBModels.TripModels;

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

            #region Post Reaction Models
            _ = CreateMap<PostReactionModel, PostReactionDto>();

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
            
            #region MainDataModels

            _ = CreateMap<CurrencyModel, CurrencyDto>();
            _ = CreateMap<CountryModel, CountryDto>();
            _ = CreateMap<AreaModel, AreaDto>();

            #endregion

            #region User Models

            _ = CreateMap<UserAuthenticatedDto, UserDto>();

            #endregion
            
            #region CompanyTripModels

            #region CompanyTripModels

            _ = CreateMap<CompanyTripModel, CompanyTripDto>();
            _ = CreateMap<CompanyTripStateModel, CompanyTripStateDto>();
            _ = CreateMap<CompanyTripBookingStateModel, CompanyTripBookingStateDto>();
            _ = CreateMap<CompanyTripCreateOrEditDto, CompanyTrip>();
            _ = CreateMap<CompanyTrip, CompanyTripCreateOrEditDto>();

            #endregion

            #region CompanyTripBooking
            _ = CreateMap<CompanyTripBookingModel, CompanyTripBookingDto>();
            _ = CreateMap<CompanyTripBookingCreateModel, CompanyTripBooking>();
            _ = CreateMap<CompanyTripBookingEditModel, CompanyTripBooking>();
            #endregion

            #region CompanyTripAttachment Models

            _ = CreateMap<CompanyTripAttachment, CompanyTripAttachmentDto>().ReverseMap();
            _ = CreateMap<CompanyTripAttachmentModel, CompanyTripAttachmentDto>().ReverseMap();

            #endregion

            #endregion
            
            #region TripModels

            #region Trip

            _ = CreateMap<TripModel, TripDto>();
            _ = CreateMap<TripEditDto, Trip>();
            _ = CreateMap<TripCreateDto,Trip>();

            #endregion

            #region TripState
            _ = CreateMap<TripStateModel, TripStateDto>();
            #endregion

            #region TripHistory
            _ = CreateMap<TripHistoryModel, TripHistoryDto>();
            #endregion


            #region TripLocation

            _ = CreateMap<TripLocationModel, TripLocationDto>();
            _ = CreateMap<TripLocationCreateDto, TripLocation>();

            #endregion

            #region TripPoint

            _ = CreateMap<TripPointModel, TripPointDto>();
            _ = CreateMap<TripPointEditDto, TripPoint>();
            _ = CreateMap<TripPointCreateDto, TripPoint>();

            #endregion
            #endregion

            #region AccountModels

            #region AccountModels

            _ = CreateMap<AccountModel, AccountDto>();

            #endregion

            #endregion
            
            #region CarModels

            #region CarClassModels

            _ = CreateMap<CarClassModel, CarClassDto>();

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
