using System;
using System.Collections.Generic;

class Program
{
    static void Main(string[] args)
    {
        List<int> ListOfNumbers = new List<int>();
        int finish= 1;

        do
        {
            Console.WriteLine("Enter a number: or type {0} to finish: ");
            int number = int.Parse(Console.ReadLine());
            Console.WriteLine("You entered: " + number);
            if (number ==0)
            {
                finish = 0;
            }
            else
            {
              ListOfNumbers.Add(number);  
            }
        } while (finish != 0);
        // some to add and multiply the numbers in the list
        Console.WriteLine("Here are somoe statistics about the numbers you entered:");
        ListOfNumbers.Sort();
        int sum = 0;
        int largest = int.MinValue;
        int smallestPositive = int.MaxValue;
        int count = ListOfNumbers.Count;
        int product = 1;
        String SortedList = String.Join(", ", ListOfNumbers);

        foreach (int n in ListOfNumbers)
        {
            sum += n;
            if (n > largest)
            {
                largest = n;
            }
            if (smallestPositive == int.MaxValue)
            {
                Console.WriteLine("No positive numbers were entered.");
            }
            else 
            {
                Console.WriteLine("Smallest positive number: " + smallestPositive);
            }
           
            product *= n;

        }
        Console.WriteLine("Sum: {0}", sum);
        Console.WriteLine("Count: {0}", count);
        Console.WriteLine("Product: {0}", product);
        Console.WriteLine("Average: {0}",(double) sum / count);
        Console.WriteLine("Largest: {0}", largest);
        Console.WriteLine("Smallest Positive: {0}", smallestPositive);
        Console.WriteLine("Sorted List: {0}", SortedList);
    }
}