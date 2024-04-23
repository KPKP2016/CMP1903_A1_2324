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
                    else
                    {
                        Console.WriteLine("Computer points: " + playThree.DiceGame2() + "\n");
                    }

                    Console.WriteLine("points: " + playThree.DiceGame2() + "\n");
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
                Console.WriteLine("Player 1 Stats: ", Statistics.player1Points);
                Console.WriteLine("Computer Stats: ", Statistics.computerPoints);

            }
            Console.ReadKey();
        }

        private static string Menu()
        {
            Console.WriteLine("---------------------------------------------");
            Console.WriteLine("SevensOut or ThreeOrMore or Stats (1,2,3): ");
            String gameChoice = Console.ReadLine();

            while ((gameChoice != "1") && (gameChoice != "2") && (gameChoice != "3"))
            {
                Console.WriteLine("Invalid input");
                Console.WriteLine("SevensOut or ThreeOrMore or Stats (1,2,3): ");
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
                    return RollTotal;
                }

                else if (RollTotal != 7)
                {
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;

                        Statistics.player1 = false;
                        Statistics.computer = true;

                        return Statistics.player1Points;
                    }
                    else
                    {
                        Statistics.computerPoints = RollTotal;

                        Statistics.computer = false;
                        Statistics.player1 = true;

                        return Statistics.computerPoints;
                    }
                }

                else
                {
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Console.WriteLine("Player 1 Total is 7");
                        Statistics.player1 = false;
                        return 0;
                    }
                    else if (Statistics.computer == true)
                    {
                        Statistics.computerPoints = RollTotal;
                        Console.WriteLine("Computer Total is 7");
                        Statistics.computer = false;
                        return 0;
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
                List<int> rolledList = new List<int>();
                int[] duplicates = new int[6];

                Dictionary<int, int> pointSystem = new Dictionary<int, int>
                {
                    {1, 0 },
                    {3, 3 },
                    {4, 6 },
                    {5, 12 },
                };

                for (int i = 0; i < 5; i++)
                {
                    Die die = new Die();
                    int roll = die.Roll();
                    rolledList.Add(roll);
                    duplicates[roll - 1] += 1;
                }

                int biggest = 0;

                for (int i = 0; i < 6;i++)
                {
                    if (duplicates[i] > duplicates[biggest])
                    {
                        biggest = i;
                    }
                }

                int rollNumber = duplicates[biggest];


                if (Statistics.player1 == true)
                {
                    Console.WriteLine("\n---Player 1's turn---\n");
                }
                else
                {
                    Console.WriteLine("\n---Computer's turn---\n");
                }

                Console.WriteLine($"Most frequent die number: {biggest+1}. Highest in-a-row: {rollNumber}");

                try
                {
                    if (rollNumber == 2)
                    {
                        Console.WriteLine("Rethrow all die or remaining die. (1/2):\n");
                        String retry = Console.ReadLine(); 
                        if (retry == "1")
                        {
                            Game.ThreeOrMore playThree = new Game.ThreeOrMore();
                            playThree.DiceGame2();
                        }
                        else if (retry == "2")
                        {
                            Console.WriteLine("Rethrow other dice");
                        }
                    }
                    
                    else
                    {
                        if (pointSystem.TryGetValue(rollNumber, out int result))
                        {

                            
                            if (Statistics.player1 == true)
                            {
                                Console.WriteLine($"+{result} Points to Player 1");
                                Statistics.player1Points += result;

                                Statistics.player1 = false;
                                Statistics.computer = true;
                            }
                            else
                            {
                                Console.WriteLine($"+{result} Points to Computer");
                                Statistics.computerPoints += result;

                                Statistics.computer = false;
                                Statistics.player1 = true;
                            }
                            
                        }

                        else
                        {
                            Console.WriteLine($"{rollNumber} in-a-row not found in the dictionary.");
                        }
                    }
                }

                catch (FormatException)
                {
                    Console.WriteLine("Enter valid input. ");
                }

                if (Statistics.player1 == true)
                {
                    return Statistics.player1Points;
                }
                else
                {
                    return Statistics.computerPoints;
                }
                
            }
        }
    }
}