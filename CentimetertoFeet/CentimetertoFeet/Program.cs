using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CentimetertoFeet
{
    class Program
    {
        static void Main(string[] args)
        {
            string userInput;
            string quitProgram;
            double centimeters;
            double inch;
            double leftOver;
            string roundedInches;
            double feet;
            

            while (true) {
                Console.WriteLine("Please Enter Number of Centimeters ");
                //prompts user to enter number of centimeters
                        userInput = "";
                //intakes user's input
                        userInput = Console.ReadLine();
                //reads user input to be used for conversion
                  
                        centimeters = double.Parse(userInput);
                
                
                //converts string userInput to a double so it can be manipulated with math functions
                inch = centimeters * 0.393701;
                //converts number to centimeters to total inches
                feet = (int)inch / 12;
                //finds number of feet in total inches
                leftOver = inch % 12;
                //calculates remaining inches that did not go into feet
                roundedInches = leftOver.ToString("0.00");
                //rounds inches to nearest hundreth place

                if (feet == 1)
                {
                    Console.WriteLine(userInput + " Centimeters is " + feet + " foot " + roundedInches + " inches");

                    //prints the gramatically correct "foot" if userInput evaluates to 1 and also provides ending statement to give user the conversion
                }
                else
                {
                    Console.WriteLine(userInput + " Centimeters is " + feet + " feet " + roundedInches + " inches");


                    //prints gramatically correct "feet" if userInput evaluates to less than one or more than 2 and provides user with statement containing accurate conversion
                }

                Console.WriteLine("Press 'Enter' to convert another value or enter 'P' to exit");


                quitProgram = "";
                quitProgram = Console.ReadLine();
                quitProgram = quitProgram.ToUpper();

                if (quitProgram == "P")
                {
                    Environment.Exit(0);
                    break;
                }
            }
        }

         
    }
}
 