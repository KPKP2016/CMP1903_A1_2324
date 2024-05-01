using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public static void Main(string[] _)
        {
            // asks he user if they want to run tests or if they want to start playing the game.
            Console.WriteLine("Run Tests or Begin Game? (1/2): ");
            String startChoice = Console.ReadLine();

            // exception handling
            while ((startChoice != "1") && (startChoice != "2"))
            {
                Console.WriteLine("Invalid Input");
                Console.WriteLine("Run Tests or Begin Game? (1/2): ");
                startChoice = Console.ReadLine();
            }

            // Tests run first
            if (startChoice == "1")
            {
                Testing.Test();
            }

            // games begin
            while (true)
            {
                string gameChoice = Menu();
                
                // gameChoice 1 is SevensOut
                if (gameChoice == "1")
                {
                    // loops until total dice roll is 7
                    while (true)
                    {
                        // new instance of SevensOut class
                        // Player1 turn
                        SevensOut playSevenP1 = new SevensOut();
                        Console.WriteLine("Player 1 Points: " + playSevenP1.DiceGame() + "\n"); // DiceGame method created

                        // after SevensOut game played, the final total is appended to a list for scores
                        Statistics.player1SevensScores.Add(Statistics.totalPlayer1Points);
                        Statistics.computerSevensScores.Add(Statistics.totalComputerPoints);

                        // if total of 2 dice is 7
                        if (Statistics.player1Points == 7)
                        {
                            Console.WriteLine("Player 1 Lost");
                            break;
                        }

                        // any other total
                        else
                        {
                            // new isntance of SevensOut class
                            // Computer turn
                            SevensOut playSevenComp = new SevensOut();
                            Console.WriteLine("Computer Points: " + playSevenComp.DiceGame() + "\n");

                            // if total of 2 dice is 7
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

                // gameChoice 2 is ThreeOrMore
                else if (gameChoice == "2")
                {
                    // loops as long as total is below 20
                    while ((Statistics.player1Points < 20) && (Statistics.computerPoints < 20))
                    {
                        // new instance of ThreeOrMore class
                        ThreeOrMore playThree = new ThreeOrMore();

                        // displays points corresponding to the player's turn
                        if (Statistics.player1 == true)
                        {
                            // new instance of ThreeOrMore class
                            // Player1 turn
                            Console.WriteLine("Player 1 points: " + playThree.DiceGame2() + "\n");
                        }
                        else if (Statistics.computer == true)
                        {
                            // new instance of ThreeOrMore class
                            // Computer turn
                            Console.WriteLine("Computer points: " + playThree.DiceGame2() + "\n");
                        }
                    }

                    // after ThreeOrMore game played, the final total is appended to a list for scores
                    Statistics.player1ThreeScores.Add(Statistics.totalPlayer1Points);
                    Statistics.computerThreeScores.Add(Statistics.totalComputerPoints);

                    // declares who wins or draws
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

                // gameChoice 3 is Stats
                else if (gameChoice == "3")
                {
                    Console.WriteLine("SevensOut stats or ThreeOrMore stats or Overall stats? (1/2/3): ");
                    String statsChoice = Console.ReadLine();

                    // exception handling
                    while ((statsChoice != "1") && (statsChoice != "2") && (statsChoice != "3"))
                    {
                        Console.WriteLine("Invalid Input");
                        Console.WriteLine("SevensOut stats or ThreeOrMore stats? (1/2/3): ");
                        statsChoice = Console.ReadLine();
                    }

                    // DisplayStats method called in Stats class with statsChoice as a parameter
                    Statistics.DisplayStats(statsChoice);
                }

                // gameChoice 4 is Quit
                else if (gameChoice == "4")
                {
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    break;
                }

                // choice to carry on or quit the game
                Console.WriteLine("\nDo you want to play another game? (1/2): ");
                string playAgain = Console.ReadLine();

                // exception handling
                while ((playAgain != "1") && (playAgain != "2"))
                {
                    Console.WriteLine("\nInvalid Input");
                    Console.WriteLine("Do you want to play another game? (1/2): ");
                    playAgain = Console.ReadLine();
                }

                // quits game
                if (playAgain == "2")
                {
                    Console.WriteLine("Goodbye");
                    Console.ReadKey();
                    break;
                }
            }
        }

        // Menu method
        public static string Menu()
        {
            // Reset method in Stats class called
            Statistics.Reset();

            Console.WriteLine("\n---------------------------------------------");
            Console.WriteLine("SevensOut or ThreeOrMore or Stats or Quit (1,2,3,4): ");
            String gameChoice = Console.ReadLine();

            // exception handling
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
            // RollTotal property
            private int _RollTotal;
            public int RollTotal
            {
                get { return _RollTotal; }
                set { _RollTotal = value; }
            }

            // DiceGame method
            public int DiceGame()
            {
                // 2 new die objects
                Die die1 = new Die();
                Die die2 = new Die();

                // roll
                int roll1 = die1.Roll();
                int roll2 = die2.Roll();

                Console.WriteLine("\nDie 1: " + roll1);
                Console.WriteLine("Die 2: " + roll2);

                RollTotal = roll1 + roll2;

                // if both rolls are the same, the sum is doubled and added to the score
                if (roll1 == roll2)
                {
                    RollTotal = (RollTotal) * 2;

                    // player1 turn
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Statistics.totalPlayer1Points += Statistics.player1Points;

                        // swaps players turn
                        Statistics.player1 = false;
                        Statistics.computer = true;

                        return Statistics.player1Points;
                    }

                    // computer turn
                    else if (Statistics.computer == true)
                    {
                        Statistics.computerPoints = RollTotal;
                        Statistics.totalComputerPoints += Statistics.computerPoints;

                        // swaps players turn
                        Statistics.computer = false;
                        Statistics.player1 = true;

                        return Statistics.computerPoints;
                    }
                    else
                    {
                        return 0;
                    }
                }

                // if any number except 7
                else if (RollTotal != 7)
                {
                    // player1 turn
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Statistics.totalPlayer1Points += Statistics.player1Points;

                        // swaps players turns
                        Statistics.player1 = false;
                        Statistics.computer = true;

                        return Statistics.player1Points;
                    }

                    // computer turn
                    else if (Statistics.computer == true)
                    {
                        Statistics.computerPoints = RollTotal;
                        Statistics.totalComputerPoints += Statistics.computerPoints;

                        // swaps players turn
                        Statistics.computer = false;
                        Statistics.player1 = true;

                        return Statistics.computerPoints;
                    }
                    else
                    {
                        return 0;
                    }
                }

                // sum of dice is 7
                else
                {
                    // player1 turn
                    if (Statistics.player1 == true)
                    {
                        Statistics.player1Points = RollTotal;
                        Console.WriteLine("Player 1 Total is 7");
                        Statistics.player1 = false;
                        return Statistics.player1Points;
                    }

                    // computer turn
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

        // ThreeOrMore game
        internal class ThreeOrMore
        {
            public int DiceGame2()
            {
                // points corrolate to the amount of in-a-row
                Dictionary<int, int> pointSystem = new Dictionary<int, int>
                {
                    {1, 0 },
                    {3, 3 },
                    {4, 6 },
                    {5, 12 },
                };

                while (true)
                {
                    // puts rolled numbers in a list
                    List<int> rolledList = new List<int>();
                    // puts die object inside list
                    List<Die> dies = new List<Die>();
                    // multiple same numbers rolled stored in list
                    int[] duplicates = new int[6];

                    // 5 die rolled and stored
                    for (int i = 0; i < 5; i++)
                    {
                        Die die = new Die();
                        dies.Add(die);
                        int roll = die.Roll();
                        rolledList.Add(roll);
                        duplicates[roll - 1] += 1;
                    }

                    int biggest = 0;
                    for (int i = 0; i < 6; i++)
                    {
                        if (duplicates[i] > duplicates[biggest])
                        {
                            biggest = i;
                        }
                    }

                    int rollNumber = duplicates[biggest];

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
                        // if 2 of a kind is 2, choice between roll all die or roll remaining die
                        if (rollNumber == 2)
                        {
                            Console.WriteLine("Rethrow all dice or remaining dice. (1/2):");
                            string retry = Console.ReadLine();

                            // exception handling
                            while (retry != "1" && retry != "2")
                            {
                                Console.WriteLine("Invalid Input. Rethrow all dice or remaining dice. (1/2):");
                                retry = Console.ReadLine();
                            }

                            // reroll all 5 die because of while loop
                            if (retry == "1")
                            {
                                continue; // Re-roll all dice
                            }

                            // removes values that are of-a-kind
                            else if (retry == "2")
                            {
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

                        // any other of-a-kind
                        else
                        {
                            // using dictionary to get value associated to of-a-kind
                            if (pointSystem.TryGetValue(rollNumber, out int result))
                            {
                                // player1 turn
                                if (Statistics.player1 == true)
                                {
                                    Console.WriteLine($"+{result} Points to Player 1");
                                    Statistics.player1Points += result;
                                    Console.WriteLine("Player 1 Total Points: " + Statistics.player1Points);
                                }

                                // computer turn
                                else if (Statistics.computer == true)
                                {
                                    Console.WriteLine($"+{result} Points to Computer");
                                    Statistics.computerPoints += result;
                                    Console.WriteLine("Computer Total Points: " + Statistics.computerPoints);
                                }
                            }

                            // exception handling
                            else
                            {
                                Console.WriteLine($"{rollNumber} in-a-row not found in the dictionary.");
                            }

                            // any other number just swaps turn
                            if (rollNumber != 2)
                            {
                                Statistics.player1 = !Statistics.player1;
                                Statistics.computer = !Statistics.computer;
                            }
                        }
                    }

                    // exception handling
                    catch (FormatException)
                    {
                        Console.WriteLine("Enter valid input.");
                    }

                    // checks which player has won
                    if (Statistics.player1Points >= 20 || Statistics.computerPoints >= 20)
                    {
                        // player1 won
                        if (Statistics.player1Points > Statistics.computerPoints)
                        {
                            Statistics.totalPlayer1Points = Statistics.player1Points;
                            Statistics.totalComputerPoints = Statistics.computerPoints;
                            return Statistics.player1Points;
                        }

                        // computer won
                        else if (Statistics.player1Points < Statistics.computerPoints)
                        {
                            Statistics.totalPlayer1Points = Statistics.player1Points;
                            Statistics.totalComputerPoints = Statistics.computerPoints;
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