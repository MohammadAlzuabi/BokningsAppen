using BokningsAppen1.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen1.Data
{
    internal class RoomManager
    {
        public static void GetAllRooms()
        {
            Console.WriteLine( "=======\nRUM\n¤==========================================================¤");
            using (var db = new MyDbContext())
            {
                foreach (var room in db.Rooms.Select(r => r))
                {
                    Console.WriteLine($"ID {room.Id} : Rumnummer[{room.RoomNumber}] med {room.NumberOfSitis} antal platser som har {room.Detalil} ");
                }
            }
            Console.WriteLine("¤==============================================================¤");

        }
    }
}
