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
                Console.WriteLine(data.ItemName);
                Console.WriteLine(data.Category);
            }
        }


        internal List<ShoppingItem> NewItemMaker()
        {
            List<ShoppingItem> newItem = new List<ShoppingItem>();
            foreach (var cat in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine("********** " + cat + " ***********");
                Console.WriteLine("Just hit ENTER key when done.");

                bool validator = false;
                do
                {
                    Console.Write("Add an item: ");

                    //Don't know how to add ItemName or Category.
                    //It just gets a red squiggle.
                    newItem.ItemName = Console.ReadLine();
                    newItem.Category = cat;

                    if (ItemName == "")
                    {
                        validator = true;
                    }

                } while (!validator) ;
            }
            return newItem;
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
