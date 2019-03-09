using System;
using System.IO;

namespace GroList
{
    class Other
    {

        internal static void AboutGroList()
        {
            string line;
            StreamReader sr = new StreamReader("../About.txt");
            line = sr.ReadLine();
            while (line != null)
            {
                Console.WriteLine(line);
                line = sr.ReadLine();
            }
            sr.Close();
        }



        internal static string PromptMessage(string message)
        {
            Console.Write(message);
            String userInput = Console.ReadLine();
            Console.WriteLine();

            return userInput.Trim();
        }


    }
}
