using System;

namespace LanguageLearningChatBotCore
{
    public class Correction
    {
        public int Offset{get; set;}
        public string Original{get; set;}
        public string Corrected{get; set;}
    }
}