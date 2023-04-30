using Microsoft.AspNetCore.Mvc.Rendering;
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
        public decimal? Price { get; set; }
        public string OwnDescription { get; set; }
        public string Description { get; set; }
        public string City { get; set; }
        //public List<SelectListItem>? StatusSelectList { get; set; } = new List<SelectListItem>();
        public string EnstrumentName { get; set; }
        public Enstrument Enstrument { get; set; }
        public string NormalizedEnstrumentName { get; set; } = "";
        public virtual Image Image { get; set; }
        public int TeacherId { get; set; }

    }
}
