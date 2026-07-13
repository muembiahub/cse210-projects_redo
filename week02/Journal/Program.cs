using System;

class Program
{
    static void Main()
    {
        string[] prompts = {
            "Who was the most interesting person I interacted with today?",
            "What was the best part of my day?",
            "How did I see the hand of the Lord in my life today?",
            "What was the strongest emotion I felt today?",
            "If I had one thing I could do over today, what would it be?"
        };

        JournalDatabase db = new JournalDatabase();
        Random random = new Random();

        while (true)
        {
            Console.WriteLine("\n--- Journal Menu ---");
            Console.WriteLine("1. Write a new entry");
            Console.WriteLine("2. Display the journal");
            Console.WriteLine("3. Quit");
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
                    db.SaveEntry(entry);
                    break;
                //  2 to display and read the entries
                case "2":
                    var entries = db.LoadEntries();
                    foreach (var e in entries)
                    {
                        Console.WriteLine(e);
                    }
                    break;

                case "3":
                    Console.WriteLine("Goodbye!");
                    return;

                default:
                    Console.WriteLine("Invalid choice. Try again.");
                    break;
            }
        }
    }
}
