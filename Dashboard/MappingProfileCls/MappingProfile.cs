﻿#region Dto Models
using Dashboard.Areas.DashboardAdministration.Models;
using Dashboard.Areas.LogEntity.Models;
using Dashboard.Areas.UserEntity.Models;
using Dashboard.Areas.AuditEntity.Models;
using Dashboard.Areas.MainDataEntity.Models;
#endregion

#region Core Service Models
using Entities.CoreServicesModels.LogModels;
using Entities.CoreServicesModels.UserModels;
using Entities.CoreServicesModels.AuditModels;
using Entities.CoreServicesModels.MainDataModels;
#endregion

#region DB Models
using Entities.DBModels.DashboardAdministrationModels;
using Entities.DBModels.MainDataModels;
#endregion

using Dashboard.Areas.AccountEntity.Models;
using Dashboard.Areas.CompanyTripEntity.Models;
using Dashboard.Areas.PostEntity.Models;
using Entities.CoreServicesModels.AccountModels;
using Entities.CoreServicesModels.CompanyTripModels;
using Entities.CoreServicesModels.PostModels;
using Entities.DBModels.AccountModels;
using Entities.DBModels.CompanyTripModels;
using Entities.DBModels.PostModels;
using Entities.RequestFeatures;

namespace Dashboard.MappingProfileCls
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            MapperConfiguration configuration = new(cfg =>
            {
                cfg.AllowNullCollections = false;
            });

            CreateMap<DateTime, string>().ConvertUsing(new DateTimeTypeConverter());
            CreateMap<DateTime?, string>().ConvertUsing(new DateTimeNullableTypeConverter());
            CreateMap<TimeSpan, string>().ConvertUsing(new TimeSpanTypeConverter());
            CreateMap<TimeSpan?, string>().ConvertUsing(new TimeSpanNullableTypeConverter());
            CreateMap<string, List<string>>().ConvertUsing(new ListOfStringTypeConverter());


            _ = CreateMap<DtParameters, RequestParameters>()
                .ForMember(dest => dest.SearchTerm, opt => opt.MapFrom(src => src.Search == null ? "" : src.Search.Value))
                .ForMember(dest => dest.OrderBy, opt =>
                                   opt.MapFrom(src => src.Order == null ?
                                                      "" :
                                                      (src.Order[0].Dir.ToString().ToLower() == "asc" ?
                                                       src.Columns[src.Order[0].Column].Data :
                                                       (src.Columns[src.Order[0].Column].Data.Contains(',') ?
                                                        src.Columns[src.Order[0].Column].Data.Replace(",", " desc,") :
                                                        src.Columns[src.Order[0].Column].Data + " desc"))))
                .ForMember(dest => dest.PageSize, opt => opt.MapFrom(src => src.Length))
                .ForMember(dest => dest.PageNumber, opt => opt.MapFrom(src => src.Length > 0 ? (src.Start / src.Length) + 1 : 0))
                .IncludeAllDerived();

            _ = CreateMap<UserAuthenticatedDto, UserDto>();

            #region Log Models
            _ = CreateMap<LogModel, LogDto>();

            _ = CreateMap<LogFilter, LogParameters>();

            #endregion

            #region User Models

            _ = CreateMap<UserFilter, UserParameters>();

            _ = CreateMap<UserModel, UserDto>();

            _ = CreateMap<User, UserCreateModel>();

            _ = CreateMap<UserCreateModel, User>();

            _ = CreateMap<UserDeviceFilter, UserDeviceParameters>();

            _ = CreateMap<UserDeviceModel, UserDeviceDto>();

            _ = CreateMap<RefreshTokenFilter, RefreshTokenParameters>();

            _ = CreateMap<RefreshTokenModel, RefreshTokenDto>();

            _ = CreateMap<VerificationFilter, VerificationParameters>();

            _ = CreateMap<VerificationModel, Areas.UserEntity.Models.VerificationDto>();

            _ = CreateMap<UserFilter, UserParameters>();

            #endregion

            #region Dashboard Administration Models

            #region Dashboard View
            _ = CreateMap<DashboardViewModel, DashboardViewDto>();

            _ = CreateMap<DashboardView, DashboardViewCreateOrEditModel>();

            _ = CreateMap<DashboardViewLang, DashboardViewLangModel>();

            _ = CreateMap<DashboardViewCreateOrEditModel, DashboardView>();

            _ = CreateMap<DashboardViewLangModel, DashboardViewLang>();
            #endregion

            #region Dashboard Administration Role
            _ = CreateMap<DashboardAdministrationRoleModel, DashboardAdministrationRoleDto>();

            _ = CreateMap<DashboardAdministrationRole, DashboardAdministrationRoleCreateOrEditModel>();

            _ = CreateMap<DashboardAdministrationRoleLang, DashboardAdministrationRoleLangModel>();

            _ = CreateMap<DashboardAdministrationRoleCreateOrEditModel, DashboardAdministrationRole>();

            _ = CreateMap<DashboardAdministrationRoleLangModel, DashboardAdministrationRoleLang>();

            _ = CreateMap<DashboardAdministrationRoleFilter, DashboardAdministrationRoleRequestParameters>();
            #endregion

            #region Dashboard Access Level
            _ = CreateMap<DashboardAccessLevelModel, DashboardAccessLevelDto>();

            _ = CreateMap<DashboardAccessLevel, DashboardAccessLevelCreateOrEditModel>();

            _ = CreateMap<DashboardAccessLevelLang, DashboardAccessLevelLangModel>();

            _ = CreateMap<DashboardAccessLevelCreateOrEditModel, DashboardAccessLevel>();

            _ = CreateMap<DashboardAccessLevelLangModel, DashboardAccessLevelLang>();
            #endregion

            #region Dashboard Administrator
            _ = CreateMap<DashboardAdministrator, DashboardAdministratorCreateOrEditModel>();

            _ = CreateMap<DashboardAdministratorCreateOrEditModel, DashboardAdministrator>();

            _ = CreateMap<DashboardAdministratorModel, DashboardAdministratorDto>();

            _ = CreateMap<DashboardAdministratorFilter, DashboardAdministratorParameters>();
            #endregion
            #endregion

            #region CompanyTrip

            #region CompanyTripState Models
            
            _ = CreateMap<CompanyTripState, CompanyTripStateCreateOrEditModel>();

            _ = CreateMap<CompanyTripStateCreateOrEditModel, CompanyTripState>();

            _ = CreateMap<CompanyTripStateModel, CompanyTripStateDto>();

            _ = CreateMap<CompanyTripStateFilter, CompanyTripStateParameters>();

            _ = CreateMap<CompanyTripStateLang, CompanyTripStateLangModel>();

            _ = CreateMap<CompanyTripStateLangModel, CompanyTripStateLang>();

            #endregion

            #region Post Models

            #region Post
            
            _ = CreateMap<Post, PostCreateOrEditModel>();

            _ = CreateMap<PostCreateOrEditModel, Post>();

            _ = CreateMap<PostModel, PostDto>();

            _ = CreateMap<PostFilter, PostParameters>();

            #endregion
            
            #region PostAttachment
            
            _ = CreateMap<PostAttachment, PostAttachmentCreateOrEditModel>();

            _ = CreateMap<PostAttachmentCreateOrEditModel, PostAttachment>();

            _ = CreateMap<PostAttachmentModel, PostAttachmentDto>();

            _ = CreateMap<PostAttachmentFilter, PostAttachmentParameters>();

            #endregion
            
            #endregion
            
            #region Account Models
            _ = CreateMap<Account, AccountCreateOrEditModel>()
                .ForMember(dest => dest.ImageUrl, opt => opt.MapFrom(src => $"{src.StorageUrl}{src.ImageUrl}"));

            _ = CreateMap<AccountCreateOrEditModel, Account>()
                .ForMember(dest => dest.StorageUrl, opt => opt.Ignore())
                .ForMember(dest => dest.ImageUrl, opt => opt.Ignore());

            _ = CreateMap<AccountModel, AccountDto>();

            _ = CreateMap<AccountFilter, AccountParameters>();
            #endregion

            #region Account State

            _ = CreateMap<AccountState, AccountStateCreateOrEditModel>();

            _ = CreateMap<AccountStateCreateOrEditModel, AccountState>();

            _ = CreateMap<AccountStateModel, AccountStateDto>();

            _ = CreateMap<AccountStateFilter, AccountStateParameters>();

            _ = CreateMap<AccountStateLang, AccountStateLangModel>();

            _ = CreateMap<AccountStateLangModel, AccountStateLang>();

            #endregion

            #region Account Type

            _ = CreateMap<AccountType, AccountTypeCreateOrEditModel>();

            _ = CreateMap<AccountTypeCreateOrEditModel, AccountType>();

            _ = CreateMap<AccountTypeModel, AccountTypeDto>();

            _ = CreateMap<AccountTypeFilter, AccountTypeParameters>();

            _ = CreateMap<AccountTypeLang, AccountTypeLangModel>();

            _ = CreateMap<AccountTypeLangModel, AccountTypeLang>();

            #endregion

            #endregion

            #region Audit Models

            #region Audit

            _ = CreateMap<AuditModel, AuditDto>();

            _ = CreateMap<AuditFilter, AuditParameters>();
            #endregion


            #endregion

            #region Main Data Models

            #region Area

            _ = CreateMap<Area, AreaCreateOrEditModel>();

            _ = CreateMap<AreaCreateOrEditModel, Area>();

            _ = CreateMap<AreaModel, AreaDto>();

            _ = CreateMap<AreaFilter, AreaParameters>();

            _ = CreateMap<AreaLang, AreaLangModel>();

            _ = CreateMap<AreaLangModel, AreaLang>();

            #endregion

            #region Currency

            _ = CreateMap<Currency, CurrencyCreateOrEditModel>();

            _ = CreateMap<CurrencyCreateOrEditModel, Currency>();

            _ = CreateMap<CurrencyModel, CurrencyDto>();

            _ = CreateMap<CurrencyFilter, CurrencyParameters>();

            _ = CreateMap<CurrencyLang, CurrencyLangModel>();

            _ = CreateMap<CurrencyLangModel, CurrencyLang>();

            #endregion

            #region Country

            _ = CreateMap<Country, CountryCreateOrEditModel>();

            _ = CreateMap<CountryCreateOrEditModel, Country>();

            _ = CreateMap<CountryModel, CountryDto>();

            _ = CreateMap<CountryFilter, CountryParameters>();

            _ = CreateMap<CountryLang, CountryLangModel>();

            _ = CreateMap<CountryLangModel, CountryLang>();

            #endregion

            #region Supplier

            _ = CreateMap<Supplier, SupplierCreateOrEditModel>();

            _ = CreateMap<SupplierCreateOrEditModel, Supplier>();

            _ = CreateMap<SupplierModel, SupplierDto>();

            _ = CreateMap<SupplierFilter, SupplierParameters>();

            _ = CreateMap<SupplierLang, SupplierLangModel>();

            _ = CreateMap<SupplierLangModel, SupplierLang>();

            #endregion

            #endregion
        }
    }

    public class DateTimeNullableTypeConverter : ITypeConverter<DateTime?, string>
    {
        public string Convert(DateTime? source, string destination, ResolutionContext context)
        {
            return source == null ? "" : source.Value.AddHours(2).ToString(ApiConstants.DateTimeStringFormat);
        }
    }

    public class DateTimeTypeConverter : ITypeConverter<DateTime, string>
    {
        public string Convert(DateTime source, string destination, ResolutionContext context)
        {
            return source.AddHours(2).ToString(ApiConstants.DateTimeStringFormat);
        }
    }


    public class TimeSpanNullableTypeConverter : ITypeConverter<TimeSpan?, string>
    {
        public string Convert(TimeSpan? source, string destination, ResolutionContext context)
        {
            return source == null ? "" : new DateTime(source.Value.Ticks).ToString(ApiConstants.TimeFormat);
        }
    }

    public class TimeSpanTypeConverter : ITypeConverter<TimeSpan, string>
    {
        public string Convert(TimeSpan source, string destination, ResolutionContext context)
        {
            return new DateTime(source.Ticks).ToString(ApiConstants.TimeFormat);
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
