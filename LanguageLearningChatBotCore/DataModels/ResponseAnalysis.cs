using System;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    class ResponseAnalysis
    {
        public TranslationData response{get;}
        public TranslationData prompt{get;}
        public List<Correction> corrections{get;}

        public ResponseAnalysis(TranslationData theirResponse, TranslationData myPrompt, List<Correction> myCorrections)
        {
            response = theirResponse;
            prompt = myPrompt;
            corrections = myCorrections;
        }
    }
}