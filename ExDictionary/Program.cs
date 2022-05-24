using System;
using System.Collections.Generic;
using System.IO;

namespace ExDictionary
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Enter file full path: ");
            string path = Console.ReadLine();
            try
            {
                using(StreamReader sr = File.OpenText(path))
                {
                    Dictionary<string, int> dict = new Dictionary<string, int>();
                    while(!sr.EndOfStream)
                    {
                        string[] votingRecord = sr.ReadLine().Split(',');
                        string candidate = votingRecord[0];
                        int numVotes = int.Parse(votingRecord[1]);
                        if (dict.ContainsKey(candidate))
                        {
                            dict[candidate] += numVotes;
                        }
                        else
                        {
                            dict[candidate] = numVotes;
                        }
                    }
                    foreach (KeyValuePair<string, int> item in dict)
                    {
                        Console.WriteLine(item.Key + ": " + item.Value);
                    }
                }
            }
            catch(IOException e)
            {
                Console.WriteLine("ERROR: file not found!");
                Console.WriteLine(e.Message);
            }
        }
    }
}
