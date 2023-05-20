using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureProgram
{
    class Scripture
    {
        private string reference;
        private string text;
        private HashSet<string> hiddenWords;
        private string hideCharacter;

        public Scripture(string reference, string text, string hideCharacter = "______")
        {
            this.reference = reference;
            this.text = text;
            hiddenWords = new HashSet<string>();
            this.hideCharacter = hideCharacter;
        }

        public string Reference
        {
            get { return reference; }
        }

        public string Text
        {
            get { return text; }
        }

        public bool IsCompletelyHidden()
        {
            return hiddenWords.Count == text.Split().Length;
        }

        public string HideRandomWord()
        {
            string[] words = text.Split();
            IEnumerable<string> visibleWords = words.Except(hiddenWords);

            if (!visibleWords.Any())
                return null;

            string hiddenWord = visibleWords.ElementAt(new Random().Next(visibleWords.Count()));
            hiddenWords.Add(hiddenWord);
            return hiddenWord;
        }

        public string GetHiddenText()
        {
            string[] words = text.Split();
            IEnumerable<string> hiddenText = words.Select(word => hiddenWords.Contains(word) ? hideCharacter : word);
            return string.Join(" ", hiddenText);
        }

        public void Display()
        {
            ClearConsole();
            Console.WriteLine($"{reference}: {GetHiddenText()}");
        }

        private void ClearConsole()
        {
            Console.Clear();
        }
    }

    class Reference
    {
        private string reference;

        public Reference(string reference)
        {
            this.reference = reference;
        }

        public override string ToString()
        {
            return reference;
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            List<Scripture> scriptures = new List<Scripture>()
            {
                new Scripture(new Reference("Psalm 27:10"), "When my father and my mother forsake me, then the LORD will take care of me."),
                new Scripture(new Reference("Jeremiah 32:27"), "Behold, I am the LORD, the God of all flesh. Is anything too hard for me?"),
                new Scripture(new Reference("Proverbs 16:3"), "Commit your work to the LORD, and your plans will be established.")
            };

            foreach (var scripture in scriptures)
            {
                scripture.Display();
                while (true)
                {
                    Console.WriteLine("Press Enter to continue or type 'quit' to exit: ");
                    string userInput = Console.ReadLine();
                    if (userInput == "quit")
                        return;

                    string hiddenWord = scripture.HideRandomWord();
                    scripture.Display();
                    if (scripture.IsCompletelyHidden())
                        break;
                }
            }
        }
    }
}
