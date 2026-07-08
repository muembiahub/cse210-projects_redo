using System;

class Program
{
    static void Main(string[] args)
    {
        string grade;
        string[] StatusOptions = { "Pass", "Fail" };

        Console.Write("What is your  percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());

        if (gradePercentage >= 93)
            grade = "A";
        else if (gradePercentage >= 90)
            grade = "A-";
        else if (gradePercentage >= 87)
            grade = "B+";
        else if (gradePercentage >= 83)
            grade = "B";
        else if (gradePercentage >= 80)
            grade = "B-";
        else if (gradePercentage >= 77)
            grade = "C+";
        else if (gradePercentage >= 73)
            grade = "C";
        else if (gradePercentage >= 70)
            grade = "C-";
        else if (gradePercentage >= 67)
            grade = "D+";
        else if (gradePercentage >= 63)
            grade = "D";
        else if (gradePercentage >= 60)
            grade = "D-";
        else if (gradePercentage >= 0)
            grade = "F";
        else
        {
            Console.WriteLine("Invalid grade percentage. Please enter a value between 0 and 100.");
            return;
        }

        Console.WriteLine($"Your grade is {grade}.");

        if (grade == "F")
        {
            Console.WriteLine("You have failed the course. Please see your instructor for assistance.");
            Console.WriteLine($"Status: {StatusOptions[1]}.");
        }
        else
        {
            Console.WriteLine("Congratulations!");
            Console.WriteLine($"Status: {StatusOptions[0]}.");
        }
    }
}
