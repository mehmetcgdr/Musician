using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Musician.Business.Abstract;
using Musician.Core;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Models.ViewModels.AccountModels;
using System.Reflection;

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

        public AccountController(UserManager<User> userManager, SignInManager<User> signInManager, ICardService cardService, ITeacherService teacherService, INotyfService notyfService, IStudentService studentService, IImageService imageService)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _cardService = cardService;
            _teacherService = teacherService;
            _notyfService = notyfService;
            _studentService = studentService;
            _imageService = imageService;
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
                    CreatedDate=DateTime.Now,
                    ModifiedDate = DateTime.Now
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
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
                        ModifiedDate = DateTime.Now,
                        Image = new Image
                        {
                            UserId = user.Id
                        }
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
                return View(registerViewModel);
            }
            return View("Index");
        }


        [HttpGet]
        public IActionResult StudentRegister()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> StudentRegister(RegisterViewModel registerViewModel)
        {
            List<User> users = await _userManager.Users.ToListAsync();
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    UserName = registerViewModel.UserName,
                    Email = registerViewModel.Email,
                    FirstName = registerViewModel.FirstName,
                    CreatedDate=DateTime.Now,
                    ModifiedDate = DateTime.Now,
                    LastName = registerViewModel.LastName,
                    RoleId = EnumRoleId.Student
                };
                var result = await _userManager.CreateAsync(user, registerViewModel.Password);
                if (result.Succeeded)
                {
                    await _userManager.AddToRoleAsync(user, "User");

                    await _userManager.AddToRoleAsync(user, "Student");
                    Student student = new Student
                    {
                        UserId = user.Id,
                        UserName = registerViewModel.UserName,
                        FirstName = registerViewModel.FirstName,
                        LastName = registerViewModel.LastName,
                        Url = Jobs.GetUrl($"{user.UserName}"),
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        Image = new Image
                        {
                            UserId = user.Id
                        }

                    };
                    await _studentService.CreateAsync(student);

                    _notyfService.Success("Kaydın başarıyla oluşturuldu, İyi dersler :)");
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    if (registerViewModel.UserName == ($"{User.Identity.Name}") || registerViewModel.Email == ($"{users.Select(x=>x.Email)}"))
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
                    _notyfService.Error("Böyle bir Kullanıcı Bulunamadı!");
                    return View(loginViewModel);
                }
                var result = await _signInManager.PasswordSignInAsync(user, loginViewModel.Password, isPersistent: true, lockoutOnFailure: true);

                if (result.Succeeded)
                {
                    _notyfService.Success("Hoşgeldin,hadi hemen derslere geçelim!");
                    return Redirect(loginViewModel.ReturnUrl ?? "/");


                }
                _notyfService.Error("Kullanıcı adı veya parola bilgilerin hatalı!");
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
            string name = id;
            User user = await _userManager.FindByNameAsync(name);
            var teachers = await _teacherService.GetAllTeachersAsync();
            var students = await _studentService.GetAllStudentsAsync();

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

            if (User.IsInRole("Student"))
            {
                userManageViewModel.Id = user.Id;
                userManageViewModel.FirstName = user.FirstName;
                userManageViewModel.LastName = user.LastName;
                userManageViewModel.Email = user.Email;
                userManageViewModel.Gender = user.Gender;
                userManageViewModel.DateOfBirth = user.DateOfBirth;
                userManageViewModel.City = user.City;
                userManageViewModel.GenderSelectList = genderList;
                userManageViewModel.UserName = user.UserName;
                userManageViewModel.Image = user.Student.Image;
                userManageViewModel.Description = user.Student.Description;

            }
            else
            {
                userManageViewModel.Id = user.Id;
                userManageViewModel.FirstName = user.FirstName;
                userManageViewModel.LastName = user.LastName;
                userManageViewModel.Email = user.Email;
                userManageViewModel.Gender = user.Gender;
                userManageViewModel.DateOfBirth = user.DateOfBirth;
                userManageViewModel.City = user.City;
                userManageViewModel.GenderSelectList = genderList;
                userManageViewModel.UserName = user.UserName;
                userManageViewModel.Image = user.Teacher.Image;
                userManageViewModel.Description = user.Teacher.Description;
                userManageViewModel.PhoneNumber = user.PhoneNumber;


            }

            return View(userManageViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Manage(UserManageViewModel userManageViewModel)
        {
            if (userManageViewModel == null) { return NotFound(); }

            User user = await _userManager.FindByIdAsync(userManageViewModel.Id);
            Student student = await _studentService.GetStudentByIdAsync(user.Id);
            Teacher teacher = await _teacherService.GetTeacherByIdAsync(user.Id);

            if (User.IsInRole("Teacher"))
            {
                teacher.Image = new Image
                {
                    Url = Jobs.UploadImage(userManageViewModel.ImageF),
                    UserId=user.Id
                };
                                                                                    //                    !!!!!!!!!!!BURAYI DÜZELT!!!!!!!!!!1
                user.PhoneNumber = userManageViewModel.PhoneNumber;
                user.FirstName = userManageViewModel.FirstName;
                user.LastName = userManageViewModel.LastName;
                user.Email = userManageViewModel.Email; // sadece userde
                user.Gender = userManageViewModel.Gender;
                user.Description = userManageViewModel.Description;
                user.DateOfBirth = userManageViewModel.DateOfBirth;
                user.City = userManageViewModel.City;
                user.ModifiedDate = DateTime.Now; 
                
                teacher.PhoneNumber = userManageViewModel.PhoneNumber;
                teacher.FirstName = userManageViewModel.FirstName;
                teacher.LastName = userManageViewModel.LastName;
                teacher.Gender = userManageViewModel.Gender;
                teacher.Description = userManageViewModel.Description;
                teacher.DateOfBirth = userManageViewModel.DateOfBirth;
                teacher.City = userManageViewModel.City;
                teacher.ModifiedDate=DateTime.Now;
            }
            else
            {
                                            
                user.PhoneNumber = userManageViewModel.PhoneNumber;
                user.FirstName = userManageViewModel.FirstName;
                user.LastName = userManageViewModel.LastName;
                user.Email = userManageViewModel.Email; // sadece userde
                user.Gender = userManageViewModel.Gender;
                user.Description = userManageViewModel.Description;
                user.DateOfBirth = userManageViewModel.DateOfBirth;
                user.City = userManageViewModel.City;
                user.ModifiedDate= DateTime.Now;
                student.Image = new Image
                {
                    Url = Jobs.UploadImage(userManageViewModel.ImageF),
                    UserId=user.Id
                };
                student.FirstName = userManageViewModel.FirstName;
                student.LastName = userManageViewModel.LastName;
                student.Gender = userManageViewModel.Gender;
                student.Description = userManageViewModel.Description;
                student.DateOfBirth = userManageViewModel.DateOfBirth;
                student.City = userManageViewModel.City;
                student.ModifiedDate = DateTime.Now;
            }
            var result = await _userManager.UpdateAsync(user);

            if (User.IsInRole("Teacher"))
            {
                 _imageService.Update(teacher.Image);
            }
            else
            {
                _imageService.Update(student.Image);
            }


           



            if (result.Succeeded)
            {
                _notyfService.Success("Profilin başarıyla güncellendi, iyi dersler :)");
                return Redirect("/Account/Manage/" + User.Identity.Name);

            }

            return View();
        }

    }
}
