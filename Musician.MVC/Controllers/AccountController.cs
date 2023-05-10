using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musician.Business.Abstract;
using Musician.Core;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Models.ViewModels;
using Musician.MVC.Models.ViewModels.AccountModels;
using SQLitePCL;
using System;
using System.Reflection;
using System.Text.Json;
using System.Xml.Linq;
using WeatherCast.Models;

namespace Musician.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly ICardService _cardService;
        private readonly ITeacherService _teacherService;
        private readonly INotyfService _notyfService;
        private readonly IStudentService _studentService;
        private readonly IImageService _imageService;
        private readonly IEnstrumentService _enstrumentService;
        private readonly IRequestService _requestService;

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICardService cardService, ITeacherService teacherService, INotyfService notyfService, IStudentService studentService, IImageService imageService, IEnstrumentService enstrumentService, IRequestService requestService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cardService = cardService;
            _teacherService = teacherService;
            _notyfService = notyfService;
            _studentService = studentService;
            _imageService = imageService;
            _enstrumentService = enstrumentService;
            _requestService = requestService;
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
                    RoleId = EnumRoleId.Teacher,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    Url = Jobs.GetUrl(registerViewModel.UserName),
                    Image = new Image
                    {
                        Url = "genel.png"
                    }
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {

                    await _userManager.AddToRoleAsync(user, "Teacher");
                    Teacher teacher = new Teacher
                    {
                        UserId = user.Id,
                    };
                    await _teacherService.CreateAsync(teacher);

                    _notyfService.Success("Kaydın başarıyla oluşturuldu, İyi dersler :)");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    if (registerViewModel.UserName == ($"{User.Identity.Name}"))
                    {
                        _notyfService.Error("Böyle bir kullanıcı adı varmış, değiştirmen gerekiyor :(");
                    }
                    else
                    {
                        _notyfService.Error("Bilgilerini yanlış girdin sanırım,kontrol eder misin? :(");
                    }

                }

            }
            _notyfService.Error("Bilgilerini eksik ya da yanlış girdin sanırım,kontrol eder misin? :(");
            return View(registerViewModel);
        }
        [HttpGet]
        public IActionResult StudentRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StudentRegister(RegisterViewModel registerViewModel)
        {

            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    CreatedDate = DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    LastName = registerViewModel.LastName,
                    RoleId = EnumRoleId.Student,
                    Url = Jobs.GetUrl(registerViewModel.UserName),
                    Image = new Image
                    {
                        
                        Url = "genel.png",
                    }
                };

                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "Student");
                    Student student = new Student
                    {
                        UserId = user.Id,
                    };
                    await _studentService.CreateAsync(student);

                    _notyfService.Success("Kaydın başarıyla oluşturuldu, İyi dersler :)");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    if (registerViewModel.UserName == ($"{User.Identity.Name}"))
                    {
                        _notyfService.Error("Böyle bir kullanıcı adı varmış, değiştirmen gerekiyor :(");
                    }
                    else
                    {
                        _notyfService.Error("Bilgilerini eksik ya da yanlış girdin sanırım,kontrol eder misin? :(");
                    }

                }

            }
            _notyfService.Error("Bilgilerini eksik ya da yanlış girdin sanırım,kontrol eder misin? :(");
            return View(registerViewModel);
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
                    _notyfService.Error("Böyle bir Kullanıcı Bulunamadı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    if (await _userManager.IsInRoleAsync(user, "Teacher"))
                    {
                        if (user.PhoneNumber == null)
                        {
                            _notyfService.Success("Hoşgeldin, önce bilgilerini dolduralım!");
                            return Redirect("/Account/Manage/" + user.UserName);
                        }

                    }
                    if (await _userManager.IsInRoleAsync(user, "Student"))
                    {
                        if (user.City == "")
                        {
                            _notyfService.Success("Hoşgeldin, önce bilgilerini dolduralım!");
                            return Redirect("/Account/Manage/" + user.UserName);
                        }
                        else
                        {
                            return Redirect(loginViewModel.ReturnUrl ?? "/");
                        }
                    }
                    else
                    {
                        _notyfService.Success("Tekrar Hoşgeldin,hadi hemen derslere geçelim!");
                        return Redirect(loginViewModel.ReturnUrl ?? "/");
                    }

                }
                else
                {
                    _notyfService.Error("Kullanıcı adı ya da şifre hatalı, tekar kontrol et");

                }

            }
            return View(loginViewModel);
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        [HttpGet]
        public async Task<IActionResult> Manage(string id)
        {
            var images = await _imageService.GetAllAsync();
            string name = id;
            User user = await _userManager.FindByNameAsync(name);
            if (String.IsNullOrEmpty(name))
            {
                return NotFound();
            }
            if (user == null)
            {
                return NotFound();
            }
            List<SelectListItem> genderList = new List<SelectListItem>();
            genderList.Add(new SelectListItem
            {
                Text = "Kadın",
                Value = "Kadın",
                Selected = user.Gender == "Kadın" ? true : false
            });
            genderList.Add(new SelectListItem
            {
                Text = "Erkek",
                Value = "Erkek",
                Selected = user.Gender == "Erkek" ? true : false
            });

            UserManageViewModel userManageViewModel = new UserManageViewModel();
            userManageViewModel.Id = user.Id;
            userManageViewModel.FirstName = user.FirstName;
            userManageViewModel.LastName = user.LastName;
            userManageViewModel.Email = user.Email;
            userManageViewModel.Gender = user.Gender;
            userManageViewModel.DateOfBirth = user.DateOfBirth;
            userManageViewModel.City = user.City;
            userManageViewModel.GenderSelectList = genderList;
            userManageViewModel.UserName = user.UserName;
            userManageViewModel.Image = user.Image;
            userManageViewModel.Description = user.Description;
            if (!User.IsInRole("Student"))
            {
                userManageViewModel.PhoneNumber = user.PhoneNumber;

            }
            return View(userManageViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Manage(UserManageViewModel userManageViewModel)
        {
            var images = await _imageService.GetAllAsync();

            if (userManageViewModel == null) { return NotFound(); }

            User user = await _userManager.FindByIdAsync(userManageViewModel.Id);
        

            user.PhoneNumber = userManageViewModel.PhoneNumber;
            user.FirstName = userManageViewModel.FirstName;
            user.LastName = userManageViewModel.LastName;
            user.Email = userManageViewModel.Email;
            user.Gender = userManageViewModel.Gender;
            user.Description = userManageViewModel.Description;
            user.DateOfBirth = userManageViewModel.DateOfBirth;
            user.City = userManageViewModel.City;
            user.ModifiedDate = DateTime.Now;
            if (userManageViewModel.ImageF != null)
            {
                user.Image = new Image
                {
                    Url = Jobs.UploadImage(userManageViewModel.ImageF),
                    UserId = user.Id
                };
            }
            var result = await _userManager.UpdateAsync(user);

            if (result.Succeeded)
            {
                _notyfService.Success("Profilin başarıyla güncellendi, iyi dersler :)");
                return Redirect("/Account/Manage/" + User.Identity.Name);

            }
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> OpenLesson()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var Enstruments = await _enstrumentService.GetAllAsync();
            var enstruments = Enstruments.Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Name
            });
            ViewBag.Enstruments = enstruments;

            var citySelectListItems = GetCities().Select(x => new SelectListItem
            {
                Text = x.Il,
                Value = x.Il
            });
            ViewBag.cities = citySelectListItems;
            LessonViewModel lessonViewModel = new LessonViewModel
            {

                Enstruments = Enstruments,
            };
            return View(lessonViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> OpenLesson(LessonViewModel lessonViewModel)
        {
            User user = await _userManager.GetUserAsync(User);
            Teacher teacher = await _teacherService.GetTeacherByIdAsync(user.Id);

            Entity.Concrete.Card card = new Entity.Concrete.Card
            {
                Id = lessonViewModel.Id,
                FirstName = teacher.User.FirstName,
                City = lessonViewModel.City,
                EnstrumentName = lessonViewModel.EnstrumentName,
                Description = lessonViewModel.Description,
                OwnDescription = lessonViewModel.OwnDescription,
                Price = lessonViewModel.Price,
                NormalizedEnstrumentName =Jobs.GetNormalizedName( lessonViewModel.EnstrumentName),
                Image = user.Image,
                Status = lessonViewModel.SelectedStatus,
                TeacherPhone=teacher.User.PhoneNumber

            };
            teacher.Cards.Add(card);
            await _cardService.CreateAsync(card);

            _notyfService.Success("İlanın paylaşıldı,hazır ol!");

            return Redirect("/");


        }
        public async Task<IActionResult> MyCards()
        {
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var teacher = await _teacherService.GetTeacherByIdAsync(user.Id);
            if (user == null)
            {
                return NotFound();
            }
            var cards = await _cardService.GetCardsByTeacherAsync(teacher.Id);
            return View(cards);
        }
        public async Task<IActionResult> CancelCard(int id)
        {
            Card card = await _cardService.GetCardWithImageAsync(id);
            await _cardService.DeleteAsync(card);
            return RedirectToAction("MyCards", "Account");
        }
        public async Task<IActionResult> MyRequests()
        {   
            var cards = await _cardService.GetAllAsync();
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            var teacher = await _teacherService.GetTeacherByIdAsync(user.Id);
            if (user == null)
            {
                return NotFound();
            }
            var requests = await _requestService.GetRequestsByTeacherAsync(teacher.Id);
            
            return View(requests);
        }
        public async Task<IActionResult> MyStudentRequests()
        {
            var users = await _userManager.Users.ToListAsync();
            var cards = await _cardService.GetAllAsync();
            
            User user = await _userManager.FindByNameAsync(User.Identity.Name);
            if (user == null)
            {
                return NotFound();
            }
            var requests = await _requestService.GetRequestsByStudentAsync(user.Id);
            
            return View(requests);
        }
        public async Task<IActionResult> CancelRequest(int id)
        {
            var request = await _requestService.GetByIdAsync(id);
            if (request == null) { NotFound(); }
            await _requestService.DeleteAsync(request);

            return Redirect("/Account/MyStudentRequests" + User.Identity.Name);
        }
        public async Task<IActionResult> AcceptRequest(int id)
        {
            var request = await _requestService.GetByIdAsync(id);
            if (request == null) { NotFound(); }
            request.OrderState = EnumOrderState.Approved;
            _requestService.Update(request);
            return Redirect("/Account/MyRequests");
        }
        [NonAction]
        public List<CityType> GetCities()
        {
            using (StreamReader sr = new StreamReader(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/json/cities.json")))
            {
                string jsonResult = sr.ReadToEnd();
                List<CityType> cities = JsonSerializer.Deserialize<List<CityType>>(jsonResult);
                return cities;
            }
        }
    }
}
