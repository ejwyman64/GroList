using System;

namespace GroList
{
    class ListMenu
    {
        internal static string[] Options =
        {
            "View Categories",
            "Start New List",
            "Exit"
        };

        public static void DisplayMenu()
        {

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


        internal static void NewListMenu()
        {
            Console.Clear();

            Menu.DisplayGreeting();
            Console.WriteLine("******************** Create A New List ********************");

            string Value = string.Empty;

            int option = 0;


            while ((option = Prompt()) != Options.Length)
            {

                switch (option)
                {
                    case 1:
                        Categories.GetCategories();
                        break;
                    case 2:
                        NewList.NewListMaker();
                        break;
                }

            }


        }
    }
}
