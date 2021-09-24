using System;
using System.Collections.Generic;
using System.Linq;

namespace Lab01v2
{
    class Program
    {
        static string userInput = "0";
        static string menuText = "Options \n ----------\n1 - Import Words From File\n2 - Bubble Sort words\n3 - LINQ/Lambda sort words\n4 - Count the Distinct Words\n5 - Take the first 10 words\n" +
            "6 - Get the number of words that start with 'j' and display the count\n7 - Get and display of words that end with 'd' and display the count\n" +
            "8 - Get and display of words that are greater than 4 characters long, and display the count\n" +
            "9 - Get and display of words that are less than 3 characters long and start with the letter 'a', and display the count\nx - Exit \n\nMake a selection: ";
        static IList<string> words = new List<string>(); //contains the words
        static string filePath = "C:/temp/Words.txt";

        static IList<string> BubbleSort(IList<string> words)
        {
           
            //actual bubble sort
            string temp = "";
            int l = words.Count();
            
            //timer
            var stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            for (int i = 0; i < l; i++)
            {
                for (int j = 0; j < l - 1; j++)
                {
                    if (words[j].CompareTo(words[j + 1]) > 0)
                    {
                        temp = words[j];
                        words[j] = words[j + 1];
                        words[j + 1] = temp;
                    }
                }
            }

            stopwatch.Stop();
            var elapsed_time = stopwatch.ElapsedMilliseconds;

            Console.WriteLine("Time elapsed: "+elapsed_time+"ms\n\n");

            return words;
        }

        static void Main(string[] args)
        {
            
            //menu loop
            while (userInput != "x") //while the input isn't 'x'
            {
                Console.WriteLine(menuText);
                userInput = Console.ReadLine();
                //Console.WriteLine(userInput);

                if (userInput == "1") //get words from file into an array
                {
                    words.Clear(); //clear words so there aren't any doubles
                    Console.Clear();
                    Console.WriteLine("Reading Words");
                    using (System.IO.StreamReader sr = new System.IO.StreamReader(filePath))
                    {
                        string line;
                        while ((line = sr.ReadLine()) != null)
                        {
                            words.Add(line);
                        }
                    }
                    Console.WriteLine("Reading Words Complete");
                    Console.WriteLine("Number of words found: "+ words.Count()+"\n\n");
                }
                else if (userInput == "2") //bubble sort 
                {
                    Console.Clear();
                    words = BubbleSort(words);
                }
                else if (userInput == "3") //Lambda sort
                {
                    Console.Clear();
                    var stopwatch = new System.Diagnostics.Stopwatch();
                    stopwatch.Start();
                    
                    words = words.OrderBy(q => q).ToList();

                    stopwatch.Stop();
                    var elapsed_time = stopwatch.ElapsedMilliseconds;
                    Console.WriteLine("Time elapsed: " + elapsed_time + "ms\n\n");
                } 
                else if (userInput == "4") //count distinct words
                { //using lambda/linq
                    Console.Clear();
                    int distinctWords = (from x in words
                                         select x).Distinct().Count();
                    Console.WriteLine("Number of distinct words: "+distinctWords + "\n\n");
                }
                else if (userInput == "5") //take and display first 10 words
                { //using lambda/linq
                    Console.Clear();
                    string[] firstTen = (from x in words
                                         select x).Take(10).ToArray();

                    if (firstTen.Length != 10) //in case there arne't any 
                    {
                        Console.WriteLine("not enough in list");
                    } else {
                        //Console.WriteLine("the first ten words are:");
                        for (int i = 0; i < 10; i++)
                        {
                            Console.WriteLine(firstTen[i]);
                        }
                        Console.WriteLine("\n\n");
                    }
                }
                else if (userInput == "6") //get number of words starting with 'j' and display count
                { //using lambda/linq
                    Console.Clear();
                    string[] jWords = (from x in words
                                       where x.StartsWith("j")
                                       select x).ToArray();
                    int count = 0;
                    for (int i = 0; i < jWords.Length; i++)
                    {
                        Console.WriteLine(jWords[i]);
                        count++;
                    }
                    Console.WriteLine("Number of words starting with 'j': "+count + "\n\n");
                }
                else if (userInput == "7") // get number of words ending with 'd' and display count
                { //using lambda/linq
                    Console.Clear();
                    string[] dWords = (from x in words
                                       where x.EndsWith("d")
                                       select x).ToArray();
                    int count = 0 ; 
                    for (int i = 0; i < dWords.Length; i++)
                    {
                        Console.WriteLine(dWords[i]);
                        count++;
                    }
                    Console.WriteLine("Number of words ending with 'd': " + count + "\n\n");
                }
                else if (userInput == "8") // get number of words more than 4 chars long and display count
                { //using lambda/linq
                    Console.Clear();
                    string[] fourWords = (from x in words
                                       where x.Length>4
                                       select x).ToArray();
                    int count = 0;
                    for (int i = 0; i < fourWords.Length; i++)
                    {
                        Console.WriteLine(fourWords[i]);
                        count++;
                    }
                    Console.WriteLine("Number of words longer than 4 characters: "+count + "\n\n");
                }
                else if (userInput == "9") // get number of words starting with 'a' and less than 3 letters long and display count
                { //using lambda/linq
                    Console.Clear();
                    string[] aWords = (from x in words
                                          where x.Length < 3 && x.StartsWith("a")
                                          select x).ToArray();
                    int count = 0;
                    for (int i = 0; i < aWords.Length; i++)
                    {
                        Console.WriteLine(aWords[i]);
                        count++;
                    }
                    Console.WriteLine("Number of words longer less than 3 characters and start with 'a':"+count + "\n\n");
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine("INVALID INPUT\n\n");
                }
            }
            Console.WriteLine("out");
            
        }
    }
  

}
