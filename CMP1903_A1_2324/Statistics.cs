using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CMP1903_A1_2324
{
    internal class Statistics
    {
        public static bool player1 = true;
        public static bool computer = false;
        
        public static int player1Points;
        public static int computerPoints;

        public static int totalPlayer1Points;
        public static int totalComputerPoints;

        public static List<int> player1SevensScores = new List<int>();
        public static List<int> computerSevensScores = new List<int>();

        public static List<int> player1ThreeScores = new List<int>();
        public static List<int> computerThreeScores = new List<int>();
        public static void Reset()
        {
            player1 = true;
            computer = false;

            player1Points = 0;
            computerPoints = 0;

            totalPlayer1Points = 0;
            totalComputerPoints = 0;

        }
    }
}
