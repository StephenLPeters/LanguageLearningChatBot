using System;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    public class ResponseAnalysis
    {
        public TranslationData Response{get;}
        public TranslationData Prompt{get;}
        public List<Correction> Corrections{get;}

        public ResponseAnalysis(TranslationData theirResponse, TranslationData myPrompt, List<Correction> myCorrections)
        {
            Response = theirResponse;
            Prompt = myPrompt;
            Corrections = myCorrections;
        }
    }
}