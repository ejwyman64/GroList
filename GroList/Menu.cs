using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class Menu
    {
        internal static string[] _options = new string[]
            {
                "Make a new list: ",
                "Search for a saved list: ",
                "View categories: ",
                "Learn about GroList: ",
                "To exit the program: "
            };

        internal static void DisplayOptions()
        {
            for (int i = 0; i < _options.Length; i++)
            {
                Console.WriteLine($"{_options[i]}{i + 1}");
            }
        }

        internal static string MenuInput(string message)
        {
            Console.Write(message);
            string userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }

        internal static int Prompt()
        {
            bool valid = false;
            int parsedOption = 0;
            string option = string.Empty;

            DisplayOptions();
            do
            {
                option = MenuInput($"Please select an option (1-{_options.Length}): ");
                bool canParse = int.TryParse(option, out parsedOption);
                valid = canParse && parsedOption > 0 && parsedOption <= 5;

                if (!valid)
                {
                    Console.WriteLine("'" + option + "' is not a valid option. Please provide a number 1-3");
                }

            }
            while (!valid);

            return parsedOption;
        }


        internal static void DisplayGreeting()
        {
            Console.WriteLine("Hello, and welcome to GroList! Select a menu option below.");
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~");

        }

    }
}
