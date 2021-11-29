using System;
using System.Collections.Generic;
using System.IO;

namespace Cli
{
    class Program
    {
        static void Main(string[] args)
        {
           
            var listAllNames = new List<string[]>(); 
            var sortedNames = new List<string>();
            Console.WriteLine(args.Length);
            if (args.Length != 1)
            {
                Console.WriteLine("Incorrect Arguments given");
                return;
            } // checks for a file to read

            var lines = File.ReadAllLines(args[0]);

            for (int i = 0; i < lines.Length; i++)
                {
                    var fullName = lines[i].Split(' ');         
                    listAllNames.Add(fullName);

                } //reads file line by line and adds full name to previously empty list "listAllNames"

            listAllNames.Sort((n1, n2) =>
                {
                    if (n1[n1.Length - 1] == n2[n2.Length - 1])
                        {
                            return String.Join(" ", n1).CompareTo(String.Join(" ", n2));
                        }
                         else
                            {
                                return n1[n1.Length - 1].CompareTo(n2[n2.Length - 1]);
                            }
                }); /// sort names alphabetically, first by checking if the surname is the same, to then sort by the full name, if the lasts names are different then sort those alphabetically



            var allNamesLength = listAllNames.ToArray().Length;
            for (int j = 0; j < allNamesLength; j++)
                {
                    var sortedFullName = String.Join(" ", listAllNames[j]);
                    sortedNames.Add(sortedFullName);
                } // put this new sorted names into a list

            File.WriteAllLines("sorted-names-list.txt", sortedNames); //write that list into a new file
            var sortedNamesObject = String.Join("\n", sortedNames); //Turn that list into a string separated by new lines
            Console.WriteLine(sortedNamesObject); // print to screen


        }
    }
};