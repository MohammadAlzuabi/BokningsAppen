using BokningsAppen1.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Cryptography.X509Certificates;

namespace BokningsAppen1.Data
{
    public class StatistikPage
    {

        public enum StatistikMenu
        {
            Sök_personer_efter_sitt_företag,
            Vissa_alla_namn_med_bokstav_ordning,
            Visa_alla_rum_som_är_bokade,
            Visa_Lediga_rum,
            Tillbaka_till_huvudmeny,
        }
        public StatistikPage()
        {

        }

        public static void RunProgram()
        {
            bool running = true;
            while (running)
            {
                string prompt = "Välkommen till StatistikPage\n¤===============================¤";
                string[] options = Enum.GetNames(typeof(StatistikMenu));
                Menu statistikMenu = new Menu(prompt, options);
                int selectedIndex = statistikMenu.Run();
                switch (selectedIndex)
                {
                    case 0:
                        FindThePerson();
                        break;
                    case 1:
                        ShowAndSortCoustmerName();
                        break;
                    case 2:
                        ShowBokedRoom();
                        break;
                    case 3:
                        ShowEmptyRoom();
                        break;
                    case 4:
                        StartPage.Run();
                        break;
                }
                Console.ReadKey();
            }
        }
        public static void ShowAndSortCoustmerName()
        {
            using (var db = new MyDbContext())
            {
                foreach (var show in db.Bookings.OrderBy(n => n.FullName).Where(n => n.FullName != null))
                {
                    Console.WriteLine($"================\nNamn {show.FullName}\n \t¤Företag {show.Company}");
                }
                Console.WriteLine("=========\nTryck valfri tangent för att försätta");
            }
        }


        public static void FindThePerson()
        {
            using (var db = new MyDbContext())
            {
                var querie = from b in db.Bookings
                             where b.Company != null
                             select b;
                foreach (var c in querie)
                {
                    Console.WriteLine($"==========\nFöretag: {c.Company}");

                }
                
            }
            using (var context = new MyDbContext())
            {

                Console.WriteLine("\nSkriv in namnet på företag: ");
                var company = Console.ReadLine();
                foreach (var list in context.Bookings.Where(c => c.Company == company))
                {
                    Console.WriteLine($"===================\nNamn: {(list.Empty == true ? list.FullName : "")}\nFöretag: {list.Company}");
                }
                Console.WriteLine("=========\nTryck valfri tangent för att försätta");
            }
        }
        public static void ShowBokedRoom()
        {
            using (var db = new MyDbContext())
            {
                foreach (var list in db.Bookings.Include(r => r.Room).Where(e => e.Empty == true))
                {
                    Console.WriteLine($"===================\nVecka: {list.WeekNumber}\nDag: {list.DayofWeek}\nNamn: {(list.Empty == true ? list.FullName : "")}\nRum-Id: {list.RoomId}");
                }
                Console.WriteLine("=========\nTryck valfri tangent för att försätta");
            }
        }

        public static void ShowEmptyRoom()
        {
            Console.WriteLine("========================\nAnge vecka nummer[1-4]");
            int weekNum = int.Parse(Console.ReadLine());
            bool empty = false;
            using(var db = new MyDbContext())
            {
                //var result = from w in db.Bookings
                //             where w.WeekNumber == weekNum && w.
                foreach (var l in db.Bookings.Where(w=>w.WeekNumber == weekNum && w.Empty == empty))
                {
                    Console.WriteLine($"====================\n{l.DayofWeek} {(l.Empty == false? "[Ledigt]" : "")}");
                }
                Console.WriteLine("=========\nTryck valfri tangent för att försätta");
            }
        }

    }
}
