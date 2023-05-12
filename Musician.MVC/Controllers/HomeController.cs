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
using System.Security.Cryptography.Xml;
using System.Text.Json;
using System.Xml.Linq;
using WeatherCast.Models;

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
        private readonly IStudentService _studentService;

        public HomeController(ITeacherService teacherService, ICardService cardService, UserManager<User> userManager, IEnstrumentService enstrumentService, INotyfService notyfService, IRequestService requestService, IStudentService studentService)
        {
            _teacherService = teacherService;
            _cardService = cardService;
            _userManager = userManager;
            _enstrumentService = enstrumentService;
            _notyfService = notyfService;
            _requestService = requestService;
            _studentService = studentService;
        }

        public async Task<IActionResult> Index(string name)
        {

            var EnstrumentList = await _enstrumentService.GetAllAsync();
            var enstruments = EnstrumentList.Select(x => new SelectListItem
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
            List<Entity.Concrete.Card> cards = await _cardService.GetFilterCardsAsync(name,null);
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> GetBySearch(string name,string city) 
        {
            
            var teacher = await _teacherService.GetAllTeachersAsync();
          
            List<Entity.Concrete.Card> cards = await _cardService.GetFilterCardsAsync(name,city);
            if (name != null && cards.Count==0)
            {
                _notyfService.Information("Aradığınız kategoride henüz ilan bulunmamaktadır :(");
                return Redirect("/");
                
            }
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
                Image = c.Image,
                SelectedStatus=c.Status,

            }).ToList();
            if (RouteData.Values["name"] != null)
            {
                ViewBag.SelectedEnstrumentName = await _cardService.GetFilterCardsAsync(RouteData.Values["name"].ToString(), RouteData.Values["city"].ToString());
            }
            return View("Index", cardsModel);
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
            var teachers = await _teacherService.GetAllTeachersAsync();
            var teacher = await _teacherService.GetTeacherByCardId(card.Teacher.Id);
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
            //User studentUser = await _userManager.GetUserAsync(User);
            var student = await _studentService.GetStudentByIdAsync(studentId);
            var teacher = await _teacherService.GetTeacherByCardId(card.Teacher.Id);

            Request request = new Request
            {
                CardId = requestViewModel.Card.Id,
                Student = student,
                TeacherId = teacher.Id,
                OrderDate = DateTime.Now,
                OrderState = EnumOrderState.Waiting,
                Price = card.Price,
                Message=requestViewModel.Message
            };
            await _requestService.CreateAsync(request);

        }
        private async Task<Payment> PaymentProcess(RequestViewModel requestViewModel) 
        {
            var card = await _cardService.GetCardWithImageAsync(requestViewModel.Card.Id);
            User user= await _userManager.GetUserAsync(User);

            Options options = new Options();
            options.ApiKey = "sandbox-WGNDY5oxa5QA052R9avfXEbquBJ6R86p";
            options.SecretKey = "sandbox-TggAvnVU19Lv2ANokoMmjnSCdXrhhpvF";
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
                    Description = "",
                    ZipCode="34200"
                },
                
            };

            Address billingAddress = new Address();
            billingAddress.ContactName = "Jane Doe";
            billingAddress.City = "Istanbul";
            billingAddress.Country = "Turkey";
            billingAddress.Description = "Nidakule Göztepe, Merdivenköy Mah. Bora Sok. No:1";
            billingAddress.ZipCode = "34742";
            request.BillingAddress = billingAddress;

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