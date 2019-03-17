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

        //internal static string GetCategory()
        //{
        //    Console.Write("Enter a category (produce, dairy, bakery, meat, frozenFood): ");
        //    string nextCategory = Console.ReadLine();

        //    string[] category = Enum.GetNames(typeof(Category));

        //    for (int cat = 0; cat > category.Length; cat++)
        //    {
        //        if (nextCategory == category[cat])
        //        {
        //            nextCategory = category[cat];
        //        }
        //    }

        //    return nextCategory;
        //}

        internal static void NewItemMaker(List<ShoppingItem> myNewShoppingItem/*, Category category*/)
        {
            foreach (var i in myNewShoppingItem)
            {
                //Console.WriteLine("============== " + category + " ==============");
                //Console.WriteLine("Hit ENTER key when done adding items.");
                bool validator2 = false;
                do
                {
                    Console.Write("Add an item: ");
                    i.ItemName = Console.ReadLine();
                    //i.Category = category; ///////////////// I would like to make it so that I can use the ENUMS to set the category automatically.
                    Console.Write("Enter category (produce, dairy, bakery, meat, frozenFood): ");
                    i.Category = Console.ReadLine();

                    myNewShoppingItem.Add(i);
                    /////////////////////////////// Needs to be able to break out of this loop. Right now there
                    /////////////////////////////// is no way to get out of this loop...

                } while (!validator2);
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
