using System;

namespace LanguageLearningChatBotCore
{
    class TranslationData
    {
        public string m_primaryText{get; set;}
        public Language m_primaryLanguage{get; set;}

        public string m_secondaryText{get; set;} 
        public Language m_secondaryLanguage{get; set;}
    }
}