using System;
using System.Collections.Generic;
using System.Collections;
using System.IO;
using Newtonsoft.Json;

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


        internal static void NewListMaker()
        {
            bool validator = false;
            do
            {
                Console.Clear();
                Console.WriteLine();

                foreach (string cat in Categories.cats)
                {

                    Console.WriteLine("============== " + cat + " ==============");
                    Console.WriteLine("Hit ENTER key when done adding items.");
                    bool validator2 = false;
                    do
                    {
                        Console.Write("Add an item: ");
                        var itemInput = Console.ReadLine();

                        if(itemInput == "")
                        {
                            validator2 = true;
                        }

                    } while (!validator2);
                } break;

            } while (!validator);
        }


        //need to refactor this page. 

        //Need an object to store the user input in.
        //Need to make sure the user input is stored in the right categories.
        //Need to save the object to the JSON file.  

        //internal static void AddItems()
        //{
        //    Console.WriteLine("Please type 'done' when finished adding items.");

        //    List<string> NewItems = new List<string>();
        //    var done = false;
        //    do
        //    {
        //        Console.Write("Type an item: ");
        //        var item = Console.ReadLine().Trim();
        //        NewItems.Add(item);

        //        done = NewItems.Contains("done");

        //        NewItems.Remove("done");




        //    } while (!done);

        //    Console.WriteLine("New items:");
        //    for (var i = 0; i < NewItems.ToArray().Length; i++)
        //    {
        //        Console.WriteLine(NewItems[i]);
        //    }


        //    string currentDirectory = Directory.GetCurrentDirectory();
        //    DirectoryInfo directory = new DirectoryInfo(currentDirectory);
        //    var fileName = Path.Combine(directory.FullName, "ListData.json");

        //    //SerializeNewList( ListMenu.listDatas, fileName);
        //}
    }
}
