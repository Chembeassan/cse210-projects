public class DailyInspirations
{
    private List<string> inspirations;
    private List<string> affirmations;
    private List<string> tips;

    public DailyInspirations()
    {
        inspirations = new List<string>()
        {
            // Motivation for coding and programming
            "The best way to predict the future is to create it. - Peter Drucker",
            "In coding, there are no problems, only solutions waiting to be found.",
            "Programmers don't byte, they nibble a bit.",
            
            // Motivation for reading and learning
            "The more that you read, the more things you will know. The more that you learn, the more places you'll go. - Dr. Seuss",
            "Reading is to the mind what exercise is to the body. - Joseph Addison",
            "A reader lives a thousand lives before he dies. The man who never reads lives only one. - George R.R. Martin",
            
            // General motivation and inspiration
            "Believe you can and you're halfway there. - Theodore Roosevelt",
            "The only limit to our realization of tomorrow will be our doubts of today. - Franklin D. Roosevelt",
            "The future belongs to those who believe in the beauty of their dreams. - Eleanor Roosevelt",
        };

        affirmations = new List<string>()
        {
            // Affirmations for coding and programming
            "I am a skilled programmer capable of solving complex problems.",
            "Every line of code I write brings me closer to my goals.",
            "I embrace challenges and view them as opportunities for growth.",
            
            // Affirmations for reading and learning
            "I am committed to lifelong learning and personal development.",
            "Reading expands my knowledge and broadens my perspective.",
            "Every book I read enriches my mind and fuels my imagination.",
            
            // General affirmations
            "I am capable of achieving anything I set my mind to.",
            "I am deserving of success and happiness.",
            "I have the power to create a life filled with purpose and fulfillment."
        };

        tips = new List<string>()
        {
            // Tips for coding and programming
            "Break down complex problems into smaller, manageable tasks.",
            "Seek feedback from peers to improve your coding skills.",
            "Explore new programming languages and frameworks to expand your knowledge.",
            
            // Tips for reading and learning
            "Set aside dedicated time each day for reading and learning.",
            "Take notes while reading to reinforce understanding and retention.",
            "Join book clubs or online communities to discuss and share insights.",
            
            // General tips
            "Set clear and achievable goals to stay focused and motivated.",
            "Practice self-care and maintain a healthy work-life balance.",
            "Celebrate your accomplishments, no matter how small they may seem."
        };
    }

    public string GetRandomInspiration()
    {
        Random random = new Random();
        int index = random.Next(inspirations.Count);
        return inspirations[index];
    }

    public string GetRandomAffirmation()
    {
        Random random = new Random();
        int index = random.Next(affirmations.Count);
        return affirmations[index];
    }

    public string GetRandomTip()
    {
        Random random = new Random();
        int index = random.Next(tips.Count);
        return tips[index];
    }
}
