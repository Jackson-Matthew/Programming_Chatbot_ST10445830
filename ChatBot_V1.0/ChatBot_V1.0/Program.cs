namespace ChatBot_V1._0
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            VoiceGreeting greeting = new VoiceGreeting();
            greeting.Greeting();

            ImageDisplay display = new ImageDisplay();
            display.Heading();

            ResponseSystem response = new ResponseSystem();
            response.Response();
        }
    }
}
