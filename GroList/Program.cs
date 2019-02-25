using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class Program
    {
        static void Main(string[] args)
        {

            Menu.DisplayGreeting();

            int option = 0;
            while ((option = Menu.Prompt()) != 5)
            {
                switch (option)
                {
                    case 1:
                        List.NewList();
                        break;
                    case 2:
                        Other.SavedSearch();
                        break;
                    case 3:
                        Categories.ViewCategories();
                        break;
                    case 4:
                        Other.AboutGroList();
                        break;
                }
            }





            //Main menu needs to be selectable to print out other options.
            //Categories option should print out a list of categories. 
            //New list should start the user on creating a new list.
            //Saved lists should print out saved lists sorted newest to oldest. Maybe they should be able to choose a date range or specific date?

        }

    }
}
