using Musician.Entity.Concrete.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class Request
    {
        public int Id { get; set; }
        //public int TeacherId { get; set; }
        public Teacher Teacher { get; set; }
        //public string StudentId { get; set; }
        public Student Student { get; set; }
        public User User { get; set; }
        public DateTime OrderDate { get; set; }
        public Card Card { get; set; }
        public int CardId { get; set; }
        public EnumOrderState OrderState { get; set; }
        public decimal? Price { get; set; }
        public string? Message { get; set; }


    }
}
public enum EnumOrderState
{
    Waiting=0,
    Approved=1,
    Completed=2,
    Ignored=3
    
}