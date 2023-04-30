using AspNetCoreHero.ToastNotification.Abstractions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Musician.Business.Abstract;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Areas.Admin.Models.ViewModels;
using Musician.MVC.Models.ViewModels;

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

        public HomeController(ITeacherService teacherService, ICardService cardService, UserManager<User> userManager, IEnstrumentService enstrumentService, INotyfService notyfService, IRequestService requestService, IImageService imageService)
        {
            _teacherService = teacherService;
            _cardService = cardService;
            _userManager = userManager;
            _enstrumentService = enstrumentService;
            _notyfService = notyfService;
            _requestService = requestService;
            _imageService = imageService;
        }

        public async Task<IActionResult> Index()
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
        public async Task<IActionResult> Users(string role)
        {
            var users = await _userManager.GetUsersInRoleAsync(role);
            return View(users);
        }
        public async Task<IActionResult> Requests()
        {
            var requests= await _requestService.GetAllAsync();
            return View(requests);
        }
    }
}
