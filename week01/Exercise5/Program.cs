using System;

class Program
{
    static void Main(string[] args)
    {

        DisplayMessage();
        Console.WriteLine("Hello Please enter your Username: ");
        String userName = Console.ReadLine();
        DisplayUserName(userName);
        //DisplayUserNumber(userNumber);
        Console.WriteLine("Please enter a number: ");
        int userNumber = int.Parse(Console.ReadLine());
        DisplayUserNumber(userNumber);
        //SquareNumber(userNumber);
        SquareNumber(userNumber, userName);

    }
    static void DisplayMessage()
    {
        Console.WriteLine("This is a message from the DisplayMessage method.");
    }
    static void DisplayUserName(string userName)
    {
        int count = userName.Length;
        Console.WriteLine("Hello " + userName + ", welcome to the program!");
        Console.WriteLine("Thank you for entering your userName.");
        Console.WriteLine("Your userName has: "+ count +" characters.");


    }
    static void DisplayUserNumber(int userNumber)
    {   
        
        Console.WriteLine("You entered the number: " + userNumber);
    }
    static void SquareNumber(int userNumber, string userName)
    {
        int square = userNumber * userNumber;
        Console.WriteLine("Hello " + userName + ", the square of " + userNumber + " is: " + square);
    }

}