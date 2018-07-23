using System;

namespace LanguageLearningChatBotCore
{
    class TranslationData
    {
        public string OriginalText{get; set;}
        public Language OriginalLanguage{get; set;}

        public string Translated{get; set;} 
        public Language TranslatedLanguage{get; set;}
    }
}