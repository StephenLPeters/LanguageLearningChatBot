using System;

namespace LanguageLearningChatBotCore
{
    class TranslationData
    {
        private string m_original;
        private string m_translated;

        public TranslationData(string original, string translated)
        {
            m_original = original;
            m_translated = translated;
        }
    }
}