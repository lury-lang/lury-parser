using System;
using Lury.Compiling.Lexer;
using Lury.Compiling.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTest
{
    [TestClass]
    public class ParserTest
    {
        [TestMethod]
        public void IsFinished()
        {
            var lexer = new Lexer("", @"");
            lexer.Tokenize();
            
            var parser = new Parser(lexer.TokenOutput);

            Assert.IsFalse(parser.IsFinished);
            parser.Parse();
            Assert.IsTrue(parser.IsFinished);
        }

        [TestMethod]
        public void ParseTest1()
        {
            var lexer = new Lexer("", @"");
            lexer.Tokenize();
            
            var parser = new Parser(lexer.TokenOutput);
            parser.Parse();

            Assert.IsNotNull(parser.TreeOutput);
            Assert.AreEqual(0, parser.TreeOutput.Count);
        }

        [TestMethod]
        public void ParseTest2()
        {
            var lexer = new Lexer("", @"0");
            lexer.Tokenize();

            var parser = new Parser(lexer.TokenOutput);
            parser.Parse();

            Assert.IsNotNull(parser.TreeOutput);
            Assert.AreEqual(1, parser.TreeOutput.Count);
        }
    }
}
