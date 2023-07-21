global using AutoMapper;
global using Contracts;
global using Contracts.Constants;
global using Contracts.Extensions;
global using CoreServices;
global using Dashboard.ActionFilters;
global using Dashboard.Extensions;
global using Dashboard.Middlewares;
global using Dashboard.Resources;
global using Dashboard.Utility;
global using Entities;
global using Entities.AuthenticationModels;
global using Entities.CoreServicesModels.DashboardAdministrationModels;
global using Entities.DBModels.UserModels;
global using Entities.ResponseFeatures;
global using Entities.ServicesModels;
global using LoggerService;
global using Microsoft.AspNetCore.Localization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Localization;
global using Microsoft.Extensions.Options;
global using Microsoft.IdentityModel.Tokens;
global using Newtonsoft.Json.Converters;
global using NLog;
global using Repository;
global using Services;
global using System.Globalization;
global using System.IdentityModel.Tokens.Jwt;
global using System.Linq.Dynamic.Core;
global using System.Reflection;
global using System.Security.Claims;
global using System.Text;
global using TenantConfiguration;
global using static Entities.EnumData.DashboardModelsEnum;
global using static Entities.EnumData.DBModelsEnum;
global using static TenantConfiguration.TenantData;









