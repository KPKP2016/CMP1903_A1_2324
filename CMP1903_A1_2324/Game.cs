using System;
using System.Collections.Generic;
using System.Runtime.InteropServices.ComTypes;
using System.Security.Cryptography.X509Certificates;

namespace CMP1903_A1_2324
{
    internal class Game
    {
        public static bool isTesting = false;
        public static void Main(string[] args)
        {
            // creates play object and starts the game.

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
                Console.WriteLine("Total: " + playSeven.DiceGame());
            }
            else if(gameChoice == "2")
            {
                Game.ThreeOrMore playThree = new Game.ThreeOrMore();
                Console.WriteLine("points: " + playThree.DiceGame2());
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
                int Points = 0;

                Die die1 = new Die();
                Die die2 = new Die();
                Die die3 = new Die();
                Die die4 = new Die();
                Die die5 = new Die();

                int roll1 = die1.Roll();
                int roll2 = die2.Roll();
                int roll3 = die3.Roll();
                int roll4 = die4.Roll();
                int roll5 = die5.Roll();

                rolledList.Add(roll1);
                rolledList.Add(roll2);
                rolledList.Add(roll3);
                rolledList.Add(roll4);
                rolledList.Add(roll5);



                // do this

                if (Game.isTesting == false)
                {
                    Console.WriteLine("Die 1: " + roll1);
                    Console.WriteLine("Die 2: " + roll2);
                    Console.WriteLine("Die 3: " + roll3);
                    Console.WriteLine("Die 4: " + roll4);
                    Console.WriteLine("Die 5: " + roll5);
                }

                if (roll1 == roll2)
                {
                    return 1;
                }

                else
                {
                    return 0;
                }
            }
        }
    }
}