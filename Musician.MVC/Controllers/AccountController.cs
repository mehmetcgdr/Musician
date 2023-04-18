using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Musician.Business.Abstract;
using Musician.Core;
using Musician.Entity.Concrete;
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
        private readonly INotyfService _notyfService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICardService cardService, ITeacherService teacherService, INotyfService notyfService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cardService = cardService;
            _teacherService = teacherService;
            _notyfService = notyfService;
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

                    await _userManager.AddToRoleAsync(user, "Teacher");
                    Teacher teacher = new Teacher
                    {
                        UserId = user.Id,
                        UserName = registerViewModel.UserName,
                        FirstName = registerViewModel.FirstName,
                        LastName = registerViewModel.LastName,
                        Url = Jobs.GetUrl($"{user.UserName}"),
                        CreatedDate = DateTime.Now,
                        Image=new Image
                        {
                            UserId=user.Id
                        }
                    };
                    await _teacherService.CreateAsync(teacher);

                    _notyfService.Success("Kaydın başarıyla oluşturuldu, İyi dersler :)");
                    return RedirectToAction("Index", "Home");
                }
                else
                {
                        if (registerViewModel.UserName.Contains($"{User.Identity.Name}"))
                             {
                            _notyfService.Error("Böyle bir kullanıcı adı varmış, değiştirmen gerekiyor :(");
                             }
                    else
                    {
                        _notyfService.Error("Bilgilerini yanlış girdin sanırım,kontrol eder misin? :(");
                    }
                    
                }
                return View(registerViewModel); 
            }
            return View("Index"); 
        }

        [HttpGet]
        public IActionResult Login(string returnUrl = null)
        {
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }
        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = await _userManager.FindByNameAsync(loginViewModel.UserName);
                if (user == null)
                {
                    ModelState.AddModelError("", "Kullanıcı bilgileri hatalı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    return Redirect(loginViewModel.ReturnUrl ?? "/");
                }
                ModelState.AddModelError("", "Kullanıcı adı ya da parola hatalı!");
            }
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Manage(string id)
        {
            string name = id;
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            User user = await _userManager.FindByNameAsync(name);
            if (user == null)
            {
                return NotFound();
            }


            return View();
        }
    
    
    }
}
