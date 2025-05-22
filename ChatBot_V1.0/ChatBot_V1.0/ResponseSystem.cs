namespace ChatBot_V1._0
{
    //ResponseSystem inherits from BotInterface 
    class ResponseSystem : BotInterface
    {
        /*
         * Asking for name is put outside of main response functionality to reduce looping of the same question.
         * Input validation to check if the user has entered anything, if no input is detected a message is displayed prompting the user for input.
        */
        public void Response()
        {
            BotInterface bot = new BotInterface();

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect2("CABBY: What is your name?\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            string? userName = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect2("\nCABBY: What can I assist you with " + userName + "?\n");
            Console.ResetColor();

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + ": ");
                string? input = Reader();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\nCABBY: I didnt quite get that, Could you tell me again?\n ");
                    Console.ResetColor();
                    continue;
                }

                string userInput = input.ToLower();
                string? matched = CabbyResponses.Keys.OrderByDescending(k => k.Length).FirstOrDefault(key => userInput.Contains(key.Replace("_", " ")));

                if (matched != null)
                {
                    var responses = CabbyResponses[matched];
                    string replyBot = responses[new Random().Next(responses.Count)];

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\n" + "CABBY: " + replyBot + "\n");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\nCABBY: I don't quite understand , could you rephrase?" + "\n");
                    Console.ResetColor();
                }
            }
        }
    }
}
/* 
* Responsefeature method implements the dictionary created in BotInterface,
* if the user input is upper case the userInput is converted to lowercase so 
* that the text can correspond with the keywords set in the dictionary.
*/
