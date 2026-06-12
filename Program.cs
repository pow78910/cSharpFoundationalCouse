
using System;
using System.Linq;
using System.Runtime.CompilerServices;



namespace Task4
{
     public class Program
    {
      public static void Main (string[] args)
        {
            Console.Clear();
            Start();

        }

        public static void Start()
        {
            Console.WriteLine("Welcome to this program");
            Console.WriteLine("This has been created to execute requirements from one of the tasks from the C# foundational course");
            Console.WriteLine("You can see the requirements of the program, or simply continue to see the output");

            Console.WriteLine("\nView requirements(1)");
            Console.WriteLine("See output(2)");
          
            Console.WriteLine("\n\nView github commands for push/pull(g)");
            

           // ConsoleKeyInfo input = Console.ReadKey(true);
        while (true)
        {
            switch (MenuAccess.menuInput())
            {
                case '1':
                    Requirements('1');
                    break;
                case '2':
                    Output();
                    break;
                case 'g':
                    Requirements('g');
                    break;
                default:
                    Console.WriteLine("Invalid Input, Try Again");
                    break;
                    
            }
        }


    }

       public static void Requirements(char fileRef)
        {
            Console.Clear();

            switch(fileRef)
            {
                case '1':
                ProgramFuncs.OutputFile("./TextFiles/Task4Requirements.txt");
                    break;
                case '3':
                    ProgramFuncs.OutputFile("./TextFiles/Task4RequirementsUpdated.txt");
                break;
                case'g':
                    ProgramFuncs.OutputFile("./TextFiles/gitHubCommands.txt");
                    break;

                default:
                    Console.WriteLine("ERROR FLAG  ---- Press any key to return");
                    Console.ReadKey();
                    Start();
                    break;
                    }
        }

        public static void Output()
        {
            Console.Clear();
            Console.WriteLine("1) View students final averages and grades");
            Console.WriteLine("2)View individual exam grades and extra credit");
        
        while (true)
        {
            switch (MenuAccess.menuInput())
            {
                case '1':
                    ProgramFuncs.DefiningScores(1);
                    break;
                case '2':
                    ProgramFuncs.DefiningScores(2);
                    break;
                default:
                    Console.WriteLine("Invalid Input, Try Again");
                    break;
                    
            }
        }

            
           
        }




    }
}