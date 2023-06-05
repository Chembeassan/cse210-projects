using System;
using System.Collections.Generic;
using System.Linq;

namespace ScriptureProgram
{
    public class Scripture
    {
        private string reference;
        private string text;
        private HashSet<string> hiddenWords;
        private string hideCharacter;
        private List<string> journalEntries;

        public Scripture(string reference, string text, string hideCharacter = "______")
        {
            this.reference = reference;
            this.text = text;
            hiddenWords = new HashSet<string>();
            this.hideCharacter = hideCharacter;
            journalEntries = new List<string>();
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

        public void Hide()
        {
            string[] words = text.Split();
            IEnumerable<string> visibleWords = words.Except(hiddenWords);

            if (!visibleWords.Any())
            {
                Console.WriteLine("All words are already hidden!");
                return;
            }

            string hiddenWord = visibleWords.ElementAt(new Random().Next(visibleWords.Count()));
            hiddenWords.Add(hiddenWord);
            Console.WriteLine($"Hiding '{hiddenWord}' in {reference}...");
        }

        public void PerformAction()
        {
            Console.WriteLine($"Performing a special action for {reference}...");

            if (reference.Contains("Psalm"))
            {
                Console.WriteLine("You feel a sense of peace and tranquility.");
            }
            else if (reference.Contains("Jeremiah"))
            {
                Console.WriteLine("You sense an overwhelming presence of strength and determination.");
            }
            else if (reference.Contains("Proverbs"))
            {
                Console.WriteLine("You feel a surge of wisdom and inspiration.");
            }
            else
            {
                Console.WriteLine("You experience a deep connection with the scripture.");
            }
        }

        public void AddJournalEntry(string entry)
        {
            journalEntries.Add(entry);
            Console.WriteLine("Journal entry added!");
        }

        public void DisplayJournalEntries()
        {
            ClearConsole();
            Console.WriteLine($"{reference}: {GetHiddenText()}");
            Console.WriteLine("\nJournal Entries:");
            foreach (string entry in journalEntries)
            {
                Console.WriteLine($"- {entry}");
            }
        }

        public void SaveJournalEntries()
        {
            string fileName = $"{reference}_journal.txt";
            System.IO.File.WriteAllLines(fileName, journalEntries);
            Console.WriteLine($"Journal entries saved to {fileName}!");
        }
    }
}
