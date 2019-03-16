using System;
using System.Collections;
using Newtonsoft.Json;


namespace GroList
{
    public class ShoppingItem : IEnumerable
    {

        [JsonProperty("itemName", Required = Required.Always)]
        public string ItemName { get; set; }

        [JsonProperty("category", Required = Required.Always)]
        public string Category { get; set; }

        internal static void PrintItem()
        {
            var shoppingItem = new ShoppingItem();
            foreach(var i in shoppingItem)
            {
                Console.WriteLine(shoppingItem.ItemName);
                Console.WriteLine(shoppingItem.Category);
            }


        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return (IEnumerator)GetEnumerator();
        }

        public IEnumerator GetEnumerator()
        {
            throw new NotImplementedException();
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
