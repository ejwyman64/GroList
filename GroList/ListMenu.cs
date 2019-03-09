using System;

namespace GroList
{
    class ListMenu
    {
        internal static string[] Options =
        {
            "Produce",
            "Dairy",
            "Bakery",
            "Meat",
            "FrozenFood",
            "CannedFood",
            "Snacks",
            "GrainsCereal",
            "PantryCondiments",
            "Beverages",
            "PetSupplies",
            "PaperPlastic",
            "CleaningSupplies",
            "HealthBeauty",
            "Other",
            "Exit List"
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
                        Value = "Produce";
                        NewList.AddItems();
                        break;
                    case 2:
                        Value = "Dairy";
                        NewList.AddItems();
                        break;
                    case 3:
                        Value = "Bakery";
                        NewList.AddItems();
                        break;
                    case 4:
                        Value = "Meat";
                        NewList.AddItems();
                        break;
                    case 5:
                        Value = "Frozen food";
                        NewList.AddItems();
                        break;
                    case 6:
                        Value = "Canned food";
                        NewList.AddItems();
                        break;
                    case 7:
                        Value = "Snacks";
                        NewList.AddItems();
                        break;
                    case 8:
                        Value = "Grains and cereal";
                        NewList.AddItems();
                        break;
                    case 9:
                        Value = "Pantry and condiments";
                        NewList.AddItems();
                        break;
                    case 10:
                        Value = "Beverages";
                        NewList.AddItems();
                        break;
                    case 11:
                        Value = "Pet supplies";
                        NewList.AddItems();
                        break;
                    case 12:
                        Value = "Paper or plastic";
                        NewList.AddItems();
                        break;
                    case 13:
                        Value = "cleaning supplies";
                        NewList.AddItems();
                        break;
                    case 14:
                        Value = "Health and beauty";
                        NewList.AddItems();
                        break;
                    case 15:
                        Value = "Other";
                        NewList.AddItems();
                        break;
                }
            }


        }
    }
}
