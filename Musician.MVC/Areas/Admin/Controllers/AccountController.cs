﻿using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Musician.Business.Abstract;
using Musician.Core;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Areas.Admin.Models.ViewModels.Accounts;

namespace Musician.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]
    public class AccountController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICardService _cardService;
        private readonly UserManager<User> _userManager;
        private readonly IEnstrumentService _enstrumentService;
        private readonly INotyfService _notyfService;
        private readonly IRequestService _requestService;
        private readonly IImageService _imageService;
        private readonly IStudentService _studentService;

        public AccountController(ITeacherService teacherService, ICardService cardService, UserManager<User> userManager, IEnstrumentService enstrumentService, INotyfService notyfService, IRequestService requestService, IImageService imageService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _cardService = cardService;
            _userManager = userManager;
            _enstrumentService = enstrumentService;
            _notyfService = notyfService;
            _requestService = requestService;
            _imageService = imageService;
            _studentService = studentService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(string id)
        {
            var images = await _imageService.GetAllAsync();
            var user = await _userManager.FindByIdAsync(id);
            UserViewModel userViewModel = new UserViewModel
            {
                Id = user.Id,
                City = user.City,
                DateOfBirth = user.DateOfBirth,
                Description = user.Description,
                FirstName = user.FirstName,
                Gender = user.Gender,
                LastName = user.LastName,
                RoleId = user.RoleId,
                Image = user.Image,
                Email = user.Email,
                PhoneNumber = user.PhoneNumber,
                UserName = user.UserName
            };
            return View(userViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(UserViewModel userViewModel)
        {
            var images = await _imageService.GetAllAsync();
            if (ModelState.IsValid)
            {
                var user = await _userManager.FindByIdAsync(userViewModel.Id);
                if (user == null) { return NotFound(); }
                user.FirstName = userViewModel.FirstName;
                user.LastName = userViewModel.LastName;
                user.Gender = userViewModel.Gender;
                user.Email = userViewModel.Email;
                user.PhoneNumber = userViewModel.PhoneNumber;
                user.UserName = userViewModel.UserName;
                user.City= userViewModel.City;
                user.CreatedDate = userViewModel.CreatedDate;
                user.ModifiedDate=DateTime.Now;
                user.DateOfBirth = userViewModel.DateOfBirth;
                if (userViewModel.ImageFile!=null)
                {
                    user.Image = new Image
                    {

                        Url = Jobs.UploadImage(userViewModel.ImageFile),
                        UserId = userViewModel.Id
                    };
                }
               
               await _userManager.UpdateAsync(user);
            }

            return Redirect("/admin/Home/Users?role=User");
        }
    
        public async Task<IActionResult> Delete(string id)
        {
            var images = await _imageService.GetAllAsync();
            var user = await _userManager.FindByIdAsync(id);
           
            
            await _userManager.DeleteAsync(user);
            return Redirect("/admin/Home/Users?role=User");
        }
        [HttpGet]
        public IActionResult CreateUser()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(CreateUserViewModel createUserViewModel)
        {
            if (ModelState.IsValid)
            {
                User user = new User
                {
                    FirstName= createUserViewModel.FirstName,
                    LastName= createUserViewModel.LastName,
                    Email= createUserViewModel.Email,
                    City= createUserViewModel.City,
                    PhoneNumber= createUserViewModel.PhoneNumber,
                    CreatedDate=DateTime.Now,
                    ModifiedDate=DateTime.Now,
                    DateOfBirth=createUserViewModel.DateOfBirth,
                    RoleId = createUserViewModel.RoleId,
                    UserName = createUserViewModel.UserName,
                };
                if (createUserViewModel.ImageFile != null)
                {
                    user.Image = new Image
                    {
                        Url = Jobs.UploadImage(createUserViewModel.ImageFile)
                    };
                };
                   var result= await _userManager.CreateAsync(user,createUserViewModel.Password);
                if (createUserViewModel.RoleId == EnumRoleId.Teacher)
                {
                   
                    Teacher teacher = new Teacher
                    {
                        FirstName = createUserViewModel.FirstName,
                        LastName = createUserViewModel.LastName,
                        City = createUserViewModel.City,
                        PhoneNumber = createUserViewModel.PhoneNumber,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        DateOfBirth = createUserViewModel.DateOfBirth,
                        UserName = createUserViewModel.UserName,
                    };
                    if (createUserViewModel.ImageFile != null)
                    {
                        teacher.Image = new Image
                        {
                            Url = Jobs.UploadImage(createUserViewModel.ImageFile),
                            UserId=user.Id
                        };
                    };
                    await _teacherService.CreateAsync(teacher);
                    await _userManager.AddToRoleAsync(user, "User");

                    await _userManager.AddToRoleAsync(user, "Teacher");
                }
                else if (createUserViewModel.RoleId==EnumRoleId.Student)
                {
                    Student student = new Student
                    {
                        FirstName = createUserViewModel.FirstName,
                        LastName = createUserViewModel.LastName,
                        City = createUserViewModel.City,
                        CreatedDate = DateTime.Now,
                        ModifiedDate = DateTime.Now,
                        DateOfBirth = createUserViewModel.DateOfBirth,
                        UserName = createUserViewModel.UserName,
                    };
                    if (createUserViewModel.ImageFile != null)
                    {
                        student.Image = new Image
                        {
                            Url = Jobs.UploadImage(createUserViewModel.ImageFile),
                            UserId = user.Id
                        };
                    };
                    await _studentService.CreateAsync(student);
                    await _userManager.AddToRoleAsync(user, "User");

                    await _userManager.AddToRoleAsync(user, "Student");
                }

                }
            return Redirect("/admin/Home/Users?role=User");
        }
           
        }
    }

