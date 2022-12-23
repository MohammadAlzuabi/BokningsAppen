using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int NumberOfSits { get; set; }
        public int NumberOfPeople { get; set; }

        public bool Whiteboard { get; set; }
        public bool Projector { get; set; }
        public bool Internet { get; set; }

        public ICollection<Person>? Persons { get; set; }

    }
}
