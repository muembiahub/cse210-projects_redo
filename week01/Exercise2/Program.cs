using System;

class Program
{
    static void Main(string[] args)
    {
        
        //  variable to hold on Student grade
        string grade = "A";
        string[] StatusOptions = { "Pass", "Fail" };


        Console.Write("What is your grade percentage? ");
        int gradePercentage = int.Parse(Console.ReadLine());


        //  if else statement to determine the letter grade
        if (gradePercentage >= 93)
        {
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Congratulations! You have an " + grade + " grade.");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage ==92 || gradePercentage ==91 || gradePercentage ==90 )
        {
            grade = "A-";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        
    
        else if (gradePercentage == 89 || gradePercentage == 88 || gradePercentage == 87)
        {
            grade = "B+";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage == 86 || gradePercentage == 85 || gradePercentage == 84 || gradePercentage == 83)
        {
            grade = "B";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage == 82 || gradePercentage == 81 || gradePercentage == 80)
        {
            grade = "B-";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
         
    
        else if (gradePercentage >= 79 && gradePercentage <= 70)
        {
            grade = "B";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage ==79 || gradePercentage == 78 || gradePercentage == 77)
        {
            grade = "C+";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage == 76 || gradePercentage == 75 || gradePercentage == 74 || gradePercentage ==73)
        {
            grade = "C";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage == 72 || gradePercentage == 71 || gradePercentage == 70)
        {
             grade = "C-";
             Console.WriteLine("Your letter grade is " + grade + ".");
             Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        
        else if (gradePercentage ==69 || gradePercentage == 68 || gradePercentage == 67)
        {
            grade = "D+";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage == 66 || gradePercentage == 65 || gradePercentage == 64 || gradePercentage ==63)
        {
            grade = "D";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage == 62 || gradePercentage == 61 || gradePercentage == 60)
        {
            grade = "D-";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("Status: " + StatusOptions[0] + ".");
        }
        else if (gradePercentage <=59 && gradePercentage >= 0)
        {
            grade = "F";
            Console.WriteLine("Your letter grade is " + grade + ".");
            Console.WriteLine("You have failed the course. Please see your instructor for assistance.");
            Console.WriteLine("Status: " + StatusOptions[1] + ".");
        }
        else
        {
            Console.WriteLine("Invalid grade percentage. Please enter a value between 0 and 100.");
            Console.WriteLine("Status: " + StatusOptions[1] + ".");
            return;
        }
    }
}