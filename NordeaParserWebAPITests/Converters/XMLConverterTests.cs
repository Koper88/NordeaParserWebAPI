using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordeaParserWebAPI.Converters;
using NordeaParserWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.XPath;

namespace NordeaParserWebAPI.Converters.Tests
{
    [TestClass()]
    public class XMLConverterTests
    {
        [TestMethod()]
        public void ConvertTest1()
        {
            var sentences = new List<Sentence> {
                new Sentence { Words = new List<string> { "aaaa"} }
            };

            var converter = new XMLConverter();
            var xml = converter.Convert(sentences);

            Assert.AreEqual(xml.Declaration.Encoding, "UTF-8");
            Assert.AreEqual(xml.Declaration.Version, "1.0");
            Assert.AreEqual(xml.Declaration.Standalone, "yes");
        }

        [TestMethod()]
        public void ConvertTest2()
        {
            var sentences = new List<Sentence> {
                new Sentence { Words = new List<string> { "aaaa","bbbb", "cccc"} },
                new Sentence { Words = new List<string> { "dddd","eeee"} },
                new Sentence { Words = new List<string> { "ffff","gggg", "hhhh", "jjjj"} },
                new Sentence { Words = new List<string> { "kkkk"} }
            };

            var converter = new XMLConverter();
            var xml = converter.Convert(sentences);

            Assert.AreEqual(xml.Root.Name.LocalName, "text");

            var sentencesNo = xml.XPathSelectElements("/text/sentence").Count();
            Assert.AreEqual(sentencesNo, 4);

            var wordsNo = xml.XPathSelectElements("/text/sentence/word").Count();
            Assert.AreEqual(wordsNo, 10);
        }
    }
}