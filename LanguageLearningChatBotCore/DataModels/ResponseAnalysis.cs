using System;
using System.Collections.Generic;

namespace LanguageLearningChatBotCore
{
    public class ResponseAnalysis
    {
        public TranslationData Response{ get; set; }
        public TranslationData Prompt{ get; set; }
        public List<Correction> Corrections{ get; set; }
    }
}