using System;

namespace LanguageLearningChatBotCore
{
    class TranslationData
    {
        public string OriginalText{get; set;}
        public Language m_originalLanguage{get; set;}

        public string m_translated{get; set;} 
        public Language m_translatedLanguage{get; set;}
    }
}