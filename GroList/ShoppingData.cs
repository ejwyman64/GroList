using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;


namespace GroList
{
    public class ShoppingData
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public string Date { get; set; }

        [JsonProperty("items")]
        public List<ShoppingItem> Items { get; set; }


        internal static void SerializeNewList(List<ShoppingData> myShoppingLists, string fileName)
        {

            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, myShoppingLists);
            }
        }

        internal static void PrintShoppingData(List<ShoppingData> myShoppingData)
        {
            foreach (var data in myShoppingData)
            {
                Console.WriteLine(data.Name);
                Console.WriteLine(data.Date);
                ShoppingItem.PrintItem(data.Items);
            }
        }

        internal static void NewListMaker()
        {
            ShoppingData newShoppingData = new ShoppingData();
            bool validator = false;
            do
            {
                Console.Clear();
                Program.DisplayGreeting();

                //*************************************************
                //Get name of list and date.
                Console.Write("Enter new list name: ");
                newShoppingData.Name = Console.ReadLine().Trim();

                newShoppingData.Date = DateTime.Now.ToString("MM/dd/yyyy");
                newShoppingData.Items = ShoppingItem.NewItemMaker();
                Program.myShoppingLists.Add(newShoppingData);
                List<ShoppingData> newList = new List<ShoppingData>
                {
                    newShoppingData
                };

                //*****************************************
                Console.WriteLine("_____________________________________________________________");
                PrintShoppingData(newList);

                //Add name and date to myNewShoppingList
                SerializeNewList(Program.myShoppingLists, Program.GetFileName());

                Console.Write("Please hit ENTER key to return to main menu");
                string completeAnswer = Console.ReadLine().Trim().ToUpper();
                if (completeAnswer == "")
                {
                    validator = true;
                }

            } while (!validator);
        }

        internal static void SearchResults(List<ShoppingData> searchResultsList)
        {
            bool validator = false;


            //Prompt for user to search.
            Console.Write("Search by the name of the list or the date (mm/dd/yyyy) the list was created: ");
            string searchQuery = Console.ReadLine();
            searchQuery = searchQuery.ToUpper();


            do
            {
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
                        //validator = false;
                    }
                    else
                    {
                        Console.Write("To try again hit the ENTER key: ");
                        var x = Console.ReadKey().Key;
                        if (x == ConsoleKey.Enter)
                        {
                            validator = true;
                        }

                    }
                }
            } while (!validator);
        }

        internal static void Email()
        {
            Console.WriteLine("Your list has been emailed.");
        }

        internal static void Print()
        {
            Console.WriteLine("Your List has been sent to your local printer.");

        }

    }
}
