using NordeaParserWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NordeaParserWebAPI.Converters
{
    public class CSVConverter
    {
        public string Convert(List<Sentence> sentences)
        {
            var stringBuilder = new StringBuilder();

            var maxNumber = sentences.Max(s => s.Words.Count);
            var headers = Enumerable.Range(1, maxNumber).Select(x => $"Word {x}");

            stringBuilder.Append(string.Join(", ", headers));

            stringBuilder.Append("\n" + string.Join("\n", Enumerable.Range(1, sentences.Count).Select(x =>
                        $"Sentence {x}, {string.Join(", ", sentences[x - 1].Words)}")));

            return stringBuilder.ToString();
        }
    }
}
