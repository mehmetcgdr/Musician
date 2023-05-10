namespace Musician.MVC.Models.ViewModels
{
    public class EnstrumentViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public bool IsApproved { get; set; }
        public string Url { get; set; }
        public string NormalizedEnstrumentName { get; set; }
    }
}
