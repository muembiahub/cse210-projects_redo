using System;

class Program
{
    static void Main()
    {    
        //  prompts to generate 
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        JournalDatabase db = null;
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal (in memory)");
            Console.WriteLine("3. Save journal (choose filename)");
            Console.WriteLine("4. Load journal (choose filename)");
            Console.WriteLine("5. Quit");
            Console.Write("Choose an option: ");
            string choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    string prompt = prompts[random.Next(prompts.Length)];
                    Console.WriteLine($"\nPrompt: {prompt}");
                    Console.Write("Your response: ");
                    string response = Console.ReadLine();
                    var entry = new JournalEntry(prompt, response);

                    if (db == null)
                    {
                        db = new JournalDatabase(":memory:");
                    }

                    db.Entries.Add(entry);
                    Console.WriteLine("Entry added to memory.");
                    break;

                case "2":
                    if (db == null || db.Entries.Count == 0)
                    {
                        Console.WriteLine("No entries in memory.");
                    }
                    else
                    {
                        foreach (var e in db.Entries)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    break;

                case "3":
                    Console.Write("Enter filename to save journal (e.g., myjournal.db): ");
                    string saveFile = Console.ReadLine();

                    if (db == null)
                    {
                        db = new JournalDatabase(saveFile);
                    }
                    else
                    {
                        db.SetFile(saveFile); 
                    }

                    db.SaveAllEntries();
                    Console.WriteLine($"Journal saved in {saveFile}");
                    break;

                case "4":
                    Console.Write("Enter filename to load journal: ");
                    string loadFile = Console.ReadLine();
                    db = new JournalDatabase(loadFile);
                    db.LoadEntries();
                    Console.WriteLine($"Journal loaded from {loadFile}");

                    if (db.Entries.Count == 0)
                    {
                        Console.WriteLine("No entries found in this database.");
                    }
                    else
                    {
                        foreach (var e in db.Entries)
                        {
                            Console.WriteLine(e);
                        }
                    }
                    break;

                case "5":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
