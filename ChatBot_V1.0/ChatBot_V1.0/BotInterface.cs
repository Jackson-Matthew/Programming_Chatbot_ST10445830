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


        public Dictionary<string, string> variousResponses = new Dictionary<string, string>()
    {
        //conversational based questions

        {"how are you","I'm doing great! How about you ?"},
        {"purpose","I'm here to help you stay safe online by providing cybersecurity tips ! "},
        {"ask you", "I can provide information on the following: \n > Phishing and examples \n > Password Safety and explanations \n > Safe browsing practices and determining if websites are secure"},
        {"yes","Sure ! What would you like me to clarify on ?" },
        {"no.","Awesome thanks for the chat ;)" },

        //greetings 

        {"thank you","Glad i could help ;) Anything else I can assist with?"},
        {"help","Sure no problem ! What would you like help with?" },
        {"goodbye","Cheers, thanks for the chat ;)" },
        {"joke","Why did the computer show up at work late?...... \n It had a hard drive" },
        {"lol","Glad you thought my joke was funny ! Anything else i can help with?"},
        {"good thanks","Cool, No problem"},

        //theory based questions
        
        {"phishing","Phishing is a common cyberattack that targets individuals by sending deceptive messages designed to trick them into revealing sensitive information."},
        {"password safety","\n > Using long and complex passwords helps prevent unauthorized access to your data.\n > Make sure each password is unique and includes a mix of letters, numbers, and special characters."},
        {"safe browsing","\n Safe browsing involves being cautious online: \n > Avoiding suspicious websites \n > Not clicking unknown links \n > Ensuring websites are secure before entering sensitive information." },

        {"examples", "Phishing occurs mostly via: Email,SMS,Messenger services, these messages will usually contain deceptive/fake links" },
        {"explain","A strong password for maximum privacy should include \n > A mix of numbers and letters \n > Various symbols \n > 16 or more charcters \n > Not be easily guessable" },
        {"secure","\n> Ensure that the website your on is using HTTPS for a secure connection \n> Check for Suspicious looking links \n> Make sure your browser is up to date with the latest security updates "}
    };

        //reader method for user input in the ResponseSystem class.
        public string Reader()
        {
            return Console.ReadLine();
        }
    }
}