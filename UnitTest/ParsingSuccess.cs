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
    public class ParsingSuccess
    {
        [TestMethod]
        public void Success()
        {
            var testcases = SuccessResource.ResourceManager.GetResourceSet(CultureInfo.InvariantCulture, true, true)
                .OfType<DictionaryEntry>()
                .Where(e => ((string)e.Key).StartsWith("Success"));

            foreach (var testcase in testcases)
            {
                var lexer = new Lexer("", (string)testcase.Value);
                lexer.Tokenize();

                var parser = new Parser(lexer.TokenOutput);

                parser.Parse();

                Assert.IsTrue(parser.IsFinished, "テストケース: " + (string)testcase.Key);
                Assert.IsNotNull(parser.TreeOutput, "テストケース: " + (string)testcase.Key);
                Assert.AreEqual(0, parser.Logger.Outputs.Count(), "テストケース: " + (string)testcase.Key);

                Debug.WriteLine("Passed: {0}", testcase.Key);
            }
        }
    }
}
