using System;

namespace LanguageLearningChatBotCore
{
    class ControllerAPI
    {
        TranslationData Translate(string data)
        {
            return new TranslationData(data, data);
        }
    }
}