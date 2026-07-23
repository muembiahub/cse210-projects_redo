// EXCEEDING REQUIREMENTS:
// 1. Scripture Library: Holds a collection of scriptures.
// 2. Random Selection: Picks a random scripture from the library upon startup.
// 3. User Interaction: Allows the user to choose a scripture from random or not let him change to another and memorize it.
// 4. File Loading: Reads scriptures dynamically from an external "scriptures.txt" file.
// 5. Smart Word Hiding: Handled in Scripture.cs to only target visible words.
// 6. Memorization Progress Tracker: Counts user steps/rounds and displays a performance summary at the end.

using System;
using System.Collections.Generic;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        List<Scripture> scriptureLibrary = LoadScripturesFromFile("scriptures.txt");

        // Fallback if file doesn't exist or is empty
        if (scriptureLibrary.Count == 0)
        {
            Reference ref1 = new Reference("Proverbs", 3, 5, 6);
            string text1 = "Trust in the Lord with all thine heart and lean not unto thine own understanding.";
            scriptureLibrary.Add(new Scripture(ref1, text1));
        }

        Random random = new Random();
        Scripture scripture = null;
        string choice = "y";

        // Loop to let the user keep rolling a random scripture until they like one
        while (choice == "y")
        {
            scripture = scriptureLibrary[random.Next(scriptureLibrary.Count)];

            Console.Clear();
            Console.WriteLine("=== SELECTED SCRIPTURE ===");
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            
            Console.Write("Would you like to memorize this scripture? (Press Enter to start, or type 'y' for a different random one): ");
            choice = Console.ReadLine().Trim().ToLower();
        }

        string userInput = "";
        int stepsTaken = 0; // Tracks how many times the user pressed enter to hide words

        // Main memorizer loop
        while (userInput != "quit" && !scripture.IsCompletelyHidden())
        {
            Console.Clear();
            Console.WriteLine(scripture.GetDisplayText());
            Console.WriteLine();
            Console.Write("Press enter to continue or type 'quit' to finish: ");
            
            userInput = Console.ReadLine().Trim().ToLower();

            if (userInput != "quit")
            {
                scripture.HideRandomWords(3);
                stepsTaken++;
            }
        }

        // Final display & Session Statistics Report
        Console.Clear();
        Console.WriteLine(scripture.GetDisplayText());
        Console.WriteLine("\n==============================");
        Console.WriteLine("      SESSION STATISTICS      ");
        Console.WriteLine("==============================");
        Console.WriteLine($" Scripture Completed: {scripture.GetDisplayText()}");
        Console.WriteLine($" Total Steps Taken:   {stepsTaken}");
        Console.WriteLine(" Status:              Memorized! 🎉");
        Console.WriteLine("==============================");
        Console.WriteLine("\nProgram ended. Great job memorizing!");
    }

    static List<Scripture> LoadScripturesFromFile(string filename)
    {
        List<Scripture> library = new List<Scripture>();

        if (File.Exists(filename))
        {
            string[] lines = File.ReadAllLines(filename);
            foreach (string line in lines)
            {
                if (string.IsNullOrWhiteSpace(line)) continue;

                string[] parts = line.Split('|');
                if (parts.Length == 5)
                {
                    string book = parts[0];
                    int chapter = int.Parse(parts[1]);
                    int startVerse = int.Parse(parts[2]);
                    int endVerse = int.Parse(parts[3]);
                    string text = parts[4];

                    Reference reference;
                    if (endVerse == 0)
                    {
                        reference = new Reference(book, chapter, startVerse);
                    }
                    else
                    {
                        reference = new Reference(book, chapter, startVerse, endVerse);
                    }

                    library.Add(new Scripture(reference, text));
                }
            }
        }

        return library;
    }
}