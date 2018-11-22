using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lottery
{
    class LotteryModel
    {
        //All the basic variables for this program.
        public static string name;
        public static int[] chosenNumbers = new int[10];
        public static int[] winningNumbers = new int[7];
        public static int minValue = 1;
        public static int maxValue = 25;
        public static int userInput = 0;
        public static int randomNumber = 0;
        public static int points = 0;
        public static bool found = false;
        public static Random randomizer = new Random();

        //The method to handle unexpected errors!
        public static int CleanedInput()
        {
            try
            {
                userInput = int.Parse(Console.ReadLine());
            }
            catch
            {
                Console.WriteLine($"Please only use integer between {minValue} - {maxValue}");
            }
            return userInput;
        }
        //The method to take the users input. Two differend for loops in this method within eachother with if and else to make sure we do not get any duplicates and numbers out of range.
        public static int[] UserInput()
        {
            for (int input = 0; input < chosenNumbers.Length; input++)
            {
                userInput = CleanedInput();
                for (int duplicate = 0; duplicate < chosenNumbers.Length; duplicate++)
                {
                    if (userInput == chosenNumbers[duplicate])
                    {
                        Console.WriteLine("no duplicates! You little cheater ;)");
                        input--;
                        found = false;
                    }
                }

                if (userInput > 0 && userInput < 26)
                {
                    chosenNumbers[input] = userInput;
                }
                else
                {
                    Console.WriteLine($"Please only chose numbers between {minValue} - {maxValue}");
                    input--;
                }
            }
            return chosenNumbers;
        }
        //The method to generate the seven random numbers which after that make sure it wont get any duplicates and checking the users score.
        public static int[] TheLottery()
        {
            for (int input = 0; input < winningNumbers.Length; input++)
            {
                randomNumber = randomizer.Next(1, 26);
                for (int check = 0; check < winningNumbers.Length; check++)
                {
                    if (randomNumber == winningNumbers[check])
                    {
                        found = (true);
                    }
                }

                if (found == false)
                {
                    winningNumbers[input] = randomNumber;
                    for (int correct = 0; correct < chosenNumbers.Length; correct++)
                    {
                        if (randomNumber == chosenNumbers[correct])
                        {
                            points++;
                        }
                    }
                }

                if (found == true)
                {
                    input--;
                    found = false;
                }
            }
            //When the user have given the desired numbers and the program has generated the winning numbers this will be presented with a score system.
            Console.WriteLine("Your chosen numbers: \n [{0}]", string.Join(", ", chosenNumbers));
            Console.WriteLine("The winning numbers: \n [{0}]", string.Join(", ", winningNumbers));
            Console.WriteLine($"you got: {points} points!");
            if (points < 5)
            {
                Console.WriteLine($"Too bad {name}! you did not win anything today. Better luck next time!");
            }
            if (points >= 5 && points <= 6)
            {
                Console.WriteLine($"You are very Lucky today {name} you won $100!");
            }
            if (points == 7)
            {
                Console.WriteLine($"CONGRATULATIONS {name}! You won the jackpot of $100,000!");
            }
            return chosenNumbers;
        }
    }

    class Lotto
    {
        public static void Main(string[] args)
        {   //Welcomming text and the command needed to call the method to make this program work.
            Console.WriteLine($"Welcome to the lottery game! Please enter you name!");
            LotteryModel.name = Console.ReadLine();
            Console.WriteLine($"Hello {LotteryModel.name}! Please enter your ten lucky numbers between {LotteryModel.minValue} - {LotteryModel.maxValue} : ");
            LotteryModel.UserInput();
            LotteryModel.TheLottery();
            Console.ReadKey();
        }
    }
}