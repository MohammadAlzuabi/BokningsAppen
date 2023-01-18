using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen1.Models
{
    public class Booking
    {
        public int Id { get; set; }

        public string? FullName { get; set; }
        public string? Company { get; set; }
        public int? WeekNumber { get; set; }
        public string? DayofWeek { get; set; }
        public bool Empty { get; set; }
        
        public int? RoomId { get; set; }
        public virtual ConferenceRoom? Room { get; set; }


    }

}
