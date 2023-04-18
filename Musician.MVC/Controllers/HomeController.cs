using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Musician.Business.Abstract;
using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;
using Musician.MVC.Models;
using Musician.MVC.Models.ViewModels;
using Musician.MVC.Models.ViewModels.AccountModels;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Diagnostics.Metrics;
using System.Xml.Linq;

namespace Musician.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITeacherService _teacherService;
        private readonly ICardService _cardService;
        private readonly UserManager<User> _userManager;
        private readonly IEnstrumentService _enstrumentService;

        public HomeController(ITeacherService teacherService, ICardService cardService, UserManager<User> userManager, IEnstrumentService enstrumentService)
        {
            _teacherService = teacherService;
            _cardService = cardService;
            _userManager = userManager;
            _enstrumentService = enstrumentService;
        }

        public async Task<IActionResult> Index(string name)
        {
            
            List<Card> cards = await _cardService.GetFilterCardsAsync(name);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetBySearch(string name) //enstrüman ismine göre
        {
            var teacher = await _teacherService.GetAllTeachersAsync();
            List<Card> cards = await _cardService.GetFilterCardsAsync(name);
            List<CardModel> cardsModel = new List<CardModel>();
            cardsModel = cards.Select(c => new CardModel
            {
                Id = c.Id,
                EnstrumentName = c.EnstrumentName,
                City = c.City,
                Description = c.Description,
                OwnDescription = c.OwnDescription,
                Enstrument = c.Enstrument,
                FirstName = c.FirstName,
                Price = c.Price,
                Image=c.Image


            }).ToList();
            if (RouteData.Values["name"] != null)
            {
                ViewBag.SelectedEnstrumentName = await _cardService.GetFilterCardsAsync(RouteData.Values["name"].ToString());
            }
            return View("Index", cardsModel);
        }
        //public async Task<IActionResult> AllCards( string name) //aramaya göre(ders adı) tüm card listesi ----bu boş olabilir kontrol edip silebilirsin

        //{
        //    List<Teacher> teachers = await _teacherService.GetAllTeachersAsync();
        //    var cards= await _cardService.GetFilterCardsAsync(name);
        //    List<LessonViewModel> cardViewModels = cards.Select(c => new LessonViewModel
        //    {
        //        Id=c.Id,
        //        FirstName=c.FirstName,
        //        City=c.City,
        //        Description=c.Description,
        //        Price = c.Price,

        //        NormalizedEnstrumentName = (c.EnstrumentName).ToUpper(),

        //    }).ToList();
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> OpenLesson() //ders ver get kısmı
        {
            var Enstruments = await _enstrumentService.GetAllAsync();

            LessonViewModel lessonViewModel = new LessonViewModel
            {
                Enstruments = Enstruments
            };

            return View(lessonViewModel);


        }
        [HttpPost]
        public async Task<IActionResult> OpenLesson(LessonViewModel lessonViewModel) //ders ver post kısmı
        {
            User user = await _userManager.GetUserAsync(User);
            Teacher teacher = await _teacherService.GetTeacherByIdAsync(user.Id);

            Card card = new Card
            {
                Id = lessonViewModel.Id,
                FirstName = teacher.FirstName,
                City = lessonViewModel.City,
                EnstrumentName = "Kaval",
                Description = lessonViewModel.Description,
                OwnDescription = lessonViewModel.OwnDescription,
                Price = lessonViewModel.Price,
                NormalizedEnstrumentName = "",
                Image = new Image
                {
                    Id=lessonViewModel.Id,
                    UserId=user.Id,
                }

            };
            teacher.Cards.Add(card);
            await _cardService.CreateAsync(card);
            //eğer başarılıysa notyf ekle
            return View("Index");
        }
        public async Task<IActionResult> CardDetails(int id)
        {
            var card = await _cardService.GetCardWithImageAsync(id);
            CardDetailsViewModel cardDetailsViewModel = new CardDetailsViewModel
            {
                Id=card.Id,
                FirstName=card.FirstName,
                City=card.City,
                Description = card.Description,
                EnstrumentName=card.EnstrumentName,
                OwnDescription=card.OwnDescription,
                Price = card.Price,
                Image = card.Image
            };

            return View(cardDetailsViewModel);
        }
    }
}