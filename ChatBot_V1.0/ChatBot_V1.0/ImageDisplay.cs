﻿namespace ChatBot_V1._0
{
    class ImageDisplay : BotInterface
    {
        public void Heading()
        {
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                string titleText = ("                                                           Hello,and Welcome To C A B B Y\n");
                string subText = ("                                                   THE CYBERSECURITY AWARNESS BOT BENEFITTING YOU !!");

                TypingEffect1(titleText);
                TypingEffect1(subText);
                string mainHeading = @"                                                                                           
============================================================================================================================================================

                                                        ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░               
                                                       ▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒              
                                                       ▒▓▒                                 ▒▓▒
                                                       ▒▓▒      ___   _   ___ _____   __   ▒▓▒
                                                       ▒▓▒     / __| /_\ | _ ) _ ) \ / /   ▒▓▒
                                                       ▒▓▒    | (__ / _ \| _ \ _ \\ V /    ▒▓▒
                                                       ▒▓▒     \___/_/ \_\___/___/ |_|     ▒▓▒
                                                       ▒▓▒                                 ▒▓▒
                                                       ▒▓▒                                 ▒▓▒              
                                                       ▒▓▒                                 ▒▓▒              
                                                       ▒▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▓▒              
                                                       ░░░░░░░░░░░░░░░░░▓▓▓▓▓░░░░░░░░░░░░░░░░░              
                                                                   ░█▓▓▓▓▓▓▓▓▓▓▓▓▓█░ 
                                                          V1.5 developed by Matthew Jackson 
                                                        ░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░░               
                                                        ▓▓░▒░░░░░░▒░▒░▓░░░█░░░▓░░░▒░░░░░░▒░▓▓       ░         
                                                       ▒▓░░░░▓░░░░░░░░▒░░░█░░░▒░░░░░░░░▒░░░░▓▒    ▒▓▓▓▒       
                                                      ░▓▒░▒░▒░░▒░▓░░░░░░░░░░░░░░░░░▓░▒░░▒░▒░░▓░  ░░░░░░░     
                                                      ▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒                            

============================================================================================================================================================";
                Console.WriteLine(mainHeading);
            }
        }
    }
}
// ASCII text header to be displayed when the program runs.

// ImageDisplay Extends BotInterface and uses the TypingEffect1 method to print the text.