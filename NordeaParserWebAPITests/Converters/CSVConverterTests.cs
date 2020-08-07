using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordeaParserWebAPI.Converters;
using NordeaParserWebAPI.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace NordeaParserWebAPI.Converters.Tests
{
    [TestClass()]
    public class CSVConverterTests
    {
        [TestMethod()]
        public void ConvertTest()
        {
            var sentences = new List<Sentence> {
                new Sentence { Words = new List<string> { "aaaa","bbbb", "cccc"} },
                new Sentence { Words = new List<string> { "dddd","eeee"} },
                new Sentence { Words = new List<string> { "ffff","gggg", "hhhh", "jjjj"} },
                new Sentence { Words = new List<string> { "kkkk"} }
            };

            var converter = new CSVConverter();
            var csv = converter.Convert(sentences);

            Assert.IsTrue(csv.StartsWith("Word 1, Word 2, Word 3, Word 4"));

            var splitedCSV = csv.Split("\n");

            Assert.AreEqual(splitedCSV[1], "Sentence 1, aaaa, bbbb, cccc");
            Assert.AreEqual(splitedCSV[2], "Sentence 2, dddd, eeee");
            Assert.AreEqual(splitedCSV[3], "Sentence 3, ffff, gggg, hhhh, jjjj");
            Assert.AreEqual(splitedCSV[4], "Sentence 4, kkkk");
        }
    }
}