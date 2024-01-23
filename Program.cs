// See https://aka.ms/new-console-template for more information
using System.Runtime.CompilerServices;
using System.Threading.Tasks;

class RollingDice
{
    static void Main(string[] args)
    {
        Console.WriteLine("Welcome to the dice throwing simulator!\n");
        Console.WriteLine("How many dice rolls would you like to simulate?");


        int numRollsInput = Convert.ToInt32(Console.ReadLine());

        // create DiceSimulate object
        DiceSimulate diceSimulate = new DiceSimulate(numRollsInput);

        // method call
        int[] rollResults = diceSimulate.countCombineDice();

        Console.WriteLine("\nDICE ROLLING SIMULATION RESULTS");
        Console.WriteLine("Each \"*\" represents 1% of the total number of rolls.");
        Console.WriteLine("Total number of rolls = " + numRollsInput + "\n");

        for (int i = 0; i < 11; i++)
        {
            Console.Write((i + 2) + ": ");
            int percentage = (int)((rollResults[i] / (double)numRollsInput) * 100);
            for (int j = 0; j < percentage; j++)
            {
                Console.Write("*");
            }
            Console.WriteLine();
        }

        Console.WriteLine("\nThank you for using the dice throwing simulator. Goodbye!");

    }

    public class DiceSimulate
    {
        int numRollsInput = 0;
        public DiceSimulate(int numRollsInput)
        {
            this.numRollsInput = numRollsInput;
        }

        public int[] countCombineDice() // this method return type is int[]
        {
            int[] diceIndex = new int[11];
            for (int i = 0; i < numRollsInput; i++)
            {
                Random rnd = new Random();
                int die1 = rnd.Next(1, 7);
                int die2 = rnd.Next(1, 7);
                int combinedDice = die1 + die2;
                diceIndex[combinedDice-2]++;
            }
            return diceIndex;
        }
    }
}