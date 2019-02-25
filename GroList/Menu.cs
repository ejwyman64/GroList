using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class Menu
    {
        static string[] _options = new string[]
            {
                "Make a new list: ",
                "Search for a saved list: ",
                "View categories: ",
                "Learn about GroList: ",
                "To exit the program: "
            };

        static void DisplayMenu()
        {

            Console.WriteLine("_________________________________________________________");

            for (int i = 0; i < _options.Length; i++)
            {
               Console.WriteLine($"{i + 1}){_options[i]}");
            }

        }

        internal static string PromptMessage(string message)
        {
            Console.Write(message);
            String userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim(); 
        }


        internal static void DisplayGreeting()
        {
            Console.WriteLine("Hello, and welcome to GroList! Select a menu option below.");
            Console.WriteLine("_________________________________________________________");

        }

        internal static int Prompt()
        {
            bool validate = false;
            int parsedUserInput = 0;
            string input = string.Empty;

            DisplayMenu();

            do
            {
                input = PromptMessage($"Please select an option (1-{_options.Length}): ");
                bool canParse = int.TryParse(input, out parsedUserInput);
                validate = canParse && parsedUserInput > 0 && parsedUserInput <= 5;

                if (!validate)
                {
                    Console.WriteLine("'" + input + "' is not a valid option. Please provide a number 1-5");
                }
            }
            while (!validate);


            return parsedUserInput;
        }



    }
}
