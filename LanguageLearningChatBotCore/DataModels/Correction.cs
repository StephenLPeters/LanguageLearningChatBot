using System;
using System.Linq;
using LanguageLearningChatBotCore.DataModels.BingSpellCheck;

namespace LanguageLearningChatBotCore
{
    public class Correction
    {
        public Correction()
        {
        }

        public Correction(FlaggedToken flaggedToken)
        {
            Suggestion bestSuggestion = flaggedToken.Suggestions.OrderByDescending(s => s.Score).FirstOrDefault();

            Original = flaggedToken.Token;
            Corrected = bestSuggestion.SuggestedText;
            Offset = flaggedToken.Offset;
        }

        public int Offset{get; set;}
        public string Original{get; set;}
        public string Corrected{get; set;}
    }
}