using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Newtonsoft.Json;
using System.Net.Mail;


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
        internal  List<ShoppingData> myShoppingLists = DeserializeData(GetFileName());

        //----- Main Method! 
        internal static void Main(string[] args)
        {
            Program program = new Program();

            int option = 0;

            while ((option = program.Prompt(program.MainMenuOptions)) != program.MainMenuOptions.Length)
            {
                switch (option)
                {
                    case 1:
                        program.NewListMenu();
                        break;
                    case 2:
                        program.SavedSearch();
                        break;
                    case 3:
                        program.AboutGroList();
                        break;
                }
            }
        }

        //============================================
        //------------ New List Maker ----------------

        //Menu to make a new list and view categories.
        internal void NewListMenu()
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
        internal void NewListMaker()
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
        internal List<ShoppingItem> NewItemMaker()
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
        internal void SavedSearch()
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
        internal void SearchResults(List<ShoppingData> searchResultsList)
        {
            bool validator = false;


            do
            {
                //Prompt for user to search.
                Console.Write("Search by the name of the list or the date (mm/dd/yyyy) the list was created: ");
                string searchQuery = Console.ReadLine();
                searchQuery = searchQuery.ToUpper();

                List<ShoppingData> EmailedList = new List<ShoppingData>();


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

                        EmailedList.Add(i);

                        Console.WriteLine("Awesome! We found it!");
                        validator = true;
                        Console.Write("Would you like to email this list to yourself? Y/N: ");
                        var exitKey = Console.ReadKey();
                        switch (exitKey.Key)
                        {
                            case ConsoleKey.Y:
                                Console.WriteLine(" ");
                                Email(EmailedList);
                                break;
                            case ConsoleKey.N:
                                Console.WriteLine(" ");
                                break;
                        }

                    }
                    else
                    {
                        notFound = true;
                    }

                }
                if (notFound == true && validator == false)
                {
                    Console.WriteLine("Sorry! GroList couldn't find that list.");
                }
                else
                {
                    break;
                }


                //Console.Write("Would you like to search for another list? Y/N: ");
                //var enterKey = Console.ReadKey();
                //switch (enterKey.Key)
                //{
                //    case ConsoleKey.Y:
                //        validator = false;
                //        Console.WriteLine("");
                //        break;
                //    case ConsoleKey.N:
                //        validator = true;
                //        Console.WriteLine("");
                //        break;
                //}

            } while (!validator);
        }


        //============================================
        //------------ Menu option arrays ------------
        internal string[] MainMenuOptions =
    {
                "Make a new list: ",
                "Search for a saved list: ",
                "Learn about GroList: ",
                "To exit the program: "
            };

        internal string[] NewListMenuOptions =
{
            "View Categories",
            "Start New List",
            "Exit"
        };

        internal string[] SearchMenuOptions =
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
        internal void SerializeNewList(List<ShoppingData> myShoppingLists, string fileName)
        {

            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, myShoppingLists);
            }
        }

        //----- Reading a text file to the console.
        internal void AboutGroList()
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
        internal string PromptMessage(string message)
        {
            Console.Write(message);
            String userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }

        //----- Greeting that always stays on top of the screen.
        internal void DisplayGreeting()
        {
            Console.WriteLine("Hello, and welcome to GroList!");
            Console.WriteLine("_____________________________________________________________");

        }

        //----- Prints menu options to the screen.
        public void DisplayMenu(string[] array)
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
        internal int Prompt(string[] array)
        {
            bool validate = false;
            int parsedUserInput = 0;
            string input = string.Empty;

            DisplayMenu(array);

            do
            {
                input = PromptMessage($"Please select an option (1-{array.Length}): ");
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
        internal void GetCategories()
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

        internal static void Email(List<ShoppingData> emailList)
        {
            string emailBody = string.Empty;

            //converting list items into strings so that they are readable by humans
            //Also adding each part of the list to the emailBody string so that it can be sent.
            foreach (var thing in emailList)
            {
                thing.Name.ToString();
                emailBody = $"Name: {thing.Name}" + Environment.NewLine;
                thing.Date.ToString();
                emailBody += $"Date: {thing.Date}" + Environment.NewLine;
                emailBody += $"Items: " + Environment.NewLine;

                foreach (var i in thing.Items)
                {
                    if (i.ItemName != null)
                    {
                        i.Category.ToString();
                        emailBody += $"{i.Category} ";
                        i.ItemName.ToString();
                        emailBody += $"{i.ItemName} " + Environment.NewLine;

                    }
                }
            }

            Console.WriteLine(emailBody);

            Console.Write("Please enter your email address: ");
            string userEmail = Console.ReadLine();
            MailMessage mail = new MailMessage();
            SmtpClient SmtpServer = new SmtpClient("smtp.gmail.com");
            mail.From = new MailAddress("ejpink4@gmail.com");
            mail.To.Add($"{userEmail}");
            mail.Subject = "New GroList";
            mail.Body = emailBody;

            SmtpServer.Port = 587;
            SmtpServer.Credentials = new System.Net.NetworkCredential("GroListApp19", "GroList@2019");
            SmtpServer.EnableSsl = true;

            SmtpServer.Send(mail);

            Console.WriteLine("Your list has been emailed. Please hit ENTER to go back to the search menu.");
            key = Console.ReadKey();
            switch (key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("");
                    break;
            }
        }

        //internal static void Print()
        //{
        //    Console.WriteLine("Your List has been sent to your local printer.");

        //}

    }
}
