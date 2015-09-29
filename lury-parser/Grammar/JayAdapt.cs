//
// JayAdapt.cs
//
// Author:
//       Tomona Nanase <nanase@users.noreply.github.com>
//
// The MIT License (MIT)
//
// Copyright (c) 2015 Tomona Nanase
//
// Permission is hereby granted, free of charge, to any person obtaining a copy
// of this software and associated documentation files (the "Software"), to deal
// in the Software without restriction, including without limitation the rights
// to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
// copies of the Software, and to permit persons to whom the Software is
// furnished to do so, subject to the following conditions:
//
// The above copyright notice and this permission notice shall be included in
// all copies or substantial portions of the Software.
//
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
// IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.

using System.Collections.Generic;

using LToken = Lury.Compiling.Lexer.Token;
using PToken = Lury.Compiling.Parser.Token;

namespace Lury.Compiling.Parser
{
    internal class Lex2yyInput : yyParser.yyInput
    {
        private IEnumerator<LToken> tokenEnumerator;

        public Lex2yyInput(IEnumerable<LToken> token)
        {
            this.tokenEnumerator = token.GetEnumerator();
        }

        public bool Advance()
        {
            return this.tokenEnumerator.MoveNext();
        }

        public yyParser.IToken GetToken()
        {
            return new Token2yyToken(this.tokenEnumerator.Current);
        }

        public object GetValue()
        {
            return this.tokenEnumerator.Current;
        }
    }

    internal class Token2yyToken : yyParser.IToken
    {
        public LToken Token { get; private set; }

        public Token2yyToken(LToken token)
        {
            this.Token = token;
        }

        public int TokenNumber
        {
            get
            {
                if (this.Token.Entry.Name.Length == 1)
                    return (int)this.Token.Entry.Name[0];

                return tokenMap[this.Token.Entry.Name];
            }
        }

        #region -- Private Static Fields --

