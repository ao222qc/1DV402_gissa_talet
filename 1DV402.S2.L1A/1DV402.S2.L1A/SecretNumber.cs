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
        //min fina fält där _number är numret som slumpas ett värde, _count är antal gissningar som räknas uppåt.

        public void Initialize()
        {
            Random rnd = new Random();
            _number = rnd.Next(1, 101);
            _count = 0;
            //här tilldelas mina små fält värden, slumpat mellan 1-100 på _number

        }
        
        public bool MakeGuess(int value)
        {

            if (_count >= MaxNumberOfGuesses) //om gissningarna överstiger maximalt antal gissningar så kastas ett undantag. Vet ej när det används riktigt dock.
            {
                throw new ApplicationException();
            }
            _count++; //count ökar ett värde per antal giltlig gissning.

            if (_number == value) //Om argumentet som skickas in i value är lika med det slumpade numret så är det helt enkelt rätt.
            {
                Console.WriteLine("You found the correct number in {0} tries! The answer is : {1}", _count, _number);
                return true;
            }

            if (_count == MaxNumberOfGuesses) //Om antal giltliga gissningar är lika med maximalt antal gissningar skrivs en sympatisk text som skriver ut svaret.
            {
                Console.WriteLine("Sorry! The correct answer is : {0}", _number);
                return false;
            }

            if (value < 1 || value > 100) //Om gissningen inte är mellan 1-100 kastas ett undantag och metoden anropas igen (som jag förstår det)
            {
                throw new ArgumentOutOfRangeException();
            }
            if (_number < value) //Om det slumpade numret är lägre än gissningen som skickas in som argument så är gissningen för hög vilket presenteras pedagogiskt tillsammans med antal gissningar kvar.
            { 
                Console.WriteLine("{0} is too high. {1} guesses left.", value, MaxNumberOfGuesses - _count); //max antal gissningar minus gissningar gjorda
                return false;
            }
            else if (_number > value) // om slumpade nr är  högre än gissningen i argumentet så är gissningen för låg. Presenteras med antal gissningar kvar.
            {
                Console.WriteLine("{0} is too low. {1} guesses left.", value, MaxNumberOfGuesses - _count);
                return false;
            }
            return true; //Returnerar ett boolskt värde så att inte kompilatorn klagar på mig.
        }
        public SecretNumber() //en konstruktor som initierar Initialize där mina nuffror får nya värden när den anropas vid ny spelomgång. 
        {
            Initialize();
        }


    }
}