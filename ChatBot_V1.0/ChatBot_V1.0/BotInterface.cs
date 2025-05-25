using System.Text.Json;

namespace ChatBot_V1._0
{
    // Parent Class that other classes Inherit from 
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

        public Dictionary<string, List<string>> CabbyResponses = new();

        private string? GetKeyword(string input)
        {
            foreach (var key in CabbyResponses.Keys.OrderByDescending(k => k.Length))
            {
                if (input.Contains(key))
                    return key;
            }
            return null;
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

                }
            }
        }
        public BotInterface()
        {
            LoadResponses("ChatbotResponses.txt");
        }

        private Dictionary<string, string> lastResponses = new();
        public string GetResponse(string userInput)
        {
            string? keyword = GetKeyword(userInput.ToLower());

            if (keyword != null && CabbyResponses.ContainsKey(keyword))
            {
                var possibleResponses = CabbyResponses[keyword];
                string? lastResponse = lastResponses.ContainsKey(keyword) ? lastResponses[keyword] : null;

                var options = possibleResponses.Where(r => r != lastResponse).ToList();

                if (options.Count == 0)
                    options = possibleResponses;

                string chosenResponse = options[new Random().Next(options.Count)];
                lastResponses[keyword] = chosenResponse;

                return chosenResponse;
            }
            Console.ForegroundColor = ConsoleColor.Cyan;
            return "Sorry, I didn't quite understand that.";
        }
        public string? Reader()
        {
            return Console.ReadLine();
        }
    }
}

/* 
* The TypingEffect methods aims to simulate each word that the system outputs as if it is being typed.
* The string text takes in all text and loops through it each character is then printed out, Thread.sleep() determines the 
* speed at which these characters are printed out onto the console.
*/

/*
* The Dictionary has keywords that are assigned to it that then have pre-determined responses.
* If a keyword is detected by the dictionary it will output the given repsonse that is associated with that keyword.
* <string, string> represents the key and the value associated with it.
* The program will loop through the dictionary to determine if the input matches a key then returns the value.
*/





