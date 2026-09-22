namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List <string> Words = new List<string> { "truth", "shall", "prevail", "boomboom", "secret", "service" };

            Console.WriteLine("Welcome to Hangman! You will be guessing the letters of a secret word. The number of chances you have is equal to the length of the word.");

            Random rng = new Random();

            int index = rng.Next(1, Words.Count);

            string secretWord = Words[index];

            int wordLength = secretWord.Length;

            char[] displayWord = new char[wordLength];

            for (int i = 0; i < wordLength; i++)
            {
                displayWord[i] = '_';
            }

            char[] guessedLetters = new char[wordLength];

            int wrongGuesses = 0;

            for (int i = 0; i < wordLength; i++)
            {
                Console.WriteLine("\nYou have " + (wordLength - i) + " chances to guess the word. Guess this word: " + new string(displayWord) + "\n");

                guessedLetters[i] = Console.ReadKey().KeyChar;

                for (int j = 0; j < wordLength; j++)
                {
                    if (guessedLetters[i] == secretWord[j])
                    {
                        displayWord[j] = guessedLetters[i];
                    }
                }

                if (new string(displayWord) == secretWord)
                {
                    Console.WriteLine("\nCongratulations! You have guessed the secret word: " + secretWord);
                    break;
                }
                else
                {
                    wrongGuesses++;
                }

                if (wrongGuesses == wordLength)
                {
                    Console.WriteLine("\nSorry, you have run out of chances. The secret word was: " + secretWord);
                    break;
                }
            }
        }
    }
}