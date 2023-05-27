namespace ScriptureProgram
{
    public class Reference
    {
        private string bookName;
        private int chapter;
        private int startVerse;
        private int endVerse;

        public Reference(string bookName, int chapter, int startVerse)
        {
            this.bookName = bookName;
            this.chapter = chapter;
            this.startVerse = startVerse;
        }

        public Reference(string bookName, int chapter, int startVerse, int endVerse)
        {
            this.bookName = bookName;
            this.chapter = chapter;
            this.startVerse = startVerse;
            this.endVerse = endVerse;
        }

        public string CreateReference()
        {
            if (endVerse > 0)
                return $"{bookName} {chapter}:{startVerse}-{endVerse}";
            else
                return $"{bookName} {chapter}:{startVerse}";
        }
    }
}
