using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Musician.Entity.Concrete;


namespace Musician.MVC.Models.ViewModels
{
    public class RequestViewModel
    {

        public Card Card { get; set; }
        public int CardId { get; set; }
        public int Id { get; set; }
        [DisplayName("Öğretmene Notunuz")]
        [Required(ErrorMessage = "Not alanı boş bırakılmamalıdır.")]
        public string Message { get; set; }
        public DateTime OrderDate { get; set; }
        //public CartViewModel Cart { get; set; }
        //Kredi Kartı ile ilgili properties
        [DisplayName("Kartın Üzerinde Ad Soyad")]
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        [MinLength(5, ErrorMessage = "Ad Soyad en az 5 karakter olmalıdır")]
        [MaxLength(100, ErrorMessage = "Ad Soyad en fazla 100 karakter olmalıdır")]
        public string CardName { get; set; }

        [DisplayName("Kart Numarası")]
        [Required(ErrorMessage = "Ad soyad zorunludur")]
        [MinLength(16, ErrorMessage = "Kart Numarası en az 16 rakam olmalıdır")]
        [MaxLength(16, ErrorMessage = "Kart Numarası en fazla 16 rakam olmalıdır")]
        public string CardNumber { get; set; }

        [DisplayName("Geçerlilik Tarihi Ay")]
        [Required(ErrorMessage = "Ay bilgisi zorunludur")]
        [MinLength(2, ErrorMessage = "Ay bilgisi en az 2 rakam olmalıdır")]
        [MaxLength(2, ErrorMessage = "Ay bilgisi en fazla 2 rakam olmalıdır")]
        public string ExpirationMonth { get; set; }

        [DisplayName("Geçerlilik Tarihi Yıl")]
        [Required(ErrorMessage = "Yıl bilgisi zorunludur")]
        [MinLength(2, ErrorMessage = "Yıl bilgisi en az 2 rakam olmalıdır")]
        [MaxLength(2, ErrorMessage = "Yıl bilgisi en fazla 2 rakam olmalıdır")]
        public string ExpirationYear { get; set; }

        [DisplayName("Cvc No")]
        [Required(ErrorMessage = "Cvc bilgisi zorunludur")]
        [MinLength(3, ErrorMessage = "Yıl bilgisi en az 3 rakam olmalıdır")]
        [MaxLength(3, ErrorMessage = "Yıl bilgisi en fazla 3 rakam olmalıdır")]
        public string Cvc { get; set; }
    }
}
