using Musician.Entity.Concrete;
using Musician.Entity.Concrete.Identity;

namespace Musician.MVC.Models.ViewModels
{
    public class CardDetailsViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public decimal? Price { get; set; }
        public string OwnDescription { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        public string EnstrumentName { get; set; }
        public Enstrument Enstrument { get; set; }
        public Image Image { get; set; }
        
    }
}
