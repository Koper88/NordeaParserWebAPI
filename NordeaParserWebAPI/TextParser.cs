using NordeaParserWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NordeaParserWebAPI
{
    public class TextParser
    {
        private char[] sentencesSeparators = { '.', '?', '!' };
        private char[] wordsSeparators = { ' ', ',', ';', ':', '/' };

        public List<Sentence> Parse(string inputText)
        {
            var rawSentences = inputText.Split(sentencesSeparators, StringSplitOptions.RemoveEmptyEntries);

            var parsedSentences = rawSentences.Select(rawSentence => new Sentence()
            {
                Words = rawSentence.Split(wordsSeparators, StringSplitOptions.RemoveEmptyEntries)
                    .Where(x => !string.IsNullOrWhiteSpace(x))
                    .OrderBy(x => x)
                    .ToList()
            });

            return parsedSentences.Where(x=>x.Words.Any()).ToList();
        }
    }
}
