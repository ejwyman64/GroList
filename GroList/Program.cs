using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace GroList
{
    internal class Program
    {

        internal static string GetFileName()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "ListData.json");
            return fileName;
        }

        internal static List<ShoppingData> myShoppingLists = DeserializeData(GetFileName());


        internal static void Main(string[] args)
        {

            int option = 0;

            while ((option = Prompt(MainMenuOptions)) != MainMenuOptions.Length)
            {
                switch (option)
                {
                    case 1:
                        NewListMenu();
                        break;
                    case 2:
                        ShoppingData.SearchResults(searchResultsList: myShoppingLists);
                        break;
                    case 3:
                        AboutGroList();
                        break;
                }
            }
        }

        //============================================
        //------------Other Menus --------------------

        internal static void NewListMenu()
        {
            Console.Clear();

            DisplayGreeting();
            Console.WriteLine("******************** Create A New List ********************");

            string Value = string.Empty;

            int option = 0;


            while ((option = Prompt(NewListMenuOptions)) != NewListMenuOptions.Length)
            {

                switch (option)
                {
                    case 1:
                        OldCategories.GetCategories();
                        break;
                    case 2:
                        ShoppingData.NewListMaker();
                        break;
                }

            }


        }

        internal static void SavedSearch()
        {
            Console.Clear();

            int option = 0;
            while ((option = Prompt(SearchMenuOptions)) != SearchMenuOptions.Length)
            {
                switch (option)
                {
                    case 1:
                        //Categories
                        //   SearchResults();
                        break;
                }
            }

        }

        //Menu option arrays:
        internal static string[] MainMenuOptions =
    {
                "Make a new list: ",
                "Search for a saved list: ",
                "Learn about GroList: ",
                "To exit the program: "
            };

        internal static string[] NewListMenuOptions =
{
            "View Categories",
            "Start New List",
            "Exit"
        };

        internal static string[] SearchMenuOptions =
{
                "To search for a list: ",
                "To exit the program: "
        };


        //Need to move menu methods and all "UI" stuff to this file.

        internal static List<ShoppingData> DeserializeData(string fileName)
        {
            var data = new List<ShoppingData>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                data = serializer.Deserialize<List<ShoppingData>>(jsonReader);
            }
            return data;
        }

        internal static void AboutGroList()
        {
            bool validator = false;
            do
            {
                Console.Clear();
                DisplayGreeting();

                var fileName = "..\\..\\About.txt";

                string line;
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();

                Console.Write("Type '1' and then hit ENTER to return to main menu: ");
                string menuReturn = Console.ReadLine();

                if (menuReturn == "1")
                {
                    validator = true;
                }

            } while (!validator);
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
            Console.WriteLine("Hello, and welcome to GroList!");
            Console.WriteLine("_____________________________________________________________");

        }

        public static void DisplayMenu(string[] array)
        {
            Console.Clear();
            DisplayGreeting();
            Console.WriteLine("_____________________________________________________________");

            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"{i + 1}){array.ElementAt(i)}");
            }

        }

        internal static int Prompt(string[] array)
        {
            bool validate = false;
            int parsedUserInput = 0;
            string input = string.Empty;

            DisplayMenu(array);

            do
            {
                input = Program.PromptMessage($"Please select an option (1-{array.Length}): ");
                bool canParse = int.TryParse(input, out parsedUserInput);
                validate = canParse && parsedUserInput > 0 && parsedUserInput <= array.Length;

                if (!validate)
                {
                    Console.WriteLine("'" + input + $"' is not a valid option. Please provide a number 1-{array.Length}");
                }
            }
            while (!validate);


            return parsedUserInput;
        }

        //internal static void Search(myShoppingLists)
        //{
        //    foreach (var list in myShoppingLists)
        //    {
        //        if (list.name = name)
        //        {
        //            ShoppingData.PrintShoppingData();
        //        }
        //    }
        //}

    }
}