        private readonly Dictionary<string, int> tokenMap = new Dictionary<string, int>()
            {
                { "NewLine", PToken.NewLine },
                { "Indent", PToken.Indent },
                { "Dedent", PToken.Dedent },
                { "EndOfFile", PToken.NewLine },  // EndOfFile -> NewLine
                { "IdentifierGet", PToken.IdentifierGet },
                { "IdentifierSet", PToken.IdentifierSet },
                { "IdentifierFile", PToken.IdentifierFile },
                { "IdentifierLine", PToken.IdentifierLine },
                { "IdentifierExit", PToken.IdentifierExit },
                { "IdentifierSuccess", PToken.IdentifierSuccess },
                { "IdentifierFailure", PToken.IdentifierFailure },
                { "KeywordAbstract", PToken.KeywordAbstract },
                { "KeywordAnd", PToken.KeywordAnd },
                { "KeywordBreak", PToken.KeywordBreak },
                { "KeywordCase", PToken.KeywordCase },
                { "KeywordCatch", PToken.KeywordCatch },
                { "KeywordClass", PToken.KeywordClass },
                { "KeywordContinue", PToken.KeywordContinue },
                { "KeywordDef", PToken.KeywordDef },
                { "KeywordDefault", PToken.KeywordDefault },
                { "KeywordDelete", PToken.KeywordDelete },
                { "KeywordElif", PToken.KeywordElif },
                { "KeywordElse", PToken.KeywordElse },
                { "KeywordEnum", PToken.KeywordEnum },
                { "KeywordExtended", PToken.KeywordExtended },
                { "KeywordFalse", PToken.KeywordFalse },
                { "KeywordFinally", PToken.KeywordFinally },
                { "KeywordFor", PToken.KeywordFor },
                { "KeywordIf", PToken.KeywordIf },
                { "KeywordImport", PToken.KeywordImport },
                { "KeywordIn", PToken.KeywordIn },
                { "KeywordInterface", PToken.KeywordInterface },
                { "KeywordInvariant", PToken.KeywordInvariant },
                { "KeywordIs", PToken.KeywordIs },
                { "KeywordLazy", PToken.KeywordLazy },
                { "KeywordNameof", PToken.KeywordNameof },
                { "KeywordNew", PToken.KeywordNew },
                { "KeywordNil", PToken.KeywordNil },
                { "KeywordNot", PToken.KeywordNot },
                { "KeywordOr", PToken.KeywordOr },
                { "KeywordOut", PToken.KeywordOut },
                { "KeywordOverride", PToken.KeywordOverride },
                { "KeywordPass", PToken.KeywordPass },
                { "KeywordPrivate", PToken.KeywordPrivate },
                { "KeywordProperty", PToken.KeywordProperty },
                { "KeywordProtected", PToken.KeywordProtected },
                { "KeywordPublic", PToken.KeywordPublic },
                { "KeywordRef", PToken.KeywordRef },
                { "KeywordReflect", PToken.KeywordReflect },
                { "KeywordReturn", PToken.KeywordReturn },
                { "KeywordScope", PToken.KeywordScope },
                { "KeywordSealed", PToken.KeywordSealed },
                { "KeywordStatic", PToken.KeywordStatic },
                { "KeywordSuper", PToken.KeywordSuper },
                { "KeywordSwitch", PToken.KeywordSwitch },
                { "KeywordThis", PToken.KeywordThis },
                { "KeywordThrow", PToken.KeywordThrow },
                { "KeywordTrue", PToken.KeywordTrue },
                { "KeywordTry", PToken.KeywordTry },
                { "KeywordUnittest", PToken.KeywordUnittest },
                { "KeywordUnless", PToken.KeywordUnless },
                { "KeywordUntil", PToken.KeywordUntil },
                { "KeywordVar", PToken.KeywordVar },
                { "KeywordWhile", PToken.KeywordWhile },
                { "KeywordWith", PToken.KeywordWith },
                { "KeywordYield", PToken.KeywordYield },
                { "Identifier", PToken.Identifier },
                { "StringLiteral", PToken.StringLiteral },
                { "EmbedStringLiteral", PToken.EmbedStringLiteral },
                { "WysiwygStringLiteral", PToken.WysiwygStringLiteral },
                { "ImaginaryNumber", PToken.ImaginaryNumber },
                { "FloatNumber", PToken.FloatNumber },
                { "Integer", PToken.Integer },
                { "RangeOpen", PToken.RangeOpen },
                { "RangeClose", PToken.RangeClose },
                { "Increment", PToken.Increment },
                { "AssignmentAdd", PToken.AssignmentAdd },
                { "Decrement", PToken.Decrement },
                { "AssignmentSub", PToken.AssignmentSub },
                { "AnnotationReturn", PToken.AnnotationReturn },
                { "AssignmentConcat", PToken.AssignmentConcat },
                { "AssignmentPower", PToken.AssignmentPower },
                { "Power", PToken.Power },
                { "AssignmentMultiply", PToken.AssignmentMultiply },
                { "AssignmentIntDivide", PToken.AssignmentIntDivide },
                { "IntDivide", PToken.IntDivide },
                { "AssignmentDivide", PToken.AssignmentDivide },
                { "AssignmentModulo", PToken.AssignmentModulo },
                { "AssignmentLeftShift", PToken.AssignmentLeftShift },
                { "LeftShift", PToken.LeftShift },
                { "LessThan", PToken.LessThan },
                { "AssignmentRightShift", PToken.AssignmentRightShift },
                { "RightShift", PToken.RightShift },
                { "MoreThan", PToken.MoreThan },
                { "Equal", PToken.Equal },
                { "Lambda", PToken.Lambda },
                { "NotEqual", PToken.NotEqual },
                { "NotIn", PToken.NotIn },
                { "IsNot", PToken.IsNot },
                { "AndShort", PToken.AndShort },
                { "AssignmentAnd", PToken.AssignmentAnd },
                { "AssignmentXor", PToken.AssignmentXor },
                { "OrShort", PToken.OrShort },
                { "AssignmentOr", PToken.AssignmentOr },
                { "NilCoalesce", PToken.NilCoalesce },
            };

        #endregion
    }
}
