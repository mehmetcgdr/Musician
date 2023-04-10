using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Musician.Business.Abstract;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Models.ViewModels.AccountModels;

namespace Musician.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICardService _cardService;
        private readonly ITeacherService _teacherService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICardService cardService, ITeacherService teacherService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cardService = cardService;
            _teacherService = teacherService;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    LastName = registerViewModel.LastName,
                };
                var result = await _userManager.CreateAsync(user,registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");

                }
            }

            return View();
        }
    }
}
