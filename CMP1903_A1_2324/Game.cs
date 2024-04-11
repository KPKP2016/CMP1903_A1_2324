using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public static bool isTesting = false;

        public static void Main(string[] _)
        {

            Console.WriteLine("SevensOut or ThreeOrMore? (1,2): ");
            String gameChoice = Console.ReadLine();

            while ((gameChoice != "1") && (gameChoice != "2"))
            {
                Console.WriteLine("SevensOut or ThreeOrMore? (1,2): ");
                gameChoice = Console.ReadLine();
            }

            if (gameChoice == "1")
            {
                Game.SevensOut playSeven = new Game.SevensOut();
                Console.WriteLine("Points: " + playSeven.DiceGame());
            }
            else if(gameChoice == "2")
            {
                while ((Statistics.player1Points < 20) && (Statistics.player2Points < 20))
                {
                    Game.ThreeOrMore playThree = new Game.ThreeOrMore();
                    Console.WriteLine("points: " + playThree.DiceGame2());
                }

                if (Statistics.player1Points > Statistics.player2Points)
                {
                    Console.WriteLine("Player 1 Wins");
                }

                else if (Statistics.player1Points == Statistics.player2Points)
                {
                    Console.WriteLine("Draw");
                }

                else
                {
                    Console.WriteLine("Player 2 Wins");
                }
                // figure out point system for both players

            }
            Console.ReadKey();
        }

        // SevensOut game
        internal class SevensOut
        {
            
            public int DiceGame()
            {
                Die die1 = new Die();
                Die die2 = new Die();

                int roll1 = die1.Roll();
                int roll2 = die2.Roll();

                int RollTotal = roll1 + roll2;

                if (Game.isTesting == false)
                {
                    Console.WriteLine("Die 1: " + roll1);
                    Console.WriteLine("Die 2: " + roll2);
                }

                if (RollTotal != 7)
                {
                    return RollTotal;
                }
                else if (die1 == die2)
                {
                    RollTotal = (roll1 + roll2) * 2;
                    return RollTotal;
                }
                else
                {
                    Console.WriteLine("Your Total is 7, Game Ended.");
                    return 0;
                }
            }
        }

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

                Console.WriteLine($"Most frequent die number is: {biggest+1}. Highest in-a-row: {rollNumber}");


                




                try
                {
                    if (rollNumber == 2)
                    {
                        Console.WriteLine("Rethrow all die or remaining die. (1/2): ");
                        String retry = Console.ReadLine(); 
                        if (retry == "1")
                        {
                            Game.ThreeOrMore playThree = new Game.ThreeOrMore();
                            Console.WriteLine(playThree.DiceGame2());
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
                            Console.WriteLine($"{ result} Points");
                            Statistics.player1Points += result;
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

                return Statistics.player1Points;


 

                //for (int i = 0; i < rolledList.Count; i++)
                //{
                //    for (int j = 0; j < rolledList.Count; j++)
                //    {
                //        if (rolledList[i] == rolledList[j])
                //        {
                //            duplicates.Add(rolledList[i]);
                //        }
                //    }
                //}

                //duplicates.Sort();

                //foreach (int item in duplicates)
                //{
                //    Console.WriteLine(item);
                //}

                //// do this

                //if (Game.isTesting == false)
                //{
                //    Console.WriteLine("Die 1: " + roll1);
                //    Console.WriteLine("Die 2: " + roll2);
                //    Console.WriteLine("Die 3: " + roll3);
                //    Console.WriteLine("Die 4: " + roll4);
                //    Console.WriteLine("Die 5: " + roll5);
                //    return 1;
                //}
                //else
                //{
                //    return 0;
                //}
            }
        }
    }
}