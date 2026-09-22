// increment tries..
// gets challenging as games are won
// do not allow the same word to be guessed twice
using System;
using CrypticWizard.RandomWordGenerator;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {

            List <string> Words = new List<string> { "truth", "shall", "prevail", "boomboom", "secret", "service" };

            Console.WriteLine("Welcome to Hangman! You will be guessing the letters of a secret word. The number of chances you have is equal to the length of the word.");
            Console.WriteLine("Would you like to play a game of Hangman? (Y/N)");

            int numberOfGames = 0;
            int gamesWon = 0;

            while (true)
            {        
                string? userInputToPlay = Console.ReadLine().ToUpper(); // dereference a null value?

                Console.Clear();

                if (userInputToPlay != null && userInputToPlay == "Y")
                {
                    numberOfGames++;

                    WordGenerator wordGenerator= new WordGenerator();

                    string secretWord = wordGenerator.GetWord();

                    int wordLength = secretWord.Length;

                    char[] displayWord = new char[wordLength];

                    for (int i = 0; i < wordLength; i++)
                    {
                        displayWord[i] = '_';
                    }

                    char[] guessedLetters = new char[wordLength];

                    int wrongLetterGuesses = 0;

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
                            gamesWon++;
                            break;
                        }
                        else
                        {
                            wrongLetterGuesses++;
                        }

                        if (wrongLetterGuesses == wordLength)
                        {
                            Console.WriteLine("\nSorry, you have run out of chances. The secret word was: " + secretWord);
                            break;
                        }
                    }

                }
                else if (userInputToPlay == "N")
                {
                    Console.WriteLine("Thank you for playing Hangman! Goodbye!");
                    return;
                }
                else
                {
                    Console.WriteLine("Invalid input. Please enter Y or N.");
                }

                Console.WriteLine("Games won: " + gamesWon); 
                Console.WriteLine("Games played: " + numberOfGames);
                Console.Write("Would you like to play another game of Hangman? (Y/N)");

            }
            
        }
    }
}