using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;

namespace GroList
{
    class Program
    {
        static void Main(string[] args)
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "ListData.json");

            //need to debug.
            var myShoppingLists = DeserializeData(fileName);

            int option = 0;
            while ((option = Menu.Prompt()) != Menu.MainMenuOptions.Length)
            {
                switch (option)
                {
                    case 1:
                        ListMenu.NewListMenu();
                        break;
                    case 2:
                        Search.SavedSearch();
                        break;
                    case 3:
                        AboutGroList();
                        break;
                }
            }
        }

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
                Menu.DisplayGreeting();

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

        Search(myShoppingList)
        {
            foreach (var list in myShoppingList)
            {
                if (list.name = neame)
                {
                    list.PrintShoppingData();
                }
            }
        }

    }
}
