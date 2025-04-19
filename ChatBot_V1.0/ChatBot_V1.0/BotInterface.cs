namespace ChatBot_V1._0
{
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
                Thread.Sleep(65);
            }
            Console.WriteLine();
        }

        public Dictionary<string, string> variousResponses = new Dictionary<string, string>()
    {
        //conversational based questions

        {"how are you","I'm doing great! How about you ?"},
        {"purpose","I'm here to help you stay safe online by providing cybersecurity tips ! "},
        {"questions", "I can provide information on the following: \n > Phishing \n > Password Saftey \n > Safe browsing practices"},
        
        //greetings 

        {"thank you","Glad i could help ;) Anything else I can assist with?"},
        //{".","No problem, let me know if there is anything else I can help with."},
        {"help","Sure no problem ! What would you like help with?" },
        {"goodbye","Cheers, thanks for the chat ;)" },
        {"uhhh","whatsup?"},
        {"good thanks","Cool, No problem"},

        //theory based questions
        
        {"phishing","Phishing is a common cyberattack that targets individuals by sending deceptive messages designed to trick them into revealing sensitive information."},
        {"password saftey","Using long and complex passwords helps prevent unauthorized access to your data. Make sure each password is unique and includes a mix of letters, numbers, and special characters."},
        {"safe browsing","Safe browsing involves being cautious online—avoiding suspicious websites, not clicking unknown links, and ensuring websites are secure before entering sensitive information." },


        {"examples","\n> Ensure that the website your on is using HTTPS for a secure connection \n> Avoid Suspicious looking links \n> Make sure your browser is up to date with the latest security updates "},
        {"can you tell me more ","\n> Ensure that the website your on is using HTTPS for a secure connection \n> Avoid Suspicious looking links \n>Make sure your browser is up to date with the latest security updates "}
};

        public string Reader()
        {
            return Console.ReadLine();
        }
    }
}


