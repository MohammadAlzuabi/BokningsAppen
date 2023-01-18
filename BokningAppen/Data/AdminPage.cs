using BokningsAppen1.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace BokningsAppen1.Data
{
    internal class AdminPage
    {
        public enum AdminMenu
        {
            Lägg_till_ett_nytt_rum,
            Ändra_detaljer_i_rummet,
            Ändra_platser_på_rummet,
            Statiskt_page,
            Tillbaka_till_startsidan,

        }

        public AdminPage()
        {

        }
        public static void RunProgram()
        {
            bool running = true;
            while (running)
            {
                string prompt = "Hej Admin! Vad vill du administrera?\n¤===============================¤";
                string[] options = Enum.GetNames(typeof(AdminMenu));

                Menu adminMenu = new Menu(prompt, options);
                int index = adminMenu.Run();
                switch (index)
                {
                    case 0:
                        Console.Clear();
                        Console.WriteLine("===========\nDetta är alla rum som du har skapat");
                        RoomManager.GetAllRooms();
                        CreateRoom();
                        break;
                    case 1:
                    case 2:
                        Console.Clear();
                        AlterRoom(index);
                        break;
                    case 3:
                        StatistikPage.RunProgram();
                        break;
                    case 4:
                        Console.Clear();
                        StatistikPage.RunProgram();
                        StartPage.Run();
                        break;
                }
                Console.ReadKey();
            }
        }
        public static void CreateRoom() // Skapa ett rum
        {

            Console.WriteLine("Lägg till ett nytt rummsnummer: ");
            var addedRom = int.Parse(Console.ReadLine());
            Console.WriteLine("Lägg till detaliler för rummet: ");
            var romDetails = Console.ReadLine();
            //Console.WriteLine("Ange antal platser");
            Console.WriteLine("Lägg till antal platser i rummet: ");
            var seats = int.Parse(Console.ReadLine());
            Console.Clear();
            using (var db = new MyDbContext())
            {
                var newRoom = new ConferenceRoom
                {
                    RoomNumber = addedRom,
                    Detalil = romDetails,
                    NumberOfSitis = seats,

                };
                Console.WriteLine($"Du har skapat ett rum med följande: RUM<{addedRom}> detaliler <{romDetails}> Antal platser <{seats}>");
                Console.WriteLine("Tryck valfri tangent för att spara");
                Console.ReadKey(true);
                db.Add(newRoom);
                db.SaveChanges();
                Console.Clear();
                RunProgram();
            }
        }
        public static void AlterRoom(int index) // Lägg in eller ändra objekt
        {
            RoomManager.GetAllRooms();
            using (var db = new MyDbContext())
            {

                Console.WriteLine("Ange rummsnummer du vill ändra på:");
                var roomNumber = int.Parse(Console.ReadLine());
                var alterRoom = (from a in db.Rooms
                                 where a.RoomNumber == (roomNumber)
                                 select a).SingleOrDefault();

                switch (index)
                {
                    case (int)AdminMenu.Ändra_detaljer_i_rummet:
                        Console.WriteLine("Ändra det nya detaljer för ruummet:");
                        var newDetail = Console.ReadLine();
                        alterRoom.Detalil = newDetail;
                        Console.WriteLine($"\nDu har lagt in {newDetail} i rum nummer {roomNumber}");
                        break;
                    case (int)AdminMenu.Ändra_platser_på_rummet:
                        Console.WriteLine("Ange det nya platser för ruummet:");
                        var newPlaces = int.Parse(Console.ReadLine());
                        alterRoom.NumberOfSitis = newPlaces;
                        Console.WriteLine($"\nDu har lagt in {newPlaces} nya platser för rum nummer {roomNumber}");
                        break;
                }
                db.SaveChanges();
                Console.WriteLine("=========\nTryck valfri tangent för att försätta");
            }
        }
    
    }
}
