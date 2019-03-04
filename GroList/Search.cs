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

        static string[] _options = new string[]
        {
                "To search for a list: ",
                "To exit the program: "
        };

        static void DisplayMenu()
        {

            Console.WriteLine("_____________________________________________________________");

            for (int i = 0; i < _options.Length; i++)
            {
                Console.WriteLine($"{i + 1}){_options[i]}");
            }

        }

        internal static int SearchPrompt()
        {
            bool validate = false;
            int parsedUserInput = 0;
            string input = string.Empty;

            DisplayMenu();

            do
            {
                input = Menu.PromptMessage($"Please select an option (1-{_options.Length}): ");
                bool canParse = int.TryParse(input, out parsedUserInput);
                validate = canParse && parsedUserInput > 0 && parsedUserInput <= 2;

                if (!validate)
                {
                    Console.WriteLine("'" + input + "' is not a valid option. Please provide a number 1-5");
                }
            }
            while (!validate);


            return parsedUserInput;
        }

        //needs to keep running until user wants to go back to menu.
        internal static void SavedSearch()
        {

            int option = 0;
            while ((option = SearchPrompt()) != 2)
            {
                switch (option)
                {
                    case 1:
                        //Categories
                        SearchResults();
                        break;
                }
            }

        }

        internal static void SearchResults()
        {
            //Find json file to deserialize.
            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "ListData.json");
            var listSearch = DeserializeList(fileName);

            //Prompt for user to search.
            Console.Write("Search by the name of the list or the date (mm/dd/yyyy) the list was created: ");
            string searchQuery = Console.ReadLine();
            searchQuery = searchQuery.ToUpper();

            //Prints searched items out to console.
            for (int i = 0; i < listSearch.Count; i++)
            {
                ListData item = listSearch[i];
                if (searchQuery == item.Name.ToUpper() || searchQuery == item.Date)
                {
                    Console.WriteLine("_____________________________________________________________");
                    Console.WriteLine(item.Name);
                    Console.WriteLine(item.Date);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Produce:");
                    item.Produce.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Dairy:");
                    item.Dairy.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Bakery:");
                    item.Bakery.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Meat:");
                    item.Meat.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Frozen Food:");
                    item.FrozenFood.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Canned Goods:");
                    item.CannedFood.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Snacks:");
                    item.Snacks.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Grains and Cereal:");
                    item.GrainsCereal.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Pantry Goods and Condiments:");
                    item.PantryCondiments.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Beverages:");
                    item.Beverages.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Pet Supplies:");
                    item.PetSupplies.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Paper and Plastic:");
                    item.PaperPlastic.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Cleaning Supplies:");
                    item.CleaningSupplies.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Health and Beauty:");
                    item.HealthBeauty.ForEach(Console.WriteLine);
                    Console.WriteLine("- - - - - - - - - - - - - - - - -");
                    Console.WriteLine("Other:");
                    item.Other.ForEach(Console.WriteLine);

                }
            }

            Console.WriteLine("Would you like to email this list to yourself or print it out?");
            Console.Write("Type P to print, type E to email, or type both to do both: ");
            string printResponse = Console.ReadLine();

            if (printResponse == "E")
            {
                EmailSearchedList.Email();
            }
            else if (printResponse == "P")
            {
                EmailSearchedList.Print();
            }
            else if (printResponse == "EP" || printResponse == "PE")
            {
                EmailSearchedList.Print();
                EmailSearchedList.Email();
            }

        }





    }
}
