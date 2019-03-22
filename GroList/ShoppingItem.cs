using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GroList
{
    public class ShoppingItem
    {

        [JsonProperty("itemName", Required = Required.Always)]
        public string ItemName { get; set; }

        [JsonProperty("category", Required = Required.Always)]
        public string Category { get; set; }

        internal static void PrintItem(List<ShoppingItem> myShoppingItem)
        {
            foreach (var data in myShoppingItem)
            {
                if (data.ItemName != null)
                {
                    Console.WriteLine(data.Category);
                    Console.WriteLine(data.ItemName);
                } else
                {
                    Console.WriteLine("empty");
                }

            }
        }
    }

    public enum Category
    {
        produce,
        dairy,
        bakery,
        meat,
        frozenFood

    }
}
