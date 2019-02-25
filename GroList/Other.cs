using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GroList
{
    class Other
    {

        internal static void AboutGroList()
        {
            string line;
            StreamReader sr = new StreamReader("C:/Users/ejpin/source/repos/GroList/GroList/README.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }


        internal static void SavedSearch()
        {
            Console.WriteLine("Soon you will be able to save lists and retrieve them in this application! So cool!");
        }
    }
}
