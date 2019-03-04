using System;
using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Globalization;
using Newtonsoft.Json.Converters;

namespace GroList
{
    public class ListData
    {
        [JsonProperty("name", Required = Required.Always)]
        public string Name { get; set; }

        [JsonProperty("date", Required = Required.Always)]
        public string Date { get; set; }

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
        public List<string> Other { get; set; }
    }

    class Search
    {

        internal static List<ListData> DeserializeList(string fileName)
        {
            var data = new List<ListData>();
            var serializer = new JsonSerializer();
            using (var reader = new StreamReader(fileName))
            using (var jsonReader = new JsonTextReader(reader))
            {
                data = serializer.Deserialize<List<ListData>>(jsonReader);
            }
            return data;
        }

        internal static void SavedSearch()
        {
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "ListData.json");
            var listSearch = DeserializeList(fileName);
            foreach (var item in listSearch)
            {
                Console.WriteLine(item.Name);
            }

        }
    }
}
