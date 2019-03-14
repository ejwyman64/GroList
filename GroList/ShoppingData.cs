using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace GroList
{
    public class ShoppingData
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public string Date { get; set; }

        public List<ShoppingItem> items { get; set; }

        //this will be called in search and will print out one list.
        public void PrintShoppingData()
        {
            foreach (var i in items)
            {
                i.PrintItem();
            }
        }

        internal static void Email()
        {
            Console.WriteLine("Your list has been emailed.");
        }

        internal static void Print()
        {
            Console.WriteLine("Your List has been sent to your local printer.");
        }
        /*
        [JsonProperty("produce", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Produce { get; set; }

        [JsonProperty("dairy", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Dairy { get; set; }

        [JsonProperty("bakery", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Bakery { get; set; }

        [JsonProperty("meat", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Meat { get; set; }

        [JsonProperty("frozenFood", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> FrozenFood { get; set; }

        [JsonProperty("cannedFood", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CannedFood { get; set; }

        [JsonProperty("snacks", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Snacks { get; set; }

        [JsonProperty("grainsCereal", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> GrainsCereal { get; set; }

        [JsonProperty("pantryCondiments", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PantryCondiments { get; set; }

        [JsonProperty("beverages", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Beverages { get; set; }

        [JsonProperty("petSupplies", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PetSupplies { get; set; }

        [JsonProperty("paperPlastic", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> PaperPlastic { get; set; }

        [JsonProperty("cleaningSupplies", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> CleaningSupplies { get; set; }

        [JsonProperty("healthBeauty", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> HealthBeauty { get; set; }

        [JsonProperty("other", NullValueHandling = NullValueHandling.Ignore)]
        public List<string> Other { get; set; }*/
    }
}
