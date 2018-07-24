using System;

namespace LanguageLearningChatBotCore
{
    public class TranslationData
    {
        public string PrimaryText{get; set;}
        public Language PrimaryLanguage{get; set;}

        public string SecondaryText{get; set;} 
        public Language SecondaryLanguage{get; set;}
    }
}