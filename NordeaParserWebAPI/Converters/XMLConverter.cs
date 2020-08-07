using NordeaParserWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace NordeaParserWebAPI.Converters
{
    public class XMLConverter
    {
        public XDocument Convert(List<Sentence> sentences)
        {
            var xDeclaration = new XDeclaration("1.0", "UTF-8", "yes");

            var sentenceElements = sentences.Select(sentence =>
                new XElement("sentence", sentence.Words.Select(word =>
                    new XElement("word", word))));

            var rootElement = new XElement("text", sentenceElements);

            return new XDocument(xDeclaration, rootElement);
        }
    }
}
