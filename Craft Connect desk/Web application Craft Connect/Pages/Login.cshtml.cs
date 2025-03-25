using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;
using WebApplicationCraftConnect.Models;
using DataAccessLibrary;
using BusinessLayer.Models;
using DocumentFormat.OpenXml.Drawing.Diagrams;
using BusinessLayer.Services;
using BusinessLayer.Interfaces;

namespace WebApplicationCraftConnect.Pages
{
    public class LoginModel : PageModel
    {
        [BindProperty]

        public LoginDTO loginDTO { get; set; }
       

        private readonly IAccountRepository repo;
        private readonly IAccountService accountService;

        public LoginModel()
        {
            repo = new AccountRepository();
            accountService = new AccountService(repo);
            loginDTO = new LoginDTO();
        }
        public IActionResult OnGet()
        {
            if (User.Identity.IsAuthenticated)
            {
                return RedirectToPage("/Homepage"); // Redirect to the home page or any other page
            }

            if (Request.Cookies.ContainsKey(nameof(loginDTO.Username)))
            {
                loginDTO.Username = Request.Cookies[nameof(loginDTO.Username)];
            }
            return Page();
        }

      
        public IActionResult OnPost()   // because you're getting information from the form
        {
            if (ModelState.IsValid)
            {
                try
                {
                    // Retrieve the stored hashed password
                    string storedHash = accountService.GetHashedPwByUsername(loginDTO.Username);

                    // Authenticate user
                    User authenticateUser = accountService.AuthenticateUser(loginDTO.Username, storedHash);
                    Admin authenticateAdmin = accountService.AuthenticateAdmin(loginDTO.Username, storedHash);

                    // Verify the password
                    if (accountService.VerifyPassword(loginDTO.Password, storedHash))
                    {
                        if (loginDTO.IsRememberMe)
                        {
                            CookieOptions cookieOptions = new CookieOptions
                            {
                                Expires = DateTime.Now.AddDays(1)
                            };
                            Response.Cookies.Append(nameof(loginDTO.Username), loginDTO.Username, cookieOptions);
                        }
                        HttpContext.Session.SetString(nameof(loginDTO.Username), loginDTO.Username);

                        if (authenticateUser != null)
                        {
                            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, authenticateUser.Username),
                        new Claim(ClaimTypes.Name, authenticateUser.Username),
                        new Claim(ClaimTypes.Role, UserTypes.customer.ToString()),
                        new Claim("UserId", authenticateUser.UserId.ToString())
                    };

                            var identity = new ClaimsIdentity(claims, "custom_authentication");
                            var principal = new ClaimsPrincipal(identity);
                            HttpContext.SignInAsync(principal);
                            return new RedirectToPageResult("/Homepage");
                        }

                        if (authenticateAdmin != null)
                        {
                            var claims = new List<Claim>
                    {
                        new Claim(ClaimTypes.NameIdentifier, authenticateAdmin.Username),
                        new Claim(ClaimTypes.Name, authenticateAdmin.Username),
                        new Claim(ClaimTypes.Role, UserTypes.admin.ToString()),
                        new Claim("AdminId", authenticateAdmin.AdminId.ToString())
                    };

                            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                            HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity));
                            return new RedirectToPageResult("/Homepage");
                        }
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Invalid username or password.");
                        return Page();
                    }
                }
                catch (DatabaseExceptionHandler dbEx)
                {
                    // Log the detailed SQL exception
                    // e.g., _logger.LogError(dbEx, "Database error occurred while retrieving hashed password.");
                    ModelState.AddModelError(string.Empty, "A database error occurred. Please try again later.");
                    return Page();
                }
                catch (Exception ex)
                {
                    // Log the general exception
                    // e.g., _logger.LogError(ex, "An error occurred while retrieving hashed password.");
                    ModelState.AddModelError(string.Empty, "An error occurred. Please try again later.");
                    return Page();
                }
            }

            // If ModelState is not valid, return the page with validation errors
            return Page();
        }

    }
}
