namespace ChatBot_V1._0
{
    //ResponseSystem inherits from BotInterface 
    class ResponseSystem : BotInterface
    {
        /*
         * Asking for name is put outside of main response functionality to reduce looping of the same question.
         * Input validation to check if the user has entered anything, if no input is detected a message is displayed prompting the user for input.
        */

        public MemorySystem memory = new MemorySystem();
        public MoodSystem mood = new MoodSystem();

        //constructors for the MemorySystem and MoodSytem classes.
        public void Response()
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect2("CABBY: What is your name?\n");
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.White;
            string? userName = Console.ReadLine();
            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Cyan;
            TypingEffect2("\nCABBY: What can I assist you with " + userName + "?\n");
            Console.ResetColor();

            string? inputMemory = userName;

            System.IO.File.WriteAllText("Memory.txt", inputMemory);

            string? savedName = File.ReadAllText("Memory.txt");

            /*
             * The while loop contains the logic for checking if certain conditions are true such as memeory recall, mood of the user
             * and if the user has entered input that the bot can respond too.
             */

            while (true)
            {
                Console.ForegroundColor = ConsoleColor.White;
                Console.Write(userName + ": ");
                string? input = Reader();
                Console.ResetColor();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("\nCABBY: I didn't quite get that, could you tell me again?\n");
                    Console.ResetColor();
                    continue;
                }

                string userInput = input.ToLower();

                MoodSystem.Mood currentMood = mood.DetermineMood(userInput);

                string? moodKey = currentMood switch
                {
                    MoodSystem.Mood.Positive => "mood_positive",
                    MoodSystem.Mood.Negative => "mood_negative",
                    _ => null
                };

                bool moodResponse = false;

                if (moodKey != null && CabbyResponses.ContainsKey(moodKey))
                {
                    var moodWithResponses = CabbyResponses[moodKey];
                    string? moodAnswer = moodWithResponses[new Random().Next(moodWithResponses.Count)];

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2("CABBY: " + moodAnswer + "\n");
                    Console.ResetColor();
                    moodResponse = true;
                }

                /*
                 * takes what the user is intersted in and returns that topic
                 * if the user has not stated any interests then cabby will state that he doesnt recall anything.
                 */

                if (userInput.Contains("what was i interested in"))
                {
                    string? topic = memory.RecallInterest();
                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2(topic != null
                        ? $"\nCABBY: You said you were interested in {topic}.\n"
                        : "\nCABBY: I don't remember you mentioning an interest yet.\n");
                    Console.ResetColor();
                }

                else if (userInput.StartsWith("im interested in") ||
                         userInput.StartsWith("i'm interested in") ||
                         userInput.StartsWith("i am interested in"))
                {
                    string topic = input.Replace("i'm interested in", "", StringComparison.OrdinalIgnoreCase)
                                        .Replace("i am interested in", "", StringComparison.OrdinalIgnoreCase)
                                        .Replace("im interested in", "", StringComparison.OrdinalIgnoreCase)
                                        .Trim();
                    memory.SaveInterest(topic);

                    Console.ForegroundColor = ConsoleColor.Cyan;
                    TypingEffect2($"\nCABBY: Got it! I've noted that you're interested in {topic}.\n");
                    Console.ResetColor();
                }

                else if (userInput.Contains("my name"))
                {
                    if (File.Exists("Memory.txt"))
                    {
                        string sName = File.ReadAllText("Memory.txt");
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypingEffect2("\nCABBY: Your name is " + sName + ".\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.WriteLine("CABBY: I don't know your name.");
                    }
                }

                else if (!moodResponse)
                {
                    string? matched = CabbyResponses.Keys
                        .OrderByDescending(k => k.Length)
                        .FirstOrDefault(key => userInput.Contains(key.Replace("_", " ")));

                    if (matched != null)
                    {
                        var responses = CabbyResponses[matched];
                        string replyBot = responses[new Random().Next(responses.Count)];

                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypingEffect2("\nCABBY: " + replyBot + "\n");
                        Console.ResetColor();
                    }
                    else
                    {
                        Console.ForegroundColor = ConsoleColor.Cyan;
                        TypingEffect2("\nCABBY: I don't quite understand, could you rephrase?\n");
                        Console.ResetColor();
                    }
                }
            }
        }
    }
}

