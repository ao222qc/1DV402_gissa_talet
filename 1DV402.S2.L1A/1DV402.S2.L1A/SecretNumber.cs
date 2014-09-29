using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1A
{
    public class SecretNumber
    {
        public const int MaxNumberOfGuesses = 7;
        private int _number;
        private int _count;
        public string exception = "no no no";

        public void Initialize()
        {
            Random rnd = new Random();
            _number = rnd.Next(1, 101);
            _count = 0;

        }
        
        public bool MakeGuess(int value)
        {
            
            if (_count >= MaxNumberOfGuesses)
            {
                throw new ApplicationException ();
                
            }
            _count++;



            if (value < 1 || value > 100)
            {
                
                throw new ArgumentOutOfRangeException();
            }
            if (_number < value)
            {
                Console.WriteLine("{0} is too high. {1} guesses left.", value, MaxNumberOfGuesses - _count);
                return false;
            }
            else if (_number > value)
            {
                Console.WriteLine("{0} is too low. {1} guesses left.", value, MaxNumberOfGuesses - _count);
                return false;
            }
            if (_count > MaxNumberOfGuesses)
            {
                //too many guesses goddamnit
                throw new ApplicationException();
            }

            if (_number == value)
            {
                Console.WriteLine("You are correct! The answer is : {0}", _number);
                return true;
            }
         
           
         
            return true;
        }
        public SecretNumber()
        {
            Initialize();
        }


    }
}