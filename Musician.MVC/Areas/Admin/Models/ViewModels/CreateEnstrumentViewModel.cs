namespace Musician.MVC.Areas.Admin.Models.ViewModels
{
    public class CreateEnstrumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string NormalizedEnstrumentName { get; set; }

    }
}
