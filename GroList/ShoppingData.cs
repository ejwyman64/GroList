using System;
using System.Collections;
using System.Collections.Generic;
using Newtonsoft.Json;


namespace GroList
{
    public class ShoppingData : IEnumerable
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public string Date { get; set; }

        [JsonProperty("items", Required = Required.Always)]
        public List<ShoppingItem> Items { get; set; }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
        }

        //this will be called in search and will print out one list.

        internal static void SearchResults()
        {
            var shoppingList = new ShoppingData();

            //Prompt for user to search.
            Console.Write("Search by the name of the list or the date (mm/dd/yyyy) the list was created: ");
            string searchQuery = Console.ReadLine();
            searchQuery = searchQuery.ToUpper();

            bool validator = false;

            do
            {

                //Prints searched items out to console.
                foreach (var i in shoppingList)
                {
                    if (searchQuery == shoppingList.Name.ToUpper() || searchQuery == shoppingList.Date)
                    {

                        //Prints out formatted list.
                        Console.WriteLine("_____________________________________________________________");
                        Console.WriteLine(shoppingList.Name);
                        Console.WriteLine(shoppingList.Date);
                        ShoppingItem.PrintItem();

                        //Prompt to ask user if they would like to send list to printer or email.
                        Console.WriteLine("_________________________________________________________________");
                        Console.WriteLine("Would you like to email this list to yourself or print it out?");
                        Console.Write("Type P to print, type E to email, or type both to do both: ");
                        string printResponse = Console.ReadLine();

                        if (printResponse == "E")
                        {
                            //sends list to email of user.
                            Email();
                        }
                        else if (printResponse == "P")
                        {
                            //sends list to local printer.
                            Print();
                        }
                        else if (printResponse == "EP" || printResponse == "PE")
                        {
                            //sends list to both email and local printer.
                            Print();
                            Email();
                        }
                        else { Console.WriteLine("Please enter a valid response."); }

                        validator = false;
                    }
                    else
                    {
                        validator = true;
                        Console.WriteLine("List not found. Please try again");

                    }




                }
            } while (!validator);

            Console.WriteLine("List not found. Please try again");
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
