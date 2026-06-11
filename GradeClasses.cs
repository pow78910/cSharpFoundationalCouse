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

        
       
            CalcScoresOutputUpdated(students, extraCred, scores);
      
        
        

         

    }

    
    public static void CalcScoresOutputUpdated(string[] students, int[] extraCred, double[][] scores)
    {

        double[] avgGrade = AvgGrade(students, scores, extraCred);
        string[] studentLetterGrades = StudentLetterGrades(avgGrade);

        Console.Clear(); 
        Console.WriteLine("Student\t\t\tGrade\n");

        for(int x=0; x<students.Length;x++)
        {
            Console.WriteLine($"{students[x]}\t\t\t{avgGrade[x]:F1}\t\t\t{studentLetterGrades[x]}");
          
        }





        MenuAccess.StartReturn();

    }

    public static double[] AvgGrade(string[] students, double[][] scores, int[]extraCred)
    {
        double[] avgTotal = new double[students.Length]; 

        for (int x=0;x<students.Length;x++)
        {
            double avgExamGrades = scores[x].Average();
            double extraCredFinalValue = (scores[x][5]/10);

            avgTotal[x] = avgExamGrades + extraCredFinalValue;
        }



        return avgTotal;
    }

    public static string[] StudentLetterGrades(double[] avgTotal)
    {

        string[] studentLetterGrades = new string[avgTotal.Length];

        for(int x=0; x< avgTotal.Length;x++)
        {
            switch(avgTotal[x])
            {
                case >=97 and <=100:
                    studentLetterGrades[x] = "A+";
                break;
                case >=93 and <97 :
                    studentLetterGrades[x] = "A";
                break;
                case >=90 and <93:
                    studentLetterGrades[x] = "A-";
                break;
                case >=87 and <90:
                    studentLetterGrades[x] = "B+";
                break;
                case >=83 and <87:
                    studentLetterGrades[x] = "B";
                break;
                case >=80 and < 83:
                    studentLetterGrades[x] = "B-";
                break;
                case >=77 and < 80:
                    studentLetterGrades[x] = "C+";
                break;
                case >=73 and < 77 :
                    studentLetterGrades[x] = "C";
                break;
                case >=70 and <73:
                    studentLetterGrades[x] = "C-";
                break;
                case >=67 and <70:
                    studentLetterGrades[x] = "D+";
                break;
                case >=63 and <67:
                    studentLetterGrades[x] = "D";
                break;
                case >=60 and < 63:
                    studentLetterGrades[x] = "D-";
                break;
                case <60:
                    studentLetterGrades[x] = "F";
                break;
                default:
                    studentLetterGrades[x] = "X";
                break;

            }
        }



        return studentLetterGrades;
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

