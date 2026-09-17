namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List <string> Words = new List<string> { "apple", "banana", "cherry", "date", "elderberry" };

            Console.WriteLine("Welcome to Hangman! You will be guessing the letters of a secret word.");

            Random rng = new Random();

            int index = rng.Next(1, Words.Count);

            string secretWord = Words[index];

            int wordLength = secretWord.Length;

            string displayWord = new string('_', wordLength);

            char[] guessedLetters = new char[wordLength];

            int wrongGuesses = 0;

            for (int i = 0; i < wordLength; i++)
            {
                Console.WriteLine("\nYou have " + (wordLength - i) + " chances to guess the word. Guess this word: " + displayWord);

                guessedLetters[i] = Console.ReadKey().KeyChar;

                foreach (char letter in secretWord)
                {
                    if(letter == guessedLetters[i])
                    {
                        Console.Write(letter);
                        //displayWord[i] = letter;  Why is this wrong? What's the alternative?
                    }
                    else
                    {
                        wrongGuesses++;
                    }
                }

            }

        }
    }
}