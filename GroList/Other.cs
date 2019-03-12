using System;
using System.IO;


namespace GroList
{
    class Other
    {

        internal static void AboutGroList()
        {
            bool validator = false;
            do
            {
                Console.Clear();
                Menu.DisplayGreeting();

                var fileName = "..\\..\\About.txt";

                string line;
                StreamReader sr = new StreamReader(fileName);
                line = sr.ReadLine();
                while (line != null)
                {
                    Console.WriteLine(line);
                    line = sr.ReadLine();
                }
                sr.Close();

                Console.Write("Type '1' and then hit ENTER to return to main menu: ");
                string menuReturn = Console.ReadLine();

                if (menuReturn == "1")
                {
                    validator = true;
                }

            } while (!validator);
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
