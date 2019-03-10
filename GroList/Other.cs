using System;
using System.IO;

namespace GroList
{
    class Other
    {

        internal static void AboutGroList()
        {
            Console.Clear();
            Menu.DisplayGreeting();

            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "About.txt");

            Console.WriteLine(fileName);

            string line;
            StreamReader sr = new StreamReader(fileName);
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
