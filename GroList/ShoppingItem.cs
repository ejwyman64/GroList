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
                Console.WriteLine(data.Category);
                Console.WriteLine(data.ItemName);
            }
        }


        internal static List<ShoppingItem> NewItemMaker()
        {
            List < ShoppingItem> items = new List<ShoppingItem>();
            foreach (var cat in Enum.GetNames(typeof(Category)))
            {
                Console.WriteLine("********** " + cat + " ***********");
                bool validator = false;
                do
                {
                    var newItem = new ShoppingItem();

                    Console.Write("Add an item: ");

                    //Don't know how to add ItemName or Category.
                    //It just gets a red squiggle.
                    newItem.ItemName = Console.ReadLine();
                    newItem.Category = cat;
                    items.Add(newItem);

                    ////This is very repetitive and not user friendly.
                    ////May have to find a new way to exit this loop.
                    Console.Write("Add another item to " + cat + "? Y/N: ");
                    var addAnother = Console.ReadLine().ToUpper();

                    if (addAnother == "Y")
                    {
                        validator = false;
                    } else
                    {
                        validator = true;
                    }

                } while (!validator) ;
            }
            return items;
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
