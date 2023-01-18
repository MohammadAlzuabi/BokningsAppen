using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen1.Models
{
    public class ConferenceRoom
    {
        public int Id { get; set; }
        public int? RoomNumber { get; set; }
        public int? NumberOfSitis { get; set; }
        public string? Detalil { get; set; }
        public ICollection<Booking>? Bookings { get; set; }

    }
}
