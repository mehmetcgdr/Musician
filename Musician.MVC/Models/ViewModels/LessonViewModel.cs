using Musician.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Musician.MVC.Models.ViewModels
{
    public class LessonViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        [DisplayName("Hakkımda")]
        [Required(ErrorMessage = "Hakkımda alanı boş bırakılamaz")]
        public string OwnDescription { get; set; }
        [DisplayName("Ücret")]
        [Required(ErrorMessage = "Ücret alanı boş bırakılamaz")]
        public decimal? Price { get; set; }
        [DisplayName("Ders Hakkında")]
        [Required(ErrorMessage = "Ders Hakkında alanı boş bırakılamaz")]
        public string Description { get; set; }
        [DisplayName("Şehir")]
        [Required(ErrorMessage = "Şehir alanı boş bırakılamaz")]
        public string City { get; set; }
        //[DisplayName("Dersin verileceği yer")]
        //[Required(ErrorMessage = "Dersin verileceği yer boş bırakılamaz")]
        //public List<SelectListItem>? StatusSelectList { get; set; } = new List<SelectListItem>();
        [DisplayName("Hangi Enstrüman için eğitim vermek istiyorsun?")]
        [Required(ErrorMessage = "Enstrüman alanı boş bırakılamaz")]
        public List<SelectListItem> SelectedEnstrument { get; set; }
        public string EnstrumentName { get; set; }
        public string EnstrumentId { get; set; }

        public string NormalizedEnstrumentName { get; set; } = "";
        public Teacher Teacher { get; set; }
        public List<Enstrument> Enstruments { get; set; }
        public virtual Image TeacherImage { get; set; }

    }
}

