using BokningsAppen1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Reflection.PortableExecutable;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BokningsAppen1.Data
{
    public class BookingPage
    {
        public enum StatistikMenu
        {
            Boka_ett_rum,
            Tillbaka_till_huvudmeny,
        }
        public BookingPage()
        {

        }

        public static void RunProgram()
        {
            bool running = true;
            while (running)
            {
                string prompt = "Hej Kunden! Vad vill du göra?\n¤===============================¤";
                string[] options = Enum.GetNames(typeof(StatistikMenu));
                Menu bookingMenu = new Menu(prompt, options);
                int index = bookingMenu.Run();
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        RoomManager.GetAllRooms();
                        Console.WriteLine("Ange vecka nummer[1-4]: ");
                        int weekNumber = int.Parse(Console.ReadLine());
                        ShowBookingList(weekNumber);
                        Console.WriteLine("Ange vilken dag vill du boka : ");
                        string day = Console.ReadLine();
                        BookingRoom(weekNumber, day);
                        break;
                    case 1:
                        StartPage.Run();
                        break;
                }
                Console.ReadKey();
            }
        }

        public static void BookingRoom(int weekNumber, string day)
        {

            using (var db = new MyDbContext())
            {
                var booking = (from b in db.Bookings
                               where b.WeekNumber == weekNumber && b.DayofWeek == day
                               select b).SingleOrDefault();

                Console.WriteLine("Ange ditt namn:");
                var name = Console.ReadLine();
                Console.WriteLine("Ange namn på ditt företag:");
                var company = Console.ReadLine();
                Console.WriteLine("Ange rums-Id du vill boka i:");
                var roomId = int.Parse(Console.ReadLine());
                if (booking != null)
                {
                    if (booking.Empty == false)
                    {
                        booking.Company = company;
                        booking.FullName = name;
                        booking.Empty = true;
                        booking.RoomId = roomId;

                        
                    }
                    else if (booking.Empty == true)
                    {
                        
                        Console.WriteLine("==========\nOPS!!\nDu kan inte boka det rummet eftersom den är upptagen\n=============================");
                    }
                }
                db.SaveChanges();
                Console.WriteLine("=========\nTryck valfri tangent för att försätta");
                Console.ReadKey(true);
                Console.Clear();
                RunProgram();
            }

        }

        public static void ShowBookingList(int weekNumber)
        {
            //int weeknum = ConsoleUtils.GetIntFromUser("Ange vecka nummer: ");
            Console.WriteLine("============\nBokning lista\n¤=========================¤");
            using (var db = new MyDbContext())
            {
                var querie = from b in db.Bookings
                             where b.WeekNumber == weekNumber
                             select b;

                foreach (var lista in querie)
                {
                    Console.WriteLine($"{lista.DayofWeek}\t {(lista.Empty == true ? lista.FullName : "{0}")}\t RUM {lista.RoomId} ");
                }
                Console.WriteLine("¤==============================¤");
                Console.WriteLine("\nTryck j för att gå tillbaka till bokningsida och ändra vecka annars tryck n för att försätta: ");
                var backToMenu = Console.ReadLine();
                if (backToMenu == "j")
                {
                    Console.Clear();
                    RoomManager.GetAllRooms();
                    RunProgram();

                }
                else
                {
                    Console.WriteLine("Försätt med bokningen");
                }
            }
        }


        public static void CreateWeeks()
        {
            using (var db = new Models.MyDbContext())
            {
                db.AddRange(
                //Vecka1
                new Models.Booking { DayofWeek = "Måndag", WeekNumber = 1, },
                new Models.Booking { DayofWeek = "Tisdag", WeekNumber = 1, },
                new Models.Booking { DayofWeek = "Onsdag", WeekNumber = 1, },
                new Models.Booking { DayofWeek = "Torsdag", WeekNumber = 1, },
                new Models.Booking { DayofWeek = "Fredag", WeekNumber = 1, },
                new Models.Booking { DayofWeek = "Lördag", WeekNumber = 1, },
                new Models.Booking { DayofWeek = "Söndag", WeekNumber = 1, },
                //Vecka2
                new Models.Booking { DayofWeek = "Måndag", WeekNumber = 2, },
                new Models.Booking { DayofWeek = "Tisdag", WeekNumber = 2, },
                new Models.Booking { DayofWeek = "Onsdag", WeekNumber = 2, },
                new Models.Booking { DayofWeek = "Torsdag", WeekNumber = 2, },
                new Models.Booking { DayofWeek = "Fredag", WeekNumber = 2, },
                new Models.Booking { DayofWeek = "Lördag", WeekNumber = 2, },
                new Models.Booking { DayofWeek = "Söndag", WeekNumber = 2, },
                //Vecka3
                new Models.Booking { DayofWeek = "Måndag", WeekNumber = 3, },
                new Models.Booking { DayofWeek = "Tisdag", WeekNumber = 3, },
                new Models.Booking { DayofWeek = "Onsdag", WeekNumber = 3, },
                new Models.Booking { DayofWeek = "Torsdag", WeekNumber = 3, },
                new Models.Booking { DayofWeek = "Fredag", WeekNumber = 3, },
                new Models.Booking { DayofWeek = "Lördag", WeekNumber = 3, },
                new Models.Booking { DayofWeek = "Söndag", WeekNumber = 3, },
                //Vecka4
                new Models.Booking { DayofWeek = "Mån", WeekNumber = 4, },
                new Models.Booking { DayofWeek = "Tis", WeekNumber = 4, },
                new Models.Booking { DayofWeek = "Ons", WeekNumber = 4, },
                new Models.Booking { DayofWeek = "Tor", WeekNumber = 4, },
                new Models.Booking { DayofWeek = "Fre", WeekNumber = 4, },
                new Models.Booking { DayofWeek = "Lör", WeekNumber = 4, },
                new Models.Booking { DayofWeek = "Sön", WeekNumber = 4, }

               );
                db.SaveChanges();
            }
        }

    }
}
