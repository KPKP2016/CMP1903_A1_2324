using System;
using System.Diagnostics;
using static CMP1903_A1_2324.Game;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        internal abstract class GameTester
        {
            public abstract void TestGame();
        }

        // testing SevensOut class
        internal class SevensOutTester : GameTester
        {
            public override void TestGame()
            {
                // new instance of SevensOut class
                SevensOut sevensOut = new SevensOut();
                // calls DiceGame method to play game
                int result = sevensOut.DiceGame();
                // Asserting conditions to check if the result is within expected range
                Debug.Assert(result >= 0, "SevensOut test failed: Result is negative");
                Debug.Assert(result <= 14, "SevensOut test failed: Result is greater than 14");
                Debug.Assert(result != 7, "SevensOut test failed: Result is 7");
                Console.WriteLine("SevensOut test passed");
            }
        }

        // testing ThreeOrMore class
        internal class ThreeOrMoreTester : GameTester
        {
            public override void TestGame()
            {
                // new instance of ThreeOrMore class
                ThreeOrMore threeOrMore = new ThreeOrMore();
                // calls DiceGame2 method to play game
                int result = threeOrMore.DiceGame2();
                // Asserting conditions to check if the result is within expected range
                Debug.Assert(result >= 0, "ThreeOrMore test failed: Result is negative");
                Debug.Assert(result <= 20, "ThreeOrMore test failed: Result is greater than 20");
                Console.WriteLine("ThreeOrMore test passed");
            }
        }

        

        internal static void Test()
        {
            // displays SevensOut testing
            Console.WriteLine("Testing SevensOut in progress...");
            GameTester sevensOutTester = new SevensOutTester();
            sevensOutTester.TestGame();

            Statistics.Reset();

            // displays ThreeOrMore testing
            Console.WriteLine("\nTesting ThreeOrMore in progress...");
            GameTester threeOrMoreTester = new ThreeOrMoreTester();
            threeOrMoreTester.TestGame();

            Statistics.Reset();
        }
    }
}









