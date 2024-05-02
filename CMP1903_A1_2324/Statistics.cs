using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        // player1 turn first
        public static bool player1 = true;
        public static bool computer = false;
        
        public static int player1Points;
        public static int computerPoints;

        public static int totalPlayer1Points;
        public static int totalComputerPoints;

        // SevensOut scores
        public static List<int> player1SevensScores = new List<int>();
        public static List<int> computerSevensScores = new List<int>();

        // ThreeOrMore scores
        public static List<int> player1ThreeScores = new List<int>();
        public static List<int> computerThreeScores = new List<int>();

        // Resets all scores
        public static void Reset()
        {
            player1 = true;
            computer = false;

            player1Points = 0;
            computerPoints = 0;

            totalPlayer1Points = 0;
            totalComputerPoints = 0;

        }

        // Shows the stats from the menu system in Game class
        public static void DisplayStats(string statsChoice)
        {
            // SevensOut class
            if (statsChoice == "1")
            {
                Console.WriteLine("\nPlayer 1 SevensOut Stats:");

                int p1GameIndex = 1;
                foreach (int p1Game in player1SevensScores)
                {
                    Console.WriteLine("Game " + p1GameIndex + ": " + p1Game);
                    p1GameIndex++;
                }

                Console.WriteLine("\nComputer SevensOut Stats:");

                int compGameIndex = 1;
                foreach (int compGame in computerSevensScores)
                {
                    Console.WriteLine("Game " + compGameIndex + ": " + compGame);
                    compGameIndex++;
                }
            }

            // ThreeOrMore class
            else if (statsChoice == "2")
            {
                Console.WriteLine("\nPlayer 1 ThreeOrMore Stats:");

                int p1GameIndex = 1;
                foreach (int p1Game in player1ThreeScores)
                {
                    Console.WriteLine("Game " + p1GameIndex + ": " + p1Game);
                    p1GameIndex++;
                }

                Console.WriteLine("\nComputer ThreeOrMore Stats:");

                int compGameIndex = 1;
                foreach (int compGame in computerThreeScores)
                {
                    Console.WriteLine("Game " + compGameIndex + ": " + compGame);
                    compGameIndex++;
                }
            }

            // Both game class
            else if (statsChoice == "3")
            {
                Console.WriteLine("\nPlayer 1 SevensOut Stats:");

                int p1GameIndex = 1;
                foreach (int p1Game in player1SevensScores)
                {
                    Console.WriteLine("Game " + p1GameIndex + ": " + p1Game);
                    p1GameIndex++;
                }

                Console.WriteLine("\nComputer SevensOut Stats:");

                int compGameIndex = 1;
                foreach (int compGame in computerSevensScores)
                {
                    Console.WriteLine("Game " + compGameIndex + ": " + compGame);
                    compGameIndex++;
                }

                Console.WriteLine("\nPlayer 1 ThreeOrMore Stats:");

                p1GameIndex = 1;
                foreach (int p1Game in player1ThreeScores)
                {
                    Console.WriteLine("Game " + p1GameIndex + ": " + p1Game);
                    p1GameIndex++;
                }

                Console.WriteLine("\nComputer ThreeOrMore Stats:");

                compGameIndex = 1;
                foreach (int compGame in computerThreeScores)
                {
                    Console.WriteLine("Game " + compGameIndex + ": " + compGame);
                    compGameIndex++;
                }
            }
        }
    }
}
