using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musician.Business.Abstract;
using Musician.Core;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Areas.Admin.Models.ViewModels;
using Musician.MVC.Models.ViewModels;
using System.Diagnostics.Metrics;

namespace Musician.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize]

    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICardService _cardService;
        private readonly UserManager<User> _userManager;
        private readonly IEnstrumentService _enstrumentService;
        private readonly INotyfService _notyfService;
        private readonly IRequestService _requestService;
        private readonly IImageService _imageService;
        private readonly IStudentService _studentService;


        public HomeController(ITeacherService teacherService, ICardService cardService, UserManager<User> userManager, IEnstrumentService enstrumentService, INotyfService notyfService, IRequestService requestService, IImageService imageService, IStudentService studentService)
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

        public  IActionResult Index()
        {
           
            return View();
        }
        public async Task<IActionResult> Enstruments(string id)
        {
            var cards = await _cardService.GetCardsInAdminAsync(id);
            List<EnstrumentsViewModel> enstrumentsViewModel = new List<EnstrumentsViewModel>();
            enstrumentsViewModel = cards.Select(c => new EnstrumentsViewModel
            {
                Price = c.Price,
                FirstName = c.FirstName,
                EnstrumentName = c.EnstrumentName,
                Id = c.Id,
                City = c.City,
                NormalizedEnstrumentName= id
            }).ToList();
            return View(enstrumentsViewModel);
        }
        public async Task<IActionResult> CancelCard(int id)
        {
            Card card = await _cardService.GetCardWithImageAsync(id);
           await  _cardService.DeleteAsync(card);
            return Redirect("/admin/Home/Enstruments");
        }
        public async Task<IActionResult> Users(string role)
        {
            if (role == "User")
            {
                var users = await _userManager.Users.OrderByDescending(x => x.IsApproved).OrderByDescending(x => x.RoleId).ToListAsync();
                return View(users);
            } 
            else 
            {
               
                var users = await _userManager.GetUsersInRoleAsync(role);

                return View(users);
            }
            
        }
        public async Task<IActionResult> Requests()
        {
            //var cards = await _cardService.GetAllAsync();
            //var students = await _studentService.GetAllStudentsAsync();
            //var teachers = await _teacherService.GetAllTeachersAsync();
            //var users=await _userManager.Users.ToListAsync();
            List<Request> requests= await _requestService.GetRequestsInAdminAsync();
            
            return View(requests);
        }
        [HttpGet]
        public IActionResult CreateEnstrument()
        {
            return View();
        }
        public async Task<IActionResult> CreateEnstrument(CreateEnstrumentViewModel createEnstrumentViewModel)
        {
            Enstrument enstrument = new Enstrument
            {
                Name = createEnstrumentViewModel.Name,
                Url = Jobs.GetUrl(createEnstrumentViewModel.Name),
                IsApproved = createEnstrumentViewModel.IsApproved,
                NormalizedEnstrumentName = Jobs.GetNormalizedName(createEnstrumentViewModel.Name),
            };
            await _enstrumentService.CreateAsync(enstrument);

            return Redirect("/admin/Home/AllEnstruments");
        }
        public async Task<IActionResult> AllEnstruments(string enstrument)
        {
            List<Enstrument> enstruments = await _enstrumentService.GetAllAsync();
            return View(enstruments);
        }
        public async Task<IActionResult> Delete(int id)
        {
            Enstrument enstrument = await _enstrumentService.GetByIdAsync(id);
            await _enstrumentService.DeleteAsync(enstrument);
            return Redirect("/admin/Home/AllEnstruments");
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            Enstrument enstrument = await _enstrumentService.GetByIdAsync(id);
            CreateEnstrumentViewModel createEnstrumentViewModel = new CreateEnstrumentViewModel
            {
                Name = enstrument.Name,
                IsApproved = enstrument.IsApproved,
                
            };
            return View(createEnstrumentViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(CreateEnstrumentViewModel createEnstrumentViewModel)
        {
            if (ModelState.IsValid)
            {
                Enstrument enstrument = await _enstrumentService.GetByIdAsync(createEnstrumentViewModel.Id);
                enstrument.Name = createEnstrumentViewModel.Name;
                enstrument.IsApproved = createEnstrumentViewModel.IsApproved;
                 _enstrumentService.Update(enstrument);
            }
            return Redirect("/admin/Home/Allenstruments");

        }
        public async Task<IActionResult> UpdateIsApproved(int id, bool ApprovedStatus)
        {
            Enstrument enstrument = await _enstrumentService.GetByIdAsync(id);
            if (enstrument != null)
            {
                enstrument.IsApproved = !enstrument.IsApproved;
                _enstrumentService.Update(enstrument);
            }

            return Redirect("/admin/Home/AllEnstruments");
        }
        //public async Task<IActionResult> GoToTeacher(int id)
        //{
        //    var card = await _cardService.GetByIdAsync(id);
        //    var teacher = await _teacherService.GetTeacherByCardAsync(card);

        //}
    }
}
