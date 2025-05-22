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
            //VariousResponses();

            // BotInterface memory = new BotInterface();
            BotInterface bot = new BotInterface();

            Console.ForegroundColor = ConsoleColor.Cyan;
                TypingEffect2("CABBY: What is your name?\n");
                Console.ResetColor();

                Console.ForegroundColor = ConsoleColor.White;
                string userName = Console.ReadLine();
                Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect2("\nCABBY: What can I assist you with " + userName + "?\n");
            Console.ResetColor();
            
            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + ": ");
                string input = Reader();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\nCABBY: I didnt quite get that, Could you tell me again?\n ");
                    Console.ResetColor();
                    continue;
                }

                string userInput = input.ToLower();
                
                                // Memory recall detection
                                if (userInput.Contains("did we talk about") ||
                                    userInput.Contains("did i ask about") ||
                                    userInput.Contains("have we spoken about") ||
                                    userInput.Contains("have we talked about") ||
                                    userInput.Contains("did we discuss") ||
                                    userInput.Contains("have we mentioned"))
                                {
                                    string[] possibleKeywords = userInput.Split(' ');
                                    string[] skipWords = { "did", "we", "talk", "about", "i", "ask", "spoken", "have", "mentioned", "discuss" };

                                    // Filter out common filler words
                                    var keywords = possibleKeywords
                                        .Where(word => !skipWords.Contains(word.ToLower()))
                                        .ToList();

                                    if (keywords.Count > 0)
                                    {
                                        string keyword = string.Join(" ", keywords); // Support multi-word topics
                                        string recallResponse = memory.RecallFromMemory(keyword);
                                        TypingEffect2("\nCABBY: " + recallResponse + "\n");
                                        continue;
                                    }
                                    else
                                    {
                                        TypingEffect2("\nCABBY: Can you remind me what topic you're referring to?\n");
                                        continue;
                                    }
                                }
                

                string matched = CabbyResponses.Keys.OrderByDescending(k => k.Length).FirstOrDefault(key => userInput.Contains(key.Replace("_", " ")));

                if (matched != null)
                {
                    var responses = CabbyResponses[matched];
                    string replyBot = responses[new Random().Next(responses.Count)];

                   // memory.SaveToMemory(userInput, replyBot);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\n" + "CABBY: " + replyBot + "\n");
                    Console.ResetColor();
                    continue;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\nCABBY: I don't quite understand , could you rephrase?"+"\n");
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
