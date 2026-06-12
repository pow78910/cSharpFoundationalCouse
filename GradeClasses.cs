using System.Diagnostics.CodeAnalysis;
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

    public static void DefiningScores(int outputRef)
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

        
            switch(outputRef)
            {
            case 1:
                //CalcScoresOutputUpdated(students, extraCred, scores);
            break;
            case 2:
                CalcScoresOutputUpdatedAgain(students, extraCred, scores);
                break;
            }
      
        
        

         

    }

    
    /*public static void CalcScoresOutputUpdated(string[] students, int[] extraCred, double[][] scores)
    {

        double[] totalGrade = Totals(students, scores, extraCred);
        string[] studentLetterGrades = StudentLetterGrades(avgGrade);

        Console.Clear(); 
        Console.WriteLine("Student\t\t\tGrade\n");

        for(int x=0; x<students.Length;x++)
        {
            Console.WriteLine($"{students[x]}\t\t\t{avgGrade[x]:F1}\t\t\t{studentLetterGrades[x]}");
          
        }




        MenuAccess.StartReturn();

    }
    */


    public static void CalcScoresOutputUpdatedAgain(string[] students, int[] extraCred, double[][] scores)
    {
        
        (double[] examScoreTotal, double[]examScoreAvg, double[] finalTotal) = Totals(students, scores, extraCred);
        string[] studentLetterGrades = StudentLetterGrades(finalTotal);
        double[] gradeDifferenceAfterExtraCredit = GradeDifferenceAfterExtraCredit(examScoreTotal, examScoreAvg, finalTotal);

    

        Console.Clear(); 
        Console.WriteLine("Student\t\t\tExam Score total\t\tOverall Total\t\tGrade\t\tExtra Credit\n");

        for(int x=0; x<students.Length;x++)
        {
            Console.WriteLine($"{students[x]}\t\t\t\t{examScoreAvg[x]:F1}\t\t\t{finalTotal[x]:F1}\t\t\t{studentLetterGrades[x]}\t\t{extraCred[x]}({gradeDifferenceAfterExtraCredit[x]:F1}pts)");
          
        }





        MenuAccess.StartReturn();

        
    }
    public static (double[] examScoreTotal, double[] examScoreAvg, double[] finalTotal) Totals (string[] students, double[][] scores, int[]extraCred)
    {
        double[] examScoreTotal = new double[students.Length];
         double[] examScoreAvg = new double[students.Length];
    
        double[] extraCredFinalValue = new double[students.Length]; 

        double[] examGradePlusExtraCred = new double[students.Length];
        double[] finalTotal = new double[students.Length]; 

       
        
        

        for (int x=0;x<students.Length;x++)
        {
            //double avgExamGrades = scores[x].Average();

            for (int y =0; y < scores[x].Length - 1; y++)
            {

                examScoreTotal[x] += scores[x][y];
                
               
            }
            examScoreAvg[x] = examScoreTotal[x] / scores[x].Length - 1; 
            extraCredFinalValue[x] = (scores[x][5])/10;
            
            examGradePlusExtraCred[x] = examScoreTotal[x] + extraCredFinalValue[x];
            finalTotal[x] = examScoreTotal[x] / (scores.Length);
            
    
        }

        /* foreach(double score in examScoreTotal)
            {
                Console.WriteLine(score);
            }
       Console.ReadKey();
*/
        return  (examScoreAvg, examScoreAvg, finalTotal);
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
    
    
    
    
        public static double[] GradeDifferenceAfterExtraCredit (double[] examScoreTotal, double[] examScoreAvg, double[] finalTotal)
    {
         double[] gradeDifferenceAfterExtraCredit = new double[examScoreTotal.Length];
         

         for(int x = 0; x < examScoreTotal.Length; x++)
        {
            gradeDifferenceAfterExtraCredit[x] = finalTotal[x] - examScoreAvg[x];
        }

         
/*
        foreach (double total in finalTotal)
        {
                Console.WriteLine(total);
        }
         foreach (double score in examScoreTotal)
        {
                Console.WriteLine(score);
        }
        Console.ReadKey();
        */
        return gradeDifferenceAfterExtraCredit;
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

