

using Musician.Entity.Concrete.Identity;

namespace Musician.Entity.Concrete
{
    public class Image 
    {
        public int Id { get; set; }
        public string Url { get; set; } = "genel.png";
        public User User { get; set; }
        public string UserId { get; set; }
        
        
    }
}
