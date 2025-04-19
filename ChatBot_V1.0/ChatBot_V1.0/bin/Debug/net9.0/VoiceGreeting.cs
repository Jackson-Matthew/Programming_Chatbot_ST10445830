using System.Media;


namespace ChatBot_V1._0
{
    class VoiceGreeting
    {
        public void Greeting()
        {
            SoundPlayer player = new SoundPlayer("Voice_GreetingIntro.wav");
            player.Play();
        }
    }
}
