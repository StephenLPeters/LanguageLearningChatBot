using System;

namespace LanguageLearningChatBotCore
{
    //Do not change this enum without also changing the array in LanguageLookup.
    public enum Language
    {
        French,
        Spanish,
        Italian,
        English
    }

    public class LanguageLookup
    {
        //This array must be kept in alignment with the Language enum above.
        static string[] _languages = new string[]
        {
            "fr",
            "es",
            "it",
            "en"
        };

        public static string[] Languages
        {
            get
            {
                return _languages;
            }
        }

        public Language FindLanguage(string code)
        {
            return (Language)Array.IndexOf(_languages, code);
        }
    }
}