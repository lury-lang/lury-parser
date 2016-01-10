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
        [ExpectedException(typeof(ArgumentNullException))]
        public void ConstructorError()
        {
            // thrown
            var parser = new Parser(null);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void TreeOutputError()
        {
            var lexer = new Lexer("", @"");
            lexer.Tokenize();

            var parser = new Parser(lexer.TokenOutput);

            // thrown: The parsing is not yet started / finished!
            var parserOutput = parser.TreeOutput;
        }

        [TestMethod]
        public void IsFinishedTest()
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

        [TestMethod]
        public void ParseTest3()
        {
            var lexer = new Lexer("", @"pass; pass");
            lexer.Tokenize();

            var parser = new Parser(lexer.TokenOutput, true);
            parser.Parse();

            Assert.IsNotNull(parser.TreeOutput);
            Assert.AreEqual(2, parser.TreeOutput.Count);
        }

        [TestMethod]
        [ExpectedException(typeof(InvalidOperationException))]
        public void ParseError()
        {
            var lexer = new Lexer("", @"");
            lexer.Tokenize();

            var parser = new Parser(lexer.TokenOutput);
            parser.Parse();

            // thrown: The parsing is already finished!
            parser.Parse();
        }
    }
}
