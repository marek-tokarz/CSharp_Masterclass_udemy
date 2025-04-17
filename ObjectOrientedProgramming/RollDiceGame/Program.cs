using System;

namespace RollDiceGame
{
    class Program
    {
        static void Main(string[] args)
        {
            RollDie rollDice = new RollDie();
            
            int number = rollDice.GenerateRandomNumber();
            NumberGuessing guessNumber = new NumberGuessing();

            guessNumber.TryGuessing(number);

            Console.ReadKey();
        }
    }

    public class RollDie
    {
        private int randomInRange = 0;
        private Random random;

        public RollDie()
        {
            // Initialize the Random object
            random = new Random();
        }

        public int GenerateRandomNumber()
        {
            return randomInRange = random.Next(0, 7);
        }
    }

    public class NumberGuessing
    {
        private bool _userGuessed = false;
        private int _numberTyped;
        private int _numberOfTries = 0;

        public void TryGuessing(int number)
        {
            Console.WriteLine("Die rolled. Guess what number it shows in 3 tries.");
            while (!_userGuessed && _numberOfTries < 3)
            {
                Console.WriteLine("Enter a number:");
                var userInput = Console.ReadLine();
                if (userInput == "")
                {
                    Console.WriteLine("Selected number can not be empty");
                    continue;
                }
                if (int.TryParse(userInput, out _numberTyped))
                {
                    if(_numberTyped < 1 || _numberTyped > 6)
                    {
                        Console.WriteLine("Type a number from range 1 to 6");
                        continue;
                    }
                    if (number == _numberTyped)
                    {
                        Console.WriteLine("You win");
                        _userGuessed = true;
                        return;
                    }
                    else
                    {
                        Console.WriteLine("Wrong number");
                        _numberOfTries++;
                    }
                } 
            }
            Console.WriteLine("You lose");
            Console.WriteLine("The number was: " + number);
        }
    }
}