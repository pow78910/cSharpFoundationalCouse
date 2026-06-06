using System.Diagnostics.Contracts;
using System.Runtime.CompilerServices;
using System.Xml.Schema;
using Task4;
class MenuAccess()
{
     public static void StartReturn()

    {
        Console.WriteLine("\nPress any key to return to start");
        Console.ReadKey();
        Console.Clear();
        Program.Start();
    }
    public static char menuInput ()
    {
         ConsoleKeyInfo input = Console.ReadKey(true);
         return input.KeyChar;
    }


}

public class ProgramFuncs
{
     public static void OutputFile(string path)
    {
       string fileText = File.ReadAllText(@path) ; 
       Console.WriteLine($"\n{fileText}");

       MenuAccess.StartReturn();    
    }

    public static void DefiningScores()
    {
        string[] students = new string[4];
         students[0] = "Alice";
         students[1]= "Ben";
         students[2] = "Chloe";
         students[3] = "Daniel";

        int[] extraCred = new int[4];

        extraCred[0] = 87;
        extraCred[1] = 92; 
        extraCred[2] = 41;
        extraCred[3] = 27;
        

        double [][] scores = new double[4][];

         scores[0] = [82,47,86,34,86,extraCred[0]];
         scores[1] = [67,34,67,98,56, extraCred[1]];
         scores[2]= [12,45,97,34,12, extraCred[2]];
         scores[3] = [12,99,9,54,24, extraCred[3]];

        CalcScoresOutput(students, extraCred, scores);

         

    }

    public static void CalcScoresOutput(string[] students, int[] extraCred, double[][] scores)
    {


           Console.SetBufferSize(Console.WindowWidth, Console.WindowHeight);
           Console.Clear();
            
       //Loops through each of the 4 students 
        for (int x = 0; x < 4; x++)
        {
            //Declares default grade which will then be changed after calculation 
            //y varibale for exam count 
            char grade = 'x';
            
            int y = 1;

            Console.WriteLine($"Student {x + 1} - {students[x]}:\n");

            foreach (double score in scores[x])
            {

                if (y < 6)
                {
                Console.WriteLine($"Exam {y} score: {score}");
                y++;
                }
                else
                {
                    Console.WriteLine($"\nExtra credit assignment: {score}");
                    Console.WriteLine($"This means you will get an extra {score / 10} added to you average grade");
                }


            }
            Console.WriteLine($"\nAverage for scores: {(scores[x].Average()).ToString("F1")}");
            Console.WriteLine($"Extra credit = {(scores[x][5] / 10).ToString("F1")}");
            Console.WriteLine($"\nTotal: {(scores[x].Average() + (scores[x][5]) /10).ToString("F1")}");

            switch ((scores[x].Average() + (scores[x][5]) /10))
            {
            case < 60:
                grade = 'F';
                break;
            case < 70:
                grade = 'D';
                break;
            case < 75:
                grade = 'C';
                break;
            case < 80:
                grade = 'B';
                break;
            case < 90:
                grade = 'A';
                break;
            default:
                
                break;
            }

            Console.WriteLine($"Final Grade: {grade}");

            Console.WriteLine("\nTest break\n");
            Console.ReadKey();
            Console.WriteLine("\n");
        }

         MenuAccess.StartReturn();
            
        
    }
    
    public static void CalcScoresOutputUpdated(string[] students, int[] extraCred, double[][] scores)
    {
        Console.WriteLine("TEST");
        MenuAccess.StartReturn();

    }
    
  

}











//I want this code to be used as a foundation later
//Do it the easy way for now; hardcoding etc, then come back and do it this way. 
/*
public class Student
{
    string name { get; set;}
    int[] score { get; set;}


    public Student(string nameArg, int[] scoreArg)
    {
        name = nameArg;
        score = scoreArg;
    }
}
*/

