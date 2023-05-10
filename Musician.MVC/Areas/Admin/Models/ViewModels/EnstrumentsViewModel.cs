using Musician.Entity.Concrete;

namespace Musician.MVC.Areas.Admin.Models.ViewModels
{
    public class EnstrumentsViewModel
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
        public string NormalizedEnstrumentName { get; set; }

    }
}
