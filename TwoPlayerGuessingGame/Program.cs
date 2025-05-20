using System.Threading.Channels;

namespace GuessingGame
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Guessing Game:
            //the user tries to guess a random number between 1 to 100.
            //The game provides hints for the user until the number is found.

            Random random = new Random();
            int randNum = random.Next(1, 101);
            int userInput;

            int counter = 0;
            int lower = 1;
            int upper = 100;

            Console.WriteLine("Enter the two players' names: ");
            string player1 = Console.ReadLine();
            string player2 = Console.ReadLine(); 

            string turn; //to keep track of the turns

            if (new Random().Next(1, 3) == 1) turn = player1;
            else turn = player2;


            while (true) // game engine
            {
                Console.WriteLine($"{turn} --> Enter a Number between {lower} and {upper}");
                userInput = Convert.ToInt32(Console.ReadLine());

                if (userInput > randNum)
                {
                    Console.WriteLine("Too high! Guess a smaller number.");

                    if (userInput > lower)
                        upper = userInput;
                }
                else if (userInput < randNum)
                {
                    Console.WriteLine("Too low! Guess a bigger number.");
                    if (userInput < upper)
                        lower = userInput;
                }
                else
                {
                    Console.WriteLine($"The game is over! {turn} won the game. WOOHOO!"); break ;
                }

                // the turn needs to be changed
                if (turn == player1) turn = player2;
                else turn = player1;
            }
        }
    }
}
