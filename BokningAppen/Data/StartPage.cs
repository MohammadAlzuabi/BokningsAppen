using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BokningsAppen1.Data
{

    internal class StartPage
    {
        public enum UserCategory
        {
            Logga_in_som_Admin,
            Logga_in_som_Kund,
            Avsluta_programet
        }
        public StartPage()
        {

        }

        public static void Run()
        {
            string prompt = ("Välkommen till bokning av konferensrum");
            Console.WriteLine();
            string[] startOptions = Enum.GetNames(typeof(UserCategory));
            Menu startMenu = new Menu(prompt, startOptions);
            int selectedIndex = startMenu.Run();
            switch (selectedIndex)
            {
                case 0:
                    AdminPage.RunProgram();
                    break;
                case 1:
                   BookingPage.RunProgram();
                    break;
                case 2:
                    Environment.Exit(0);
                    break;
            }
        }

    }
    
}
