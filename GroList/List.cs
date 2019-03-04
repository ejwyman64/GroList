using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GroList
{
    class List
    {


        internal static void NewList()
        {

            Console.WriteLine("Create a new list...");


            int option = 0;
            while ((option = Menu.Prompt()) != 5)
            {
                switch (option)
                {
                    case 1:
                        //Categories
                        //Search.SavedSearch();
                        break;
                    case 2:
                        //
                        //Other.SavedSearch();
                        break;
                }
            }
        }
    }
}
