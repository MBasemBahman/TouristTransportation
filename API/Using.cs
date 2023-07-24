global using API.ActionFilters;
global using API.Controllers;
global using API.Utility;
global using AutoMapper;
global using BaseDB;
global using Contracts;
global using Contracts.Constants;
global using Contracts.Extensions;
global using Contracts.Logger;
global using CoreServices;
global using Entities;
global using Entities.AuthenticationModels;
global using Entities.RequestFeatures;
global using Entities.ResponseFeatures;
global using Entities.TenantModels;
global using LoggerService;
global using Microsoft.AspNetCore.Localization;
global using Microsoft.AspNetCore.Mvc;
global using Microsoft.AspNetCore.Mvc.Controllers;
global using Microsoft.AspNetCore.Mvc.Filters;
global using Microsoft.AspNetCore.Server.Kestrel.Core;
global using Microsoft.EntityFrameworkCore;
global using Microsoft.Extensions.Options;
global using Microsoft.OpenApi.Any;
global using Microsoft.OpenApi.Models;
global using Repository;
global using Services;
global using System.Globalization;
global using System.Linq.Dynamic.Core;
global using System.Reflection;
global using TenantConfiguration;
global using static Entities.EnumData.DBModelsEnum;
global using static TenantConfiguration.TenantData;





