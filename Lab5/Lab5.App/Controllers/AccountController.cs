using System.Threading.Tasks;
using System.Security.Claims;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;

using Auth0.AspNetCore.Authentication;

using Lab5.App.Services;
using Lab5.App.Models;

public class AccountController(Auth0UserService auth0UserService) : Controller
{
    private readonly Auth0UserService _auth0UserService = auth0UserService;

    [HttpGet]
    public IActionResult Register() =>
        User.Identity != null && User.Identity.IsAuthenticated
            ? RedirectToAction("Profile", "Account")
            : View();

    [HttpPost]
    public async Task<IActionResult> Register(RegistrationInfoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            await _auth0UserService.CreateUserAsync(model);
            return RedirectToAction("Index", "Home");
        }
        catch (Exception error)
        {
            ModelState.AddModelError(string.Empty, error.Message);
            return View(model);
        }
    }

    // public async Task Login(string returnUrl = "/")
    // {
    //     var authenticationProperties = new LoginAuthenticationPropertiesBuilder()
    //       // Indicate here where Auth0 should redirect the user after a login.
    //       // Note that the resulting absolute Uri must be added to the
    //       // **Allowed Callback URLs** settings for the app.
    //       .WithRedirectUri(returnUrl)
    //       .Build();
    //
    //     await HttpContext.ChallengeAsync(
    //       Auth0Constants.AuthenticationScheme,
    //       authenticationProperties
    //     );
    // }

    [HttpGet]
    public IActionResult Login() =>
        User.Identity != null && User.Identity.IsAuthenticated
            ? RedirectToAction("Profile", "Account")
            : View();

    [HttpPost]
    public async Task<IActionResult> Login(LoginInfoViewModel model)
    {
        if (!ModelState.IsValid)
            return View(model);

        try
        {
            UserProfileViewModel userProfile = await _auth0UserService.GetUser(model);
            List<Claim> claims =
            [
                new Claim(ClaimTypes.NameIdentifier, userProfile.Email),
                new Claim(ClaimTypes.Name, userProfile.FullName),
                new Claim(ClaimTypes.Email, userProfile.Email),
                // new Claim("ProfileImage", userProfile.ProfileImage),
                new Claim(ClaimTypes.MobilePhone, userProfile.PhoneNumber),
                new Claim("Username", userProfile.Username)
            ];

            ClaimsIdentity claimsIdentity = new(claims, "AuthScheme");
            ClaimsPrincipal claimsPrincipal = new(claimsIdentity);

            await HttpContext.SignInAsync("AuthScheme", claimsPrincipal);

            return RedirectToAction("Profile", "Account");
        }
        catch (Exception error)
        {
            ModelState.AddModelError(string.Empty, $"Error authenticating user: {error.Message}");
            return View(model);
        }
    }

    // [Authorize]
    // public IActionResult Profile()
    // {
    //     ViewBag.Name = User.Identity.Name;
    //
    //     ViewBag.EmailAddress = User.Claims
    //         .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value;
    //
    //     // return View(new
    //     // {
    //     //     Name = User.Identity.Name,
    //     //     EmailAddress = User.Claims
    //     //     .FirstOrDefault(c => c.Type == ClaimTypes.Email)?.Value,
    //     //     ProfileImage = User.Claims
    //     //     .FirstOrDefault(c => c.Type == "picture")?.Value
    //     // });
    //     return View();
    // }
    [Authorize]
    public IActionResult Profile()
    {
        string alternativeValue = "N/A";
        ClaimsPrincipal user = HttpContext.User;

        UserProfileViewModel profileViewModel = new()
        {
            Email = user.FindFirst(ClaimTypes.Email)?.Value ?? alternativeValue,
            FullName = user.FindFirst(ClaimTypes.Name)?.Value ?? alternativeValue,
            PhoneNumber = user.FindFirst(ClaimTypes.MobilePhone)?.Value ?? alternativeValue,
            // ProfileImage = user.FindFirst("ProfileImage")?.Value ?? alternativeValue,
            Username = user.FindFirst("Username")?.Value ?? alternativeValue
        };

        return View(profileViewModel);
    }

    // [Authorize]
    // public async Task Logout()
    // {
    //     var authenticationProperties = new LogoutAuthenticationPropertiesBuilder()
    //       // Indicate here where Auth0 should redirect the user after a logout.
    //       // Note that the resulting absolute Uri must be added to the
    //       // **Allowed Logout URLs** settings for the app.
    //       .WithRedirectUri(Url.Action("Index", "Home"))
    //       .Build();
    //
    //     // Logout from Auth0
    //     await HttpContext.SignOutAsync(
    //       Auth0Constants.AuthenticationScheme,
    //       authenticationProperties
    //     );
    //     // Logout from the application
    //     await HttpContext.SignOutAsync(
    //       CookieAuthenticationDefaults.AuthenticationScheme
    //     );
    // }

    // [HttpPost]
    // [HttpPost]
    [Authorize]
    public async Task<IActionResult> Logout()
    {
        await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }
}
