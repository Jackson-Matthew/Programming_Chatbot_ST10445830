using System.Media;

namespace ChatBot_V1._0
{
    class VoiceGreeting
    {
        public void Greeting()
        {
            if (OperatingSystem.IsWindows())
            {
                SoundPlayer player = new SoundPlayer("Voice_GreetingIntro.wav");
                player.Play();
            }
        }
    }
}
/*
 * Voice greeting uses the Voice_GreetingIntro.wav file 
 * if statement is used to pass worflow validation,stating that if the platform is windows then it will pass the checks.
*/