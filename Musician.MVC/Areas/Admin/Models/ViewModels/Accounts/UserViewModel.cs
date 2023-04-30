using Musician.Entity.Concrete;

namespace Musician.MVC.Areas.Admin.Models.ViewModels.Accounts
{
    public class UserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Description { get; set; } 
        public string Gender { get; set; } 
        public string City { get; set; } 
        public DateTime? DateOfBirth { get; set; } 
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public EnumRoleId RoleId { get; set; }
        public Image? Image { get; set; }
        public IFormFile ImageFile { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string UserName { get; set; }
    }
}
