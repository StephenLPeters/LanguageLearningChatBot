using System;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    class ControllerAPIImpl
    {
        private TranslationData Translate(string data)
        {
            return new TranslationData();
        }

        public ResponseAnalysis Respond(Language primary, Language secondary, string data)
        {
            return new ResponseAnalysis(new TranslationData(), new TranslationData(), new List<Correction>() );
        }
    }
}