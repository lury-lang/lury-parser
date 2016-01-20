using Lury.Compiling.Lexer;
using Lury.Compiling.Parser;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Collections;
using System.Globalization;
using System.Diagnostics;

namespace UnitTest
{
    [TestClass]
    public class ParsingSyntaxError
    {
        [TestMethod]
        public void SyntaxError()
        {
            var testcases = ErrorResource.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(e => ((string)e.Key).StartsWith("SyntaxError"));

            foreach (var testcase in testcases)
            {
                var lexer = new Lexer("", (string)testcase.Value);
                lexer.Tokenize();

                var parser = new Parser(lexer.TokenOutput);

                parser.Parse();

                Assert.IsTrue(parser.IsFinished);
                Assert.IsNull(parser.TreeOutput);
                Assert.AreNotEqual(0, parser.Logger.Outputs.Count());
                Assert.AreNotEqual(0, parser.Logger.ErrorOutputs.Count());
                Assert.IsTrue(parser.Logger.ErrorOutputs.Any(e => e.OutputNumber == (int)ParserError.SyntaxError));

                var error = parser.Logger.ErrorOutputs.First();
                Debug.WriteLine("Passed: {0} (in: {1})",
                    (string)testcase.Key,
                    error.CodePosition.CharPosition);
                Debug.WriteLine("|" + error.Appendix.Replace("\n", "\n|"));
            }
        }

        [TestMethod]
        public void UnexpectedEOF()
        {
            var testcases = ErrorResource.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(e => ((string)e.Key).StartsWith("UnexpectedEOF"));

            foreach (var testcase in testcases)
            {
                var lexer = new Lexer("", (string)testcase.Value);
                lexer.Tokenize();

                var parser = new Parser(lexer.TokenOutput);

                parser.Parse();

                Assert.IsTrue(parser.IsFinished);
                Assert.IsNull(parser.TreeOutput);
                Assert.AreNotEqual(0, parser.Logger.Outputs.Count());
                Assert.AreNotEqual(0, parser.Logger.ErrorOutputs.Count());
                Assert.IsTrue(parser.Logger.ErrorOutputs.Any(e => e.OutputNumber == (int)ParserError.UnexpectedEOF));

                var error = parser.Logger.ErrorOutputs.First();
                Debug.WriteLine("Passed: {0} (in: {1})",
                    (string)testcase.Key,
                    error.CodePosition.CharPosition);
                Debug.WriteLine("|" + error.Appendix.Replace("\n", "\n|"));
            }
        }
    }
}
