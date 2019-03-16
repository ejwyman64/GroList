using System;
using System.Collections.Generic;
using System.Collections;


namespace GroList
{
    class OldCategories
    {
        internal static List<string> cats = new List<string>
                {
                "Produce",
                "Dairy",
                "Bakery",
                "Meat",
                "FrozenFood",
                "CannedFood",
                "Snacks",
                "GrainsCereal",
                "PantryCondiments",
                "Beverages",
                "PetSupplies",
                "PaperPlastic",
                "CleaningSupplies",
                "HealthBeauty",
                "Other"
                };


        internal static void GetCategories()
        {
            bool validator = false;

            do
            {
                Console.Clear();
                Program.DisplayGreeting();

                foreach (string cat in cats)
                {
                    Console.WriteLine(cat);
                }

                Console.Write("Type '1' to return to main menu: ");
                string menuReturn = Console.ReadLine();

                if (menuReturn == "1")
                {
                    validator = true;
                    Console.Clear();
                    Program.DisplayGreeting(); 
                }

            } while (!validator);
        }
    }

}
