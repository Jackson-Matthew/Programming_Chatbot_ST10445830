using System.Text.Json;

namespace ChatBot_V1._0
{
    // Parent Class that other classes Inherit from 

    /* 
     * The TypingEffect methods aims to simulate each word that the system outputs as if it is being typed.
     * The string text takes in all text and loops through it each character is then printed out, Thread.sleep() determines the 
     * speed at which these characters are printed out onto the console.
     */
    class BotInterface
    {
        public void TypingEffect1(string text)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                Thread.Sleep(20);
            }
            Console.WriteLine();
        }
        public void TypingEffect2(string text)
        {
            foreach (var character in text)
            {
                Console.Write(character);
                Thread.Sleep(40);
            }
            Console.WriteLine();
        }

        /*
         * The Dictionary has keywords that are assigned to it that then have pre-determined responses.
         * If a keyword is detected by the dictionary it will output the given repsonse that is associated with that keyword.
         * <string, string> represents the key and the value associated with it.
         * The program will loop through the dictionary to determine if the input matches a key then returns the value.
         */

        //reader method for user input in the ResponseSystem class.

        public Dictionary<string, List<string>> CabbyResponses = new();

        public BotInterface()
        {
            LoadResponses("ChatbotResponses.txt");
        }

        private void LoadResponses(string filePath)
        {
            foreach (var line in File.ReadAllLines(filePath))
            {
                if (!line.Contains('|')) continue;

                var parts = line.Split('|', 2);
                string key = parts[0].Trim().ToLower();
                string jsonList = parts[1].Trim();

                try
                {
                    var responseList = JsonSerializer.Deserialize<List<string>>(jsonList);
                    if (responseList != null)
                        CabbyResponses[key] = responseList;
                }
                catch
                {
                    // handle improperly formatted lines or log them
                }
            }
        }


        public string GetResponse(string userInput)
        {
            string keyword = GetKeyword(userInput.ToLower());

            if (keyword != null && CabbyResponses.ContainsKey(keyword))
            {
                var possibleResponses = CabbyResponses[keyword];
                return possibleResponses[new Random().Next(possibleResponses.Count)];
            }

            return "Sorry, I didn't quite understand that.";
        }

        // Simple keyword matcher
        private string GetKeyword(string input)
        {
            // Sort keywords by length (descending) to match more specific phrases first
            foreach (var key in CabbyResponses.Keys.OrderByDescending(k => k.Length))
            {
                if (input.Contains(key))
                    return key;
            }

            return null;
        }



        public string Reader()
        {
            return Console.ReadLine();
        }

       /* private string memoryfilepath = "Memory.txt";

        public Dictionary<string, string> LoadMemory()
        {
            var memory = new Dictionary<string, string>();
            if (File.Exists(memoryfilepath))
            {
                foreach (var line in File.ReadAllLines(memoryfilepath))
                {
                    var parts = line.Split('=', 2);
                    if (parts.Length == 2)
                    {
                        memory[parts[0]] = parts[1];
                    }
                }
            }
            return memory;
        }
        private Dictionary<string, string> chatMemory = new Dictionary<string, string>();

       public void SaveToMemory(string userInput, string response)
{
    string key = userInput.ToLower().Trim();
    chatMemory[key] = response;
    File.AppendAllText(memoryfilepath, $"{key}|{response}{Environment.NewLine}");
}



        /*
        public string RecallFromMemory(string keyword)
        {

            keyword = keyword.ToLower().Trim();

            foreach (var entry in chatMemory)
            {
                if (entry.Key.Contains(keyword))
                {
                    return $"Yes, earlier you asked about \"{keyword}\". Here's what I said: \"{entry.Value}\"";
                }
            }
            return "I don't recall us talking about that yet.";
        }

        */

    }
}





