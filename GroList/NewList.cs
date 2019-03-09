using System.Collections.Generic;
using System.IO;
using Newtonsoft.Json;
using System;

namespace GroList
{
    class NewList
    {
        internal static void SerializeNewList(List<ListData> listDatas, string fileName)
        {
            var serializer = new JsonSerializer();
            using (var writer = new StreamWriter(fileName))
            using (var jsonWriter = new JsonTextWriter(writer))
            {
                serializer.Serialize(jsonWriter, listDatas);
            }
        }

        internal static void AddItems()
        {
            Console.WriteLine("Please type 'done' when finished adding items.");
            List<string> NewItems = new List<string>();
            var done = false;
            do
            {
                Console.Write("Type an item: ");
                var item = Console.ReadLine().Trim();
                NewItems.Add(item);

                done = NewItems.Contains("done");

                NewItems.Remove("done");
                

            } while (!done);

            Console.WriteLine("New items:");
            for (var i = 0; i < NewItems.ToArray().Length; i++)
            {
                Console.WriteLine(NewItems[i]);
            }


            string currentDirectory = Directory.GetCurrentDirectory();
            DirectoryInfo directory = new DirectoryInfo(currentDirectory);
            var fileName = Path.Combine(directory.FullName, "ListData.json");

            //SerializeNewList( ListMenu.listDatas, fileName);
        }
    }
}
