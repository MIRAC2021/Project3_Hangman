// TODO: increment tries..
// TODO: gets challenging as games are won
// TODO: do not allow the same word to be guessed twice
using System;
using CrypticWizard.RandomWordGenerator;

namespace Hangman
{
    internal class Program
    {
        static void Main(string[] args)
        {
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
                    int wrongGuesses = 0;

                    char[] guessedLetters = new char[wordLength];

                    while(wrongGuesses < wordLength)
                    {
                        Console.WriteLine("\nYou have " + (wordLength - wrongGuesses) + " chances to guess the word. Guess this word: " + new string(displayWord) + "\n");
                        char guessedLetter = Console.ReadKey().KeyChar;
                        bool letterFound = false;
                        for (int j = 0; j < wordLength; j++)
                        {
                            if (guessedLetter == secretWord[j])
                            {
                                displayWord[j] = guessedLetter;
                                letterFound = true;
                            }
                        }
                        if (!letterFound)
                        {
                            wrongGuesses++;
                        }
                        if (new string(displayWord) == secretWord)
                        {
                            Console.WriteLine("\nCongratulations! You have guessed the secret word: " + secretWord);
                            gamesWon++;
                            break;
                        }
                        if (wrongGuesses == wordLength)
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