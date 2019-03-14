using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class Menu
    {
        internal static string[] MainMenuOptions =
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

            for (int i = 0; i < MainMenuOptions.Length; i++)
            {
                Console.WriteLine($"{i + 1}){MainMenuOptions[i]}");
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
                input = Program.PromptMessage($"Please select an option (1-{MainMenuOptions.Length}): ");
                bool canParse = int.TryParse(input, out parsedUserInput);
                validate = canParse && parsedUserInput > 0 && parsedUserInput <= MainMenuOptions.Length;

                if (!validate)
                {
                    Console.WriteLine("'" + input + $"' is not a valid option. Please provide a number 1-{MainMenuOptions.Length}");
                }
            }
            while (!validate);


            return parsedUserInput;
        }


    }
}
