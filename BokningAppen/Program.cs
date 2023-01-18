using BokningsAppen1.Data;
using BokningsAppen1.Models;
using System.Security.Principal;

namespace BokningsAppen
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            StartPage.Run();
            //StatistikPage.RunProgram();

        }
    }
}