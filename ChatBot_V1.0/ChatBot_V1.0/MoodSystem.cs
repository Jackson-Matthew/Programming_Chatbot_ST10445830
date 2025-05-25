namespace ChatBot_V1._0
{
    class MoodSystem
    {
        public enum Mood { Positive, Negative, Neutral }

        public Mood DetermineMood(string userInput)
        {
            var positiveWords = new[] { "great", "well", "excellent", "cool", "thanks" };
            var negativeWords = new[] { "missunderstand", "frustrated", "bad", "wrong", "incorrect", "terrible", "not good" };

            userInput = userInput.ToLower();

            if (positiveWords.Any(word => userInput.Contains(word)))
            {
                return Mood.Positive;
            }
            if (negativeWords.Any(word => userInput.Contains(word)))
            {
                return Mood.Negative;
            }
            return Mood.Neutral;
        }
    }
}
