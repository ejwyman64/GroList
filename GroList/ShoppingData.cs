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



        internal static void PrintShoppingData(List<ShoppingData> myShoppingData)
        {
            foreach (var data in myShoppingData)
            {
                Console.WriteLine("..........................");
                Console.WriteLine("----- Name -----");
                Console.WriteLine(data.Name);
                Console.WriteLine("----- Date -----");
                Console.WriteLine(data.Date);
                if(data.Items != null)
                {
                    ShoppingItem.PrintItem(data.Items);

                }
            }
            Console.Write("Please hit ENTER key to return to main menu: ");
            Program.key = Console.ReadKey();
            switch (Program.key.Key)
            {
                case ConsoleKey.Enter:
                    Console.WriteLine("");
                    break;
            }
        }



    }
}
