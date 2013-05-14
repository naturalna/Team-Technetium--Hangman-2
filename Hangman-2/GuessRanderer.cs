using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Hangman
{
    public class GuessRanderer : WordInitializator
    {
        public GuessRanderer(): base()
        {
        }

        public void InitializationAfterTheGuess( string word, char charSupposed)
        {
            int supposedCharCounter = 0;
            
            if (base.OrderedLettersMask.Contains<char>(charSupposed))
            {
                Console.WriteLine("You have already revelaed the letter {0}", charSupposed);
                return;
            }

            for (int i = 0; i < word.Length; i++)
            {
                if (word[i].Equals(charSupposed))
                {
                    base.OrderedLettersMask[i] = word[i];
                    supposedCharCounter++;
                }
            }

            if (supposedCharCounter == 0)
            {
                Console.WriteLine("Sorry! There are no unrevealed letters {0}", charSupposed);
                base.NotGuessedCharsCounter++;
            }
            else
            {
                Console.WriteLine("Good job! You revealed {0} letters.\n", supposedCharCounter);
                base.GuessedCharsCounter += supposedCharCounter;
            }

            if (base.GuessedCharsCounter == word.Length)
            {
                base.GameEndInitialization(word);
                CommandExecuter.Restart();
            }

            Console.WriteLine("The secret word is:");
            base.RevealGuessedLetters(word);
        }

        public void RevealTheNextLetterByHelp(string word)
        {
            char firstUnrevealedLetter = '$';

            for (int i = 0; i < word.Length; i++)
            {
                if (base.OrderedLettersMask[i].Equals('$'))
                {
                    firstUnrevealedLetter = word[i];
                    break;
                }
            }

            Console.WriteLine("OK, I reveal for you the next letter {0}.", firstUnrevealedLetter);
            this.InitializationAfterTheGuess(word, firstUnrevealedLetter);

            base.IsPlayerUsedHelp = true;
        }
    }
}
