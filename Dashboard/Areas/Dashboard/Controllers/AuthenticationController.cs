﻿using Contracts.Logger;

namespace Dashboard.Areas.Dashboard.Controllers
{
    [Area("Dashboard")]
    [Authorize]
    public class AuthenticationController : Controller
    {
        private readonly ILoggerManager _logger;
        private readonly IMapper _mapper;
        private readonly IAuthenticationManager _authManager;
        private readonly UnitOfWork _unitOfWork;
        private readonly IWebHostEnvironment _environment;

        public AuthenticationController(ILoggerManager logger, IMapper mapper,
        IAuthenticationManager authManager, UnitOfWork unitOfWork, IWebHostEnvironment environment)
        {
            _logger = logger;
            _mapper = mapper;
            _authManager = authManager;
            _unitOfWork = unitOfWork;
            _environment = environment;
        }

        [HttpGet]
        [AllowAnonymous]
        public async Task<IActionResult> Login()
        {
            //VCardManager vCardManager = new(_environment.WebRootPath);

            //var url = vCardManager.SaveContact("MohamedBasem", "Export/vCards", new Contact
            //{
            //    DisplayName = "John Doe",
            //    Person = new Person
            //    {
            //        Name = new Name
            //        {
            //            FirstName = "John",
            //            MiddleName = "William",
            //            LastName = "Doe",
            //            Suffix = "jr."
            //        },

            //        BirthDay = new DateTime(1972, 1, 3),
            //        Spouse = "Jane Doe",
            //        Anniversary = new DateTime(2001, 6, 15)
            //    },

            //    Work = new Work
            //    {
            //        JobTitle = "Facility Manager",
            //        Company = "Does Company"
            //    },

            //    PhoneNumbers = new PhoneNumber[]
            //        {
            //            new PhoneNumber
            //            {
            //                Value = "876-54321",
            //                IsMobile = true
            //            },
            //            new PhoneNumber
            //            {
            //                Value = "123-45678",
            //                IsWork = true,
            //            }
            //        },

            //    EmailAddresses = new string[]
            //        {
            //            "john.doe@internet.com"
            //        }
            //});

            string refreshToken = Request.Cookies[HeadersConstants.SetRefresh];

            try
            {
                if (!string.IsNullOrWhiteSpace(refreshToken))
                {
                    UserAuthenticatedDto auth = await _authManager.Authenticate(refreshToken, IpAddress());

                    RemoveCookies();

                    SetAccount(auth, auth.RefreshTokenResponse.Expires);
                    SetViews(auth.Fk_DashboardAdministrationRole, auth.RefreshTokenResponse.Expires);

                    SetToken(auth.TokenResponse);
                    SetRefresh(auth.RefreshTokenResponse);
                    SetAdminData(auth.Fk_DashboardAdministrator, auth.RefreshTokenResponse.Expires);


                    return Request.Headers.Referer.Any()
                        ? Redirect(Request.Headers.Referer)
                        : RedirectToAction("SetSettings", "Home", new { area = "Dashboard" });
                }
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            RemoveCookies();

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [AllowAnonymous]
        public async Task<IActionResult> Login(UserForAuthenticationDto model)
        {
            try
            {
                UserAuthenticatedDto auth = await _authManager.Authenticate(model, IpAddress());

                RemoveCookies();

                SetAccount(auth, auth.RefreshTokenResponse.Expires);
                SetViews(auth.Fk_DashboardAdministrationRole, auth.RefreshTokenResponse.Expires);

                SetToken(auth.TokenResponse);
                SetRefresh(auth.RefreshTokenResponse);
                SetAdminData(auth.Fk_DashboardAdministrator, auth.RefreshTokenResponse.Expires);

                return RedirectToAction("SetSettings", "Home", new { area = "Dashboard" });
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return View(model);
        }

        public IActionResult ChangePassword()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordDto model)
        {
            try
            {
                UserAuthenticatedDto auth = (UserAuthenticatedDto)Request.HttpContext.Items["User"];

                await _unitOfWork.User.ChangePassword(auth.Id, model);
                await _unitOfWork.Save();

                return RedirectToAction(nameof(Logout));
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return View(model);
        }

        [AllowAnonymous]
        public async Task<IActionResult> Logout()
        {
            try
            {
                string refresh = Request.Cookies[HeadersConstants.SetRefresh];

                if (!string.IsNullOrWhiteSpace(refresh))
                {
                    await _authManager.RevokeToken(refresh, IpAddress());
                }

                RemoveCookies();
            }
            catch (Exception ex)
            {
                ViewData[ViewDataConstants.Error] = _logger.LogError(HttpContext.Request, ex).ErrorMessage;
            }

            return RedirectToAction(nameof(Login));
        }

        // Helper Methods
        private void SetToken(TokenResponse response)
        {
            CookieOptions option = new()
            {
                Expires = DateTime.Parse(response.Expires, CultureInfo.InvariantCulture),
            };
            Response.Cookies.Append(HeadersConstants.AuthorizationToken, response.RefreshToken, option);
        }

        private void SetRefresh(TokenResponse response)
        {
            CookieOptions option = new()
            {
                Expires = DateTime.Parse(response.Expires, CultureInfo.InvariantCulture),
            };
            Response.Cookies.Append(HeadersConstants.SetRefresh, response.RefreshToken, option);
        }

        private void SetAccount(UserAuthenticatedDto auth, string expires)
        {
            CookieOptions option = new()
            {
                Expires = DateTime.Parse(expires, CultureInfo.InvariantCulture),
            };

            Response.Cookies.Append(ViewDataConstants.AccountName, auth.Name, option);
            if (!string.IsNullOrWhiteSpace(auth.EmailAddress))
            {
                Response.Cookies.Append(ViewDataConstants.AccountEmail, auth.EmailAddress, option);
            }
        }

        private void SetViews(int fk_Role, string expires)
        {
            List<int> views = _unitOfWork.DashboardAdministration.GetViewsByRoleId(fk_Role);
            string listString = string.Join(",", views);

            CookieOptions option = new()
            {
                Expires = DateTime.Parse(expires, CultureInfo.InvariantCulture),
            };
            Response.Cookies.Append(ViewDataConstants.Views, listString, option);
        }

        private void SetAdminData(int fk_admin, string expires)
        {
            DashboardAdministratorModel Admin = _unitOfWork.DashboardAdministration
                                                    .GetAdministratorbyId(fk_admin, otherLang: false);


            CookieOptions option = new()
            {
                Expires = DateTime.Parse(expires, CultureInfo.InvariantCulture),
            };
            Response.Cookies.Append(AdminCookiesDataConstants.Role, Admin.Fk_DashboardAdministrationRole.ToString(), option);
        }

        private void RemoveCookies()
        {
            foreach (string cookie in Request.Cookies.Keys)
            {
                Response.Cookies.Delete(cookie);
            }
        }

        private string IpAddress()
        {
            // get source ip address for the current request
            return Request.Headers.ContainsKey("x-Forwarded-For")
                ? (string)Request.Headers["x-Forwarded-For"]
                : HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }
    }
}
