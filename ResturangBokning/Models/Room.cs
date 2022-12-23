using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen1.Models
{
    public class Room
    {
        public int Id { get; set; }
        public int? RoomNumber { get; set; }
        public int NumberOfSitis { get; set; }
        public int NumberOfPeople { get; set; }

        public bool WhiteBoard { get; set; }
        public bool Projector { get; set; } 
        public bool Internet { get; set; }

        public ICollection<Person>? Persons { get; set; }

    }
}
