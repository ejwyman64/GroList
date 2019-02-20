using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    public class List
    {
        public DateTime Date { get; set; }
        public Category Category { get; set; }
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
        BakingCondiments,
        Beverages,
        PetSupplies,
        PaperPlastic,
        CleaningSupplies,
        HealthBeauty,
        Other
    }

}
