using Musician.Entity.Concrete;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Musician.MVC.Areas.Admin.Models.ViewModels.Accounts
{
    public class CreateUserViewModel
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string? Description { get; set; }
        public string? Gender { get; set; }
        public string City { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public Teacher Teacher { get; set; }
        public Student Student { get; set; }
        public EnumRoleId RoleId { get; set; }
        public Image? Image { get; set; }
        public IFormFile? ImageFile { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime ModifiedDate { get; set; }
        public string UserName { get; set; }
        [DisplayName("Parola")]
        [Required(ErrorMessage = "Parola alanı zorunludur")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DisplayName("Parola Tekrar")]
        [Required(ErrorMessage = "Parola tekrar alanı zorunludur")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "İki parola aynı olmalıdır!")]
        public string RePassword { get; set; }
    }
}
