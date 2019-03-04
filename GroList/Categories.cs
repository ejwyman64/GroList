using System;

namespace GroList
{
    public class Categories
    {
        public DateTime Date { get; set; }
        public Category Category { get; set; }


        internal static void ViewCategories()
        {
            string[] Cats = (string[])Enum.GetNames(typeof(Category));

            for (int i = 0; i < Cats.Length; i++)
            {
                Console.WriteLine(Cats[i]);
            }
        }
    }

    public enum Category
    {
        Produce,
        Dairy,
        Bakery,
        Meat,
        FrozenFood,
        CannedFood,
        Snacks,
        GrainsCereal,
        PantryCondiments,
        Beverages,
        PetSupplies,
        PaperPlastic,
        CleaningSupplies,
        HealthBeauty,
        Other
    }




}
