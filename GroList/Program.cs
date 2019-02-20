using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello! Would you like to see the menu? Type YES to see the menu, type NO to quit:   ");
             string input = Console.ReadLine();

            Console.WriteLine(input);

            //If statement to display main menu
            if(input == "YES")
            {
                MainMenu();
            }
            else if(input == "NO")
            {
                Environment.Exit(0);
            }
            else
            {
                //there has to be a more straightforward way of writing this out...
                Console.Write("Please input YES or NO:   ");
                string homeinput = Console.ReadLine();
                if (homeinput == "YES")
                { MainMenu(); }
                else if (input == "NO")
                { Environment.Exit(0); }
                else
                {
                    Console.Write("Please input YES or NO:   ");
                }
            }
            //My problem right now is that the program only goes through the if statement once, then anything else you type just closes the program.
            //I need to be able to loop through the if statement until either the user types YES and goes to the main menu or they type NO and exit the program.

            //Main menu needs to be selectable to print out other options.
            //Categories option should print out a list of categories. 
            //New list should start the user on creating a new list.
            //Saved lists should print out saved lists sorted newest to oldest. Maybe they should be able to choose a date range or specific date?

            Console.Read();
        }

        private static void MainMenu()
        {
            Console.WriteLine("Categories, New List, Saved Lists");
        }
    }
}
