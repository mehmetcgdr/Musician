using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Musician.Entity.Concrete
{
    public class Card
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public decimal? Price { get; set; }
        public string Description { get; set; }
        public string Title { get; set; }
        public string City { get; set; }
        public EnumState EnumState { get; set; }
        public string EnstrumentName { get; set; }


    }
}
public enum EnumState
{
    AtHome=0,
    Online=1
}