using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class Menu
    {
        internal static string[] Options =
            {
                "Make a new list: ",
                "Search for a saved list: ",
                "Learn about GroList: ",
                "To exit the program: "
            };

        internal static void DisplayGreeting()
        {
            Console.WriteLine("Hello, and welcome to GroList!");
            Console.WriteLine("_____________________________________________________________");

        }

        public static void DisplayMenu()
        {
            Console.Clear();
            DisplayGreeting();
            Console.WriteLine("_____________________________________________________________");

            for (int i = 0; i < Options.Length; i++)
            {
                Console.WriteLine($"{i + 1}){Options[i]}");
            }

        }


        internal static int Prompt()
        {
            bool validate = false;
            int parsedUserInput = 0;
            string input = string.Empty;

            DisplayMenu();

            do
            {
                input = Other.PromptMessage($"Please select an option (1-{Options.Length}): ");
                bool canParse = int.TryParse(input, out parsedUserInput);
                validate = canParse && parsedUserInput > 0 && parsedUserInput <= Options.Length;

                if (!validate)
                {
                    Console.WriteLine("'" + input + $"' is not a valid option. Please provide a number 1-{Options.Length}");
                }
            }
            while (!validate);


            return parsedUserInput;
        }


    }
}
