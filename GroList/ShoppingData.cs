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
                if(data.Items != null)
                {
                    ShoppingItem.PrintItem(data.Items);

                }
            }
            Console.Read();
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
