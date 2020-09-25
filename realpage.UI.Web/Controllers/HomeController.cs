using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using realpage.InfraestructureData.Model;
using System.Threading.Tasks;

namespace realpage.UI.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly UserManager<RpUsers> _userManager;
        private readonly SignInManager<RpUsers> _signInManager;
        //private readonly IEmailService _emailService;

        public HomeController(UserManager<RpUsers> userManager,
           SignInManager<RpUsers> signInManager)//,  IEmailService emailService
        {
            _userManager = userManager;
            _signInManager = signInManager;
            //_emailService = emailService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [Authorize]
        public IActionResult WellcomeSalute()
        {
            return View();
        }

        public IActionResult Login()
        {

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            //login functionality
            var user = await _userManager.FindByNameAsync(username);

            if (user != null)
            {
                //sign in
                var signInResult = await _signInManager.PasswordSignInAsync(user, password, false, false);

                if (signInResult.Succeeded)
                {
                    return RedirectToAction("WellcomeSalute");
                }
            }

            return RedirectToAction("Index");
        }

        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(string username, string password)
        {


            var user = new RpUsers
            {
                UserName = username,
                Email = "",
            };

            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {

                var code = await _userManager.GenerateEmailConfirmationTokenAsync(user);

                //var link = Url.Action(nameof(VerifyEmail), "Home", new { userId = user.Id, code }, Request.Scheme, Request.Host.ToString());

                //await _emailService.SendAsync("test@test.com", "email verify", $"<a href=\"{link}\">Verify Email</a>", true);

                return RedirectToAction("EmailVerification");
            }

            return RedirectToAction("Index");
        }


        public async Task<IActionResult> LogOut()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }

        //public async Task<IActionResult> VerifyEmail(string userId, string code)
        //{
        //    var user = await _userManager.FindByIdAsync(userId);

        //    if (user == null) return BadRequest();

        //    var result = await _userManager.ConfirmEmailAsync(user, code);

        //    if (result.Succeeded)
        //    {
        //        return View();
        //    }

        //    return BadRequest();
        //}

        //public IActionResult EmailVerification() => View();

        //public async Task<IActionResult> LogOut()
        //{
        //    await _signInManager.SignOutAsync();
        //    return RedirectToAction("Index");
        //}
    }
}
