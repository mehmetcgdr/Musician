using AspNetCoreHero.ToastNotification.Abstractions;
using Iyzipay;
using Iyzipay.Model;
using Iyzipay.Request;
using Microsoft.AspNetCore.Components.Routing;
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
        private readonly INotyfService _notyfService;
        private readonly IRequestService _requestService;

        public HomeController(ITeacherService teacherService, ICardService cardService, UserManager<User> userManager, IEnstrumentService enstrumentService, INotyfService notyfService, IRequestService requestService)
        {
            _teacherService = teacherService;
            _cardService = cardService;
            _userManager = userManager;
            _enstrumentService = enstrumentService;
            _notyfService = notyfService;
            _requestService = requestService;
        }

        public async Task<IActionResult> Index(string name)
        {
            
            List<Entity.Concrete.Card> cards = await _cardService.GetFilterCardsAsync(name);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetBySearch(string name) //enstrüman ismine göre
        {
            name = name.ToUpper();
            var teacher = await _teacherService.GetAllTeachersAsync();
            List<Entity.Concrete.Card> cards = await _cardService.GetFilterCardsAsync(name);
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

            Entity.Concrete.Card card = new Entity.Concrete.Card
            {
                Id = lessonViewModel.Id,
                FirstName = teacher.FirstName,
                City = lessonViewModel.City,
                EnstrumentName = lessonViewModel.EnstrumentName,
                Description = lessonViewModel.Description,
                OwnDescription = lessonViewModel.OwnDescription,
                Price = lessonViewModel.Price,
                NormalizedEnstrumentName = lessonViewModel.EnstrumentName.ToUpper(),    
                Image = new Image
                {
                    Id=lessonViewModel.Id,
                    UserId=user.Id,
                }

            };
            teacher.Cards.Add(card);
            await _cardService.CreateAsync(card);
            //eğer başarılıysa notyf ekle
            //_notyfService.Success("İlanın paylaşıldı,hazır ol!");

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

        [HttpGet]
        public async Task<IActionResult> RequestLesson(int id)
        {
            List<Teacher> teachers = await _teacherService.GetAllTeachersAsync();
            Entity.Concrete.Card card = await _cardService.GetCardWithImageAsync(id);   
            RequestViewModel requestViewModel = new RequestViewModel
            {
                Card = card,
                CardId=card.Id,
            };
            
            
            return View(requestViewModel);
        }
        [HttpPost]
        public async Task<IActionResult> RequestLesson(RequestViewModel requestViewModel)
        {
            var card = await _cardService.GetCardWithImageAsync(requestViewModel.Card.Id);
            User student=await _userManager.GetUserAsync(User);
            var teacher = await _teacherService.GetTeacherByCardId(card.TeacherId);
            if (ModelState.IsValid)
            {
                
                if (!CardNumberControl(requestViewModel.CardNumber))
                {
                    _notyfService.Error("Geçersiz Kart Numarası Girdiniz, Kontrol Ediniz.");
                    return View(requestViewModel);
                }
                Payment payment = await PaymentProcess(requestViewModel);
                if (payment.Status == "success")
                {
                    SaveRequest(requestViewModel, student.Id, teacher.Id);
                    _notyfService.Success("Ödemeniz alınmıştır, eğitim sonlanana kadar paranız güvendedir, öğretmen kaynaklı bir sorunda ödemeniz iade edilecektir. iyi dersler :)");
                }
                else
                {
                    _notyfService.Error("Bir sorun oluştu!");
                }
                
            }
            requestViewModel = new RequestViewModel
            {
                Card = card,
                CardId = card.Id,
            };
            return View(requestViewModel);
        }














        [NonAction]
        private bool CardNumberControl(string cardNumber)
        {
            #region Açıklamalar
            /* -cardNumber'ı boşluk ve tire'den arındıracağız.
             * -cardNumber uzunluk kontrolünü yapacağız.
             * -Sayısal değer kontrolü yapacağız.
             * -Luhn algoritmasına uygunluğunu test edeceğiz
             */
            #endregion
            cardNumber = cardNumber.Replace("-", "").Replace(" ", "");
            if (cardNumber.Length != 16) return false;
            foreach (var chr in cardNumber)
            {
                if (!Char.IsNumber(chr)) return false;
            }
            int oddTotal = 0;
            int ovenTotal = 0;
            for (int i = 0; i < cardNumber.Length; i += 2)
            {
                int nextOddNumber = Convert.ToInt32(cardNumber[i].ToString());
                int nextOvenNumber = Convert.ToInt32(cardNumber[i + 1].ToString());
                int addedOddNumber = nextOddNumber * 2;
                addedOddNumber = addedOddNumber >= 10 ? addedOddNumber - 9 : addedOddNumber;
                oddTotal += addedOddNumber;
                ovenTotal += nextOvenNumber;
            }
            int total = oddTotal + ovenTotal;
            bool isValidNumber = total % 10 == 0 ? true : false;
            return isValidNumber;
        }
        [NonAction]
        private async void SaveRequest(RequestViewModel requestViewModel,string studentId,int teacherId)
        {
            var card = await _cardService.GetCardWithImageAsync(requestViewModel.Id);
            User student = await _userManager.GetUserAsync(User);
            var teacher = await _teacherService.GetTeacherByCardId(card.TeacherId);

            Request request = new Request
            {
                CardId = requestViewModel.Card.Id,
                StudentId = student.Id,
                TeacherId = teacher.Id,
                OrderDate = DateTime.Now,
                OrderState = EnumOrderState.Waiting,
                Price = card.Price,
            };
            await _requestService.CreateAsync(request);

        }
        private async Task<Payment> PaymentProcess(RequestViewModel requestViewModel) 
        {
            var card = await _cardService.GetCardWithImageAsync(requestViewModel.Card.Id);
            User user= await _userManager.GetUserAsync(User);

            Options options = new Options();
            options.ApiKey = "sandbox-dTZf9NUJPygOvQpL6WsC9RX7XBHAHbNu";
            options.SecretKey = "sandbox-jEVIazukcVxlNRTFDbHXijoF7wQaPyiR";
            options.BaseUrl= "https://sandbox-api.iyzipay.com";


            CreatePaymentRequest request = new CreatePaymentRequest
            {
                Locale = Locale.TR.ToString(),
                ConversationId = new Random().Next(1000000, 9999999).ToString(),
                Price = Convert.ToInt32(card.Price).ToString(),
                PaidPrice = Convert.ToInt32(card.Price).ToString(),
                Currency = Currency.TRY.ToString(),
                Installment = 1,
                PaymentChannel = PaymentChannel.WEB.ToString(),
                PaymentGroup = PaymentGroup.PRODUCT.ToString(),
                PaymentCard= new PaymentCard
                {
                    CardHolderName=requestViewModel.CardName,
                    CardNumber=requestViewModel.CardNumber,
                    ExpireMonth=requestViewModel.ExpirationMonth,
                    ExpireYear=requestViewModel.ExpirationYear,
                    Cvc=requestViewModel.Cvc,
                    RegisterCard=0
                },
                Buyer=new Buyer
                {
                    Id=user.Id,
                    Name=user.FirstName,
                    Surname=user.LastName,
                    Email=user.Email,
                    IdentityNumber="00000000000",
                    RegistrationAddress="WorldWideWeb",
                    Ip="85.99.155.212",
                    City=user.City,
                    Country="Türkiye",
                    ZipCode="34700"
                },
                ShippingAddress = new Address
                {
                    ContactName = user.FirstName+ "" + user.LastName,
                    City = user.City,
                    Country = "Türkiye",
                    Description = user.Description
                },
                BillingAddress = new Address
                {
                    ContactName = user.FirstName + "" + user.LastName,
                    City = user.City,
                    Country = "Türkiye",
                    Description = user.Description
                }
            };
            List<BasketItem> basketItems = new List<BasketItem>();
            BasketItem basketItem;
            basketItem = new BasketItem
            {
                Id = card.Id.ToString(),
                Name = card.EnstrumentName,
                Category1 = "Özel Ders",
                ItemType = BasketItemType.VIRTUAL.ToString(),
                Price = Convert.ToInt32(card.Price).ToString()
            };
            basketItems.Add(basketItem);
            request.BasketItems = basketItems;
            Payment payment =Payment.Create(request, options);
            return payment;
        }
    }
}