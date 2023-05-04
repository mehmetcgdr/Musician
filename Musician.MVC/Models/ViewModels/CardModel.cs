using Musician.Entity.Concrete;

namespace Musician.MVC.Models.ViewModels
{
    public class CardModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public decimal? Price { get; set; }
        public string OwnDescription { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        //public List<SelectListItem>? StatusSelectList { get; set; } = new List<SelectListItem>();
        public List<Enstrument> Enstruments { get; set; }
        public string EnstrumentName { get; set; }
        public Enstrument Enstrument { get; set; }

        public Image Image { get; set; }

    }
}
