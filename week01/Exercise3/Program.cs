using System;
using System.Runtime.CompilerServices;

class Program
{
    static void Main(string[] args)
    {   
        String IsUserWantsToContinue ;
       

        do { 

        int magicNumber =  new Random().Next(1, 101);
        int guess;
        int attempts = 0;

        Console.WriteLine("Welcome to the Magic Number Guessing Game!");
        Console.WriteLine(" A new magic number has been generated between 1 and 100. Try to guess it!");

        do
        {
            
            Console.WriteLine("Guess the magic number (between 1 and 100): ");
            guess = Convert.ToInt32(Console.ReadLine());
            attempts++;

            if (guess == magicNumber)
            {
                Console.WriteLine("You guessed the magic number!"); 
                Console.WriteLine("It took you :" + attempts +  " attempts.");
            }
            else if (guess > magicNumber)
            {
                Console.WriteLine("You guessed too high!");
            }
            else if (guess < magicNumber)
            {
                Console.WriteLine("You guessed too low!");
            }
            else
            {
                Console.WriteLine("You  did not guessed the magic number!");
            }
            

        } while (guess != magicNumber);
        Console.WriteLine("Do you want to play again? (yes/no)");
        IsUserWantsToContinue = Console.ReadLine().ToLower();

        } while (IsUserWantsToContinue == "yes");
        Console.WriteLine("Thank you for playing!");
    }
}