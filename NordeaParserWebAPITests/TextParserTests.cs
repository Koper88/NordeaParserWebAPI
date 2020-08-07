using Microsoft.VisualStudio.TestTools.UnitTesting;
using NordeaParserWebAPI;
using System;
using System.Collections.Generic;
using System.Text;

namespace NordeaParserWebAPI.Tests
{
    [TestClass()]
    public class TextParserTests
    {
        static TextParser parser = new TextParser();

        [TestMethod()]
        public void ParseTest1()
        {
            var res = parser.Parse(" ");
            Assert.AreEqual(res.Count, 0);
        }

        [TestMethod()]
        public void ParseTest2()
        {
            var res = parser.Parse(".,,..!  .");
            Assert.AreEqual(res.Count, 0);
        }

        [TestMethod()]
        public void ParseTest3()
        {
            var res = parser.Parse("Mary had");
            Assert.AreEqual(res.Count, 1);
            Assert.AreEqual(res[0].Words.Count, 2);
        }

        [TestMethod()]
        public void ParseTest4()
        {
            var res = parser.Parse("Mary.had");
            Assert.AreEqual(res.Count, 2);
            Assert.AreEqual(res[0].Words.Count, 1);
            Assert.AreEqual(res[1].Words.Count, 1);
        }

        [TestMethod()]
        public void ParseTest5()
        {
            var res = parser.Parse("Mary?had a lamb");
            Assert.AreEqual(res.Count, 2);
            Assert.AreEqual(res[0].Words.Count, 1);
            Assert.AreEqual(res[1].Words.Count, 3);
        }

        [TestMethod()]
        public void ParseTest6()
        {
            var res = parser.Parse("Mary,had");
            Assert.AreEqual(res.Count, 1);
            Assert.AreEqual(res[0].Words.Count, 2);
        }

        [TestMethod()]
        public void ParseTest7()
        {
            var res = parser.Parse("Mary had a little lamb. Peter called for the wolf.");
            Assert.AreEqual(res.Count, 2);
            Assert.AreEqual(res[0].Words.Count, 5);
            Assert.AreEqual(res[1].Words.Count, 5);
        }

        [TestMethod()]
        public void ParseTest8()
        {
            var res = parser.Parse("..bbbb, aaa'a. ffffff: gg! d");
            Assert.AreEqual(res.Count, 3);
            Assert.AreEqual(res[0].Words.Count, 2);
            Assert.AreEqual(res[1].Words.Count, 2);
            Assert.AreEqual(res[2].Words.Count, 1);
            Assert.AreEqual(res[0].Words[0].Length, 5);
            Assert.AreEqual(res[0].Words[1].Length, 4);
            Assert.AreEqual(res[1].Words[0].Length, 6);
            Assert.AreEqual(res[1].Words[1].Length, 2);
            Assert.AreEqual(res[2].Words[0].Length, 1);
        }
    }
}