using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen.Models
{
    public class Person
    {
        public int Id { get; set; }
        public string? Name { get; set; }

        public string? Adress { get; set; }

        public string? Company { get; set; }

        public int ConfernseRoomId { get; set; }
        public virtual Room? ConferenceRoom { get; set; }   
        //public ICollection<ConferenceRoom>? Rooms { get; set; }
    }
}
