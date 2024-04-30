using System.Diagnostics;

namespace CMP1903_A1_2324
{
    internal class Testing
    {
        // runs both methods.
        public Testing()
        {
            // testing is run before the final output
            Game.isTesting = true;
            TestSevensOut();
            //TestDiceSumSevensOut();
            Game.isTesting = false;
        }
        public void TestSevensOut()
        {
            Game.SevensOut sevensOutTest = new Game.SevensOut();

            int total = 0;
            while (true)
            {
                total = sevensOutTest.DiceGame();
                Debug.Assert(total > 2 && total < 19, "Total sum of the rolled dice, is out of bounds");

                Debug.Assert(total != 7, "\nTest Failed: Game didn't stop when total equals 7.\n");
                if (total == 7)
                {
                    Debug.WriteLine("Test Passed: Game stops when total equals 7.");
                    break;
                }
            }
        }

        public void TestDiceSumSevensOut()
        {
            // Creates new TestSum object
            Game.SevensOut testPlay = new Game.SevensOut();
            int TestSum = testPlay.DiceGame();

            // Tests if sum is inside bounds
            Debug.Assert(TestSum > 1 && TestSum < 13, "Total sum of the rolled dice, is out of bounds");
            /*Debug.Assert(TestSum == 7, "Game Over");*/
        }

        
    }
}











