using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace gradebook
{
    public class Program
    {
        static string letterGrade;
        static double averageScore;
        static string studentName;
        static string inputTestScore = "";
        static int testScore;
        static string startMenu;
        static string path;
        //initializes variables being declared outside of main
        static void Main(string[] args)
        {
            while (true) //loops main to allow user to continue using program until they quit
            {
                
                Console.WriteLine("Enter 'entry' to enter a new student's information\nEnter 'retrieve' to view previous entries\nEnter 'quit' to exit program");
                startMenu = "";
                startMenu = Console.ReadLine(); //takes user input to determine what they'd like to do
                startMenu.ToLower(); //standardizes form of user's input to reduce errors

                if (startMenu == "retrieve") 
                {

                    string[] printEntries = File.ReadAllLines(@"\\server\student_docs$\aallen\Documents\Visual Studio 2015\Projects\gradebook\StudentInformation/StudentInformation.txt");
                    /*I realize this is a really specific directory that wouldn't apply to a typical user but I would get exceptions and errors whenever I would try to go to
                        a standard user's directory such as c:/desktop or just c:/. The same issue was had when printing the information to the text file

                     However, this code would typically print the entries in the user's studentinformation text file assuming it already exists. If it does not exist,
                     I have code that creates the file when an entry is made below
                    */
                    Console.WriteLine(""); //spaces out different entries for readability
                    foreach (string line in printEntries)
                    {
                        Console.WriteLine(line);
                    } //prints each line of text file
                    Console.ReadLine();
                }

                else if (startMenu == "entry")
                {

                    Console.WriteLine("Please input student First and Last name");
                    studentName = Console.ReadLine(); //intakes student's first and last name

                    while (inputTestScore != "done") //continues to take test scores until user enters done
                    {
                        Console.WriteLine("Please input test scores (enter 'done' when finished)");
                        inputTestScore = Console.ReadLine();
                        inputTestScore = inputTestScore.ToLower(); //lowercases input to reduce possibility of errors


                        if (inputTestScore == "done")
                        {
                            double sumTest = testScores.Sum(); //finds the sum of the tests by adding all doubles within the list testScores
                            averageScore = sumTest / testScores.Count; //finds average by dividing sum of tests by number of tests
                            String.Format("{0:0.00}", averageScore); //formats answer so it isnt a long running decimal

                            FindGrade(averageScore); //calls helper method FindGrade which determines student's grade based on their average score
                            Console.WriteLine("\n" + "Student Name is: " + studentName);
                            Console.WriteLine("Number of tests taken: " + testScores.Count);
                            Console.WriteLine("Average test score: " + averageScore);
                            Console.WriteLine("Student Grade is: " + letterGrade);
                            Console.WriteLine("Press 'enter' to copy student information to registry");
                            Console.ReadLine(); //prints all information so it is visible to user
                            CreateEntry(); //calls CreateEntry so the user input information is stores in a text file and can be recalled if user enters 'retrieve'
                            inputTestScore = ""; //sets inputTestScore back to an emptry string from done so the loop doesnt skip the ability to enter tests after the first entry is submitted
                            break; //breaks while loop

                        }
                        else
                        {
                            testScore = Int32.Parse(inputTestScore); //converts the user input string to an integer so it can be manipulated with math functions
                            testScores.Add(testScore); //adds the user input integer to the list
                        }

                        
                    
                    }

                }
                        else if (startMenu == "quit")
                        {
                            Environment.Exit(0); //exits program if user wishes to do so
                        }
            }
        }
        public static string FindGrade(double averageScore)
        {

        
            if (averageScore >= 90)
            {
                letterGrade = "A";
            }

            else if (averageScore >= 80)
            {
                letterGrade = "B";
            }
            else if (averageScore >= 70)
            {
                letterGrade = "C";
            }
            else if (averageScore >= 60)
            {
                letterGrade = "D";
            }
            else if (averageScore <= 59)
            {
                letterGrade = "F";
            }

            return letterGrade; //determines the letter grade depending on the average of the user test scores and returns that value
        }

        public static void CreateEntry()
        {

            path = @"\\server\student_docs$\aallen\Documents\Visual Studio 2015\Projects\gradebook\StudentInformation/StudentInformation.txt"; 
            /*again a really spacific path but quinten suggested I leave it as is because trying to make it a really general path that would apply to all users would be somewhat tricky. I tried a 
             number of ways to create a file to the user's desktop, documents folder, and c:/ drive but nothing seemed to work. If you change this directory to one of your pathways it will work
            */
            if (!File.Exists(path)) 
            {
                using (StreamWriter sw = File.CreateText(path)) //creates the text file if it doesnt already exist
                {
            
                    sw.WriteLine("Student Name: " + studentName);
                    sw.WriteLine("Tests Taken: " + testScores.Count);
                    sw.WriteLine("Average Score: " + averageScore);
                    sw.WriteLine("Letter Grade: " + letterGrade);
                    sw.WriteLine("");
                } //puts the user entered information into the text file
            }

            using (StreamWriter sw = File.AppendText(path)) //if the text file already exists, it appends the user input information
            {
                sw.WriteLine("Student Name: " + studentName);
                sw.WriteLine("Tests Taken: " + testScores.Count);
                sw.WriteLine("Average Score: " + averageScore);
                sw.WriteLine("Letter Grade: " + letterGrade);
                sw.WriteLine("");
            }

        }

        public static List<double> testScores = new List<double>(); /*this just establishes the list I am using to store an infinite possible amount of test scores while still being able to do math to it
                                       I thought this was a better approach than just having a finite number of varibles, as this way the user can enter as many as he or she wants*/
    }
}