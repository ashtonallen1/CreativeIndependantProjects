using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RandomNumberGuess
{
    class Program
    {
        static int randomNumber;
        static int guessLimit;
        static string userGuess;
        static int userNumber;
        static string quit;
        //initializes all varibles in classes other than main
        static void Main(string[] args)
        {

            while (true)
            {
                Console.WriteLine("Welcome to Number Guess \nPlease Choose a Difficulty (Easy, Medium, Hard) or enter 'p' to exit"); //prompts for user difficulty choice
                SelectDifficulty(); //calls SelectDifficulty class which establish difficulty of gameplay
                NumberGuess(); //calls NumberGuess class where the gameplay/win/lose take place
            }
        }
        static void SelectDifficulty()
        {
            string userDifficulty = "";
            userDifficulty = Console.ReadLine(); //stores users difficulty choice
            userDifficulty = userDifficulty.ToUpper(); //makes userinput uppercase to reduce possible errors
            Random rnd = new Random(); //establishes new random

            if (userDifficulty == "P")
            {
                Environment.Exit(0); //allows user to quit from the beginning
            }

            else
            {
                if (userDifficulty == "EASY")
                {
                    randomNumber = rnd.Next(1, 10); //generates easy ranger of numbers. Same for medium and hard
                    guessLimit = 5; //establishes amount of guesses user is granted
                    Console.WriteLine("Please guess a number between 1 and 10"); 
                    //Console.WriteLine("Number is: " + randomNumber); used for testing wins
                }
                else if (userDifficulty == "MEDIUM")
                {
                    randomNumber = rnd.Next(1, 20);
                    guessLimit = 10;
                    Console.WriteLine("Please guess a number between 1 and 20");
                }
                else if (userDifficulty == "HARD")
                {
                    randomNumber = rnd.Next(1, 50);
                    guessLimit = 20;
                    Console.WriteLine("Please guess a number between 1 and 50");
                }
            }
        }

        static void NumberGuess()
        {
            
            int guess; //intakes user's number guess
            while (!int.TryParse(Console.ReadLine(), out guess))
            {            
                   //informs user if they did not enter an integer by checking for exceptions
                    Console.WriteLine("You did not input a valid number! Please input an integer and try again.");      
            }

                if (userNumber != randomNumber)
                {

                    if (guessLimit <= 1) //user has run out of guesses and lost the game
                    {
                        Console.WriteLine("You did not guess the correct number. The correct number was: " + randomNumber + "\nPress Enter to Replay or enter 'P' to Quit");

                        quit = "";
                        quit = Console.ReadLine();
                        quit = quit.ToUpper(); //accepts input if user wishes to quit, does nothing otherwise. Also capitalizes 'P' to reduce user error

                        if (quit == "P")
                        {
                            Environment.Exit(0); //exits program
                        }
                    }

                    else
                    {
                        guessLimit--; //subtracts 1 from guess limit until guess limit becomes 0
                        Console.WriteLine("You did not get the number correct. You have " + guessLimit + " guesses remaining");
                        NumberGuess(); //reruns this method so user can continue guessing
                    }

                }

                else
                {
                    Console.WriteLine("Congratulations, you win a free 5 pound bag of anthrax! \nPress Enter to Replay or enter 'P' to Quit");
                    quit = "";
                    quit = Console.ReadLine();
                    quit = quit.ToUpper();

                    if (quit == "P")
                    {
                        Environment.Exit(0);
                    }

                }
            }
        }
    }



