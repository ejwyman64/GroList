﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;


namespace GroList
{
    internal class Program
    {
        //----- Locates the JSON file for the deserialization and serialization.
        internal static string GetFileName()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "ListData.json");
            return fileName;
        }

        //----- Calls the deserialization method on the JSON file and saves it to a list.
        internal static List<ShoppingData> myShoppingLists = DeserializeData(GetFileName());

        //----- Main Method! 
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
                        SavedSearch();
                        break;
                    case 3:
                        AboutGroList();
                        break;
                }
            }
        }

        //============================================
        //------------ New List Maker ----------------

        //Menu to make a new list and view categories.
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
                        GetCategories();
                        break;
                    case 2:
                        NewListMaker();
                        break;
                }

            }


        }
        //----- Really helpful variable that helped me exit out of the NewListMaker() method.
        internal static ConsoleKeyInfo key = new ConsoleKeyInfo();

        //Method to make a new list.
        internal static void NewListMaker()
        {
            bool validator = false;
            ShoppingData newShoppingData = new ShoppingData();
            do
            {
                Console.Clear();
                DisplayGreeting();

                //*************************************************
                //Get name of list and date.
                Console.Write("Enter new list name: ");
                newShoppingData.Name = Console.ReadLine().Trim();

                newShoppingData.Date = DateTime.Now.ToString("MM/dd/yyyy");
                newShoppingData.Items = NewItemMaker();
                myShoppingLists.Add(newShoppingData);
                List<ShoppingData> newList = new List<ShoppingData>
                {
                    newShoppingData
                };

                SerializeNewList(myShoppingLists, GetFileName());

                //*****************************************
                Console.WriteLine("_____________________________________________________________");
                ShoppingData.PrintShoppingData(newList);
                if (key.Key == ConsoleKey.Enter)
                {
                    validator = true;
                }


            } while (!validator);
        }
        //Method to add items to the new list.
        internal static List<ShoppingItem> NewItemMaker()
        {
            List<ShoppingItem> items = new List<ShoppingItem>();
            foreach (var cat in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine("********** " + cat + " ***********");
                bool validator = false;
                do
                {
                    var newItem = new ShoppingItem();

                    Console.Write("Add an item: ");

                    newItem.ItemName = Console.ReadLine();
                    newItem.Category = cat;
                    if (string.IsNullOrEmpty(newItem.ItemName))
                    {
                        validator = true;
                    }
                    else
                    {
                        validator = false;
                        items.Add(newItem);
                    }



                } while (!validator);
            }
            return items;
        }


        //============================================
        //------------ Search Methods ----------------
        //Menu for searching through the lists.
        internal static void SavedSearch()
        {
            Console.Clear();

            int option = 0;
            while ((option = Prompt(SearchMenuOptions)) != SearchMenuOptions.Length)
            {
                switch (option)
                {
                    case 1:
                        SearchResults(searchResultsList: myShoppingLists);
                        break;
                    case 2:
                        ShoppingData.PrintShoppingData(myShoppingData: myShoppingLists);
                        break;
                }
            }

        }
        //Method for searching through the lists.
        internal static void SearchResults(List<ShoppingData> searchResultsList)
        {
            bool validator = false;

            do
            {
                //Prompt for user to search.
                Console.Write("Search by the name of the list or the date (mm/dd/yyyy) the list was created: ");
                string searchQuery = Console.ReadLine();
                searchQuery = searchQuery.ToUpper();


                bool notFound = false;
                //Prints searched items out to console.
                foreach (var i in searchResultsList)
                {
                    if (searchQuery == i.Name.ToUpper() || searchQuery == i.Date)
                    {
                        //Prints out formatted list.
                        Console.WriteLine("_____________________________________________________________");
                        Console.WriteLine(i.Name);
                        Console.WriteLine(i.Date);
                        ShoppingItem.PrintItem(i.Items);
                        Console.WriteLine("_____________________________________________________________");
                        //--------------------------------------------------------------------------------
                        //Prompt to ask user if they would like to send list to printer or email.
                        //------------------------------------------------------------------------------
                        //Console.WriteLine("Would you like to email this list to yourself or print it out?");
                        //Console.Write("Type P to print, type E to email, or type both to do both: ");
                        //string printResponse = Console.ReadLine();
                        //if (printResponse == "E")
                        //{
                        //    //sends list to email of user.
                        //    Email();
                        //}
                        //else if (printResponse == "P")
                        //{
                        //    //sends list to local printer.
                        //    Print();
                        //}
                        //else if (printResponse == "EP" || printResponse == "PE")
                        //{
                        //    //sends list to both email and local printer.
                        //    Print();
                        //    Email();
                        //}
                        //else { Console.WriteLine("Please enter a valid response."); }

                        Console.WriteLine("Awesome! We found it!");
                        notFound = false;
                        break;

                    }
                    else
                    {
                        notFound = true;
                    }

                }
                if (notFound == true)
                {
                    Console.WriteLine("Sorry! GroList couldn't find that list.");

                }


                Console.Write("Would you like to search for another list? Y/N: ");
                var enterKey = Console.ReadKey();
                switch (enterKey.Key)
                {
                    case ConsoleKey.Y:
                        validator = false;
                        Console.WriteLine("");
                        break;
                    case ConsoleKey.N:
                        validator = true;
                        Console.WriteLine("");

                        break;
                }

            } while (!validator);
        }


        //============================================
        //------------ Menu option arrays ------------
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
                "To print out all saved lists to screen: ",
                "To exit the program: "
        };

        //----- Deserialize JSON file.
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
        //----- Serialize List to JSON file.
        internal static void SerializeNewList(List<ShoppingData> myShoppingLists, string fileName)
        {

            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, myShoppingLists);
            }
        }

        //----- Reading a text file to the console.
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

                Console.Write("Type ENTER to return to main menu: ");
                key = Console.ReadKey();

                if (key.Key == ConsoleKey.Enter)
                {
                    validator = true;
                }

            } while (!validator);
        }

        //----- Prints out the prompt message for the main menu.
        internal static string PromptMessage(string message)
        {
            Console.Write(message);
            String userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }

        //----- Greeting that always stays on top of the screen.
        internal static void DisplayGreeting()
        {
            Console.WriteLine("Hello, and welcome to GroList!");
            Console.WriteLine("_____________________________________________________________");

        }

        //----- Prints menu options to the screen.
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

        //----- Standard prompt method to cycle through the menu options.
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

        //----- Prints the categories in the Categoy Enum to the screen.
        internal static void GetCategories()
        {
                Console.Clear();
                DisplayGreeting();

                foreach (var cat in Enum.GetNames(typeof(Category)))
                {
                    Console.WriteLine(cat);
                    Console.WriteLine("-----------------------------------------");
                }

                Console.Write("Hit ENTER to return to main menu: ");
                Console.ReadKey();
        }

        //internal static void Email()
        //{
        //    Console.WriteLine("Your list has been emailed.");
        //}

        //internal static void Print()
        //{
        //    Console.WriteLine("Your List has been sent to your local printer.");

        //}

    }
}
