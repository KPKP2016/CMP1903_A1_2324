using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.CompilerServices;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;
using static System.Net.Mime.MediaTypeNames;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public static bool isTesting = false;

        public static void Main(string[] _)
        {
            

            while (true)
            {
                string gameChoice = Menu();

                if (gameChoice == "1")
                {
                    while (true)
                    {
                        SevensOut playSevenP1 = new SevensOut();
                        Console.WriteLine("Player 1 Points: " + playSevenP1.DiceGame() + "\n");

                        if (Statistics.player1Points == 7)
                        {
                            Console.WriteLine("Player 1 Lost");
                            break;
                        }

                        else
                        {
                            SevensOut playSevenComp = new SevensOut();
                            Console.WriteLine("Computer Points: " + playSevenComp.DiceGame() + "\n");

                            if (Statistics.computerPoints == 7)
                            {
                                Console.WriteLine("Computer Lost");
                                break;
                            }
                            else
                            {
                                continue;
                            }
                        }
                    }
                }





                else if (gameChoice == "2")
                {
                    while ((Statistics.player1Points < 20) && (Statistics.computerPoints < 20))
                    {
                        ThreeOrMore playThree = new ThreeOrMore();

                        if (Statistics.player1 == true)
                        {
                            Console.WriteLine("Player 1 points: " + playThree.DiceGame2() + "\n");
                        }
                        else if (Statistics.computer == true)
                        {
                            Console.WriteLine("Computer points: " + playThree.DiceGame2() + "\n");
                        }

                    }

                    if (Statistics.player1Points > Statistics.computerPoints)
                    {
                        Console.WriteLine("Player 1 Wins");
                    }

                    else if (Statistics.player1Points == Statistics.computerPoints)
                    {
                        Console.WriteLine("Draw");
                    }

                    else
                    {
                        Console.WriteLine("Computer Wins");

                    }
                }




                else if (gameChoice == "3")
                {
                    Console.WriteLine("\nPlayer 1 Stats: " + Statistics.totalPlayer1Points);
                    Console.WriteLine("Computer Stats: " + Statistics.totalComputerPoints);
                    
                }






                else if (gameChoice == "4")
                {
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    break;
                }





                Console.WriteLine("\nDo you want to play another game? (1/2): ");
                string playAgain = Console.ReadLine();


                while ((playAgain != "1") && (playAgain != "2"))
                {
                    Console.WriteLine("\nInvalid Input");
                    Console.WriteLine("Do you want to play another game? (1/2): ");
                    playAgain = Console.ReadLine();
                }

                if (playAgain == "2")
                {
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    break;
                }
            }
        }




        public static string Menu()
        {
            
            Statistics.player1 = true;
            Statistics.computer = false;

            Statistics.player1Points = 0;
            Statistics.computerPoints = 0;

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("SevensOut or ThreeOrMore or Stats or Quit (1,2,3,4): ");
            String gameChoice = Console.ReadLine();

            while ((gameChoice != "1") && (gameChoice != "2") && (gameChoice != "3") && (gameChoice != "4"))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("SevensOut or ThreeOrMore or Stats (1,2,3,4): ");
                gameChoice = Console.ReadLine();
            }

            return gameChoice;
        }

        // SevensOut game
        internal class SevensOut
        {
            private int _RollTotal;
            public int RollTotal
            {
                get { return _RollTotal; }
                set { _RollTotal = value; }
            }

            public int DiceGame()
            {
                Die die1 = new Die();
                Die die2 = new Die();

                int roll1 = die1.Roll();
                int roll2 = die2.Roll();

                Console.WriteLine("\nDie 1: " + roll1);
                Console.WriteLine("Die 2: " + roll2);

                RollTotal = roll1 + roll2;

                if (roll1 == roll2)
                {
                    RollTotal = (RollTotal) * 2;

                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Statistics.totalPlayer1Points += Statistics.player1Points;

                        Statistics.player1 = false;
                        Statistics.computer = true;

                        return Statistics.player1Points;
                    }
                    else if (Statistics.computer == true)
                    {
                        Statistics.computerPoints = RollTotal;
                        Statistics.totalComputerPoints += Statistics.computerPoints;

                        Statistics.computer = false;
                        Statistics.player1 = true;

                        return Statistics.computerPoints;
                    }
                    else
                    {
                        return 0;
                    }
                }

                else if (RollTotal != 7)
                {
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Statistics.totalPlayer1Points += Statistics.player1Points;

                        Statistics.player1 = false;
                        Statistics.computer = true;

                        return Statistics.player1Points;
                    }
                    else if (Statistics.computer == true)
                    {
                        Statistics.computerPoints = RollTotal;
                        Statistics.totalComputerPoints += Statistics.computerPoints;

                        Statistics.computer = false;
                        Statistics.player1 = true;

                        return Statistics.computerPoints;
                    }
                    else
                    {
                        return 0;
                    }   
                }

                else
                {
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Console.WriteLine("Player 1 Total is 7");
                        Statistics.player1 = false;
                        return Statistics.player1Points;
                    }
                    else if (Statistics.computer == true)
                    {
                        Statistics.computerPoints = RollTotal;
                        Console.WriteLine("Computer Total is 7");
                        Statistics.computer = false;
                        return Statistics.computerPoints;
                    }
                    else
                    {
                        return 0;
                    }

                }
            }
        }

        // ThreeOrMore Game
        internal class ThreeOrMore
        {
            public int DiceGame2()
            {
                Dictionary<int, int> pointSystem = new Dictionary<int, int>
                {
                    {1, 0 },
                    {3, 3 },
                    {4, 6 },
                    {5, 12 },
                };

                while (true)
                {
                    List<int> rolledList = new List<int>();
                    List<Die> dies = new List<Die>();
                    int[] duplicates = new int[6];

                    // Roll the dice
                    for (int i = 0; i < 5; i++)
                    {
                        Die die = new Die();
                        dies.Add(die);
                        int roll = die.Roll();
                        rolledList.Add(roll);
                        duplicates[roll - 1] += 1;
                    }

                    // Determine the most frequent number rolled
                    int biggest = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        if (duplicates[i] > duplicates[biggest])
                        {
                            biggest = i;
                        }
                    }

                    int rollNumber = duplicates[biggest];

                    // Display current player's turn and rolls
                    if (Statistics.player1 == true)
                    {
                        Console.WriteLine("\n---Player 1's turn---");
                    }
                    else if (Statistics.computer == true)
                    {
                        Console.WriteLine("\n---Computer's turn---");
                    }

                    Console.WriteLine("Dice Rolls:");
                    foreach (var item in rolledList)
                    {
                        Console.WriteLine(item.ToString());
                    }

                    Console.WriteLine($"Most frequent die number: {biggest + 1}. Highest in-a-row: {rollNumber}");

                    try
                    {
                        if (rollNumber == 2)
                        {
                            Console.WriteLine("Rethrow all dice or remaining dice. (1/2):");
                            string retry = Console.ReadLine();

                            while (retry != "1" && retry != "2")
                            {
                                Console.WriteLine("Invalid Input. Rethrow all dice or remaining dice. (1/2):");
                                retry = Console.ReadLine();
                            }

                            if (retry == "1")
                            {
                                continue; // Re-roll all dice
                            }
                            else if (retry == "2")
                            {
                                // Remove the dice that are not rolled again
                                for (int i = 0; i < rolledList.Count; i++)
                                {
                                    if (rolledList[i] != 2)
                                    {
                                        rolledList.RemoveAt(i);
                                        dies.RemoveAt(i);
                                        i--;
                                    }
                                }
                            }
                        }
                        else
                        {
                            // Accumulate points for the current player
                            if (pointSystem.TryGetValue(rollNumber, out int result))
                            {
                                if (Statistics.player1 == true)
                                {
                                    Console.WriteLine($"+{result} Points to Player 1");
                                    Statistics.player1Points += result;
                                    Console.WriteLine("Player 1 Total Points: " + Statistics.player1Points);
                                }
                                else if (Statistics.computer == true)
                                {
                                    Console.WriteLine($"+{result} Points to Computer");
                                    Statistics.computerPoints += result;
                                    Console.WriteLine("Computer Total Points: " + Statistics.computerPoints);
                                }
                            }
                            else
                            {
                                Console.WriteLine($"{rollNumber} in-a-row not found in the dictionary.");
                            }

                            // Switch turns only when a number other than 2 is rolled
                            if (rollNumber != 2)
                            {
                                Statistics.player1 = !Statistics.player1;
                                Statistics.computer = !Statistics.computer;
                            }
                        }
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter valid input.");
                    }

                    // Break the loop if both players' points reach 20
                    if (Statistics.player1Points >= 20 || Statistics.computerPoints >= 20)
                    {
                        if (Statistics.player1Points > Statistics.computerPoints)
                        {
                            return Statistics.player1Points;
                        }

                        else if (Statistics.player1Points < Statistics.computerPoints)
                        {
                            return Statistics.computerPoints;
                        }

                        else
                        {
                            return 0;
                        }
                    }
                }
            }
        }

    }
}