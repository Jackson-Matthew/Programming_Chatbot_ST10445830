namespace ChatBot_V1._0
{
    class ResponseSystem : BotInterface
    {
        public void Response()
        {
            TypingEffect2("CABBY: What is your name?\n");
            String userName = Console.ReadLine();
            TypingEffect2("\nCABBY: What can I assist you with " + userName + "?\n");

            while (true)
            {
                Console.Write(userName + ": ");
                string input = Reader();
                string response = Responsefeature(input);

                TypingEffect2("\n" + "CABBY: " + response + "\n");
            }
        }
        public string Responsefeature(string userInput)
        {
            userInput = userInput.ToLower();


            foreach (var Word in variousResponses.Keys)
            {
                if (userInput.Contains(Word))
                {
                    return variousResponses[Word];
                }
            }
            return "Sorry, I didn't quite get that, could you rephrase?";
        }
    }
}